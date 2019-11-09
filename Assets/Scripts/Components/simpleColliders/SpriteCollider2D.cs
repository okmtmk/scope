using System;
using System.Collections.Generic;
using System.Linq;
using Components.models;
using src.colliders;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Components.simpleColliders
{
    [Serializable]
    public class ColliderEvent : UnityEvent<SpriteCollider2D>
    {
    }

    /**
     * 矩形同士のシンプルな当たり判定処理
     */
    public class SpriteCollider2D : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer sprite;
        [SerializeField] public ColliderEvent onColliderEnter = new ColliderEvent();
        [SerializeField] public ColliderEvent onColliding = new ColliderEvent();
        [SerializeField] public ColliderEvent onColliderExit = new ColliderEvent();

        public float X => gameObject.transform.position.x;
        public float Y => gameObject.transform.position.y;

        public float Width => sprite.bounds.size.x;
        public float Height => sprite.bounds.size.y;

        /*
         * 静的フィールド
         */

        [NonSerialized] private static readonly List<SpriteCollider2D> Colliders
            = new List<SpriteCollider2D>();

        [NonSerialized] private static readonly List<CollidedPair> CollidedPairs
            = new List<CollidedPair>();

        /*
         * 同一フレームでの多重判定防止
         */

        [NonSerialized] private static readonly List<CollidedPair> DecidedInFrame
            = new List<CollidedPair>();

        [NonSerialized] private static int _processFrameCount;

        private static bool IsSameFrame => Time.frameCount == _processFrameCount;

        /*
         * Unity event functions
         */

        private void OnEnable()
        {
            Colliders.Add(this);
        }

        private void OnDisable()
        {
            RemoveContainCollidedPair();
            Colliders.Remove(this);
        }

        private void Update()
        {
            if (!IsSameFrame)
            {
                FreshCollided();
            }

            var list = new List<SpriteCollider2D>(Colliders);
            list.Remove(this);

            list.ForEach(other =>
            {
                if (IsDecidedPairInFrame(other))
                {
                    return;
                }
                else
                {
                    AddSameFrameDecidedPair(other);
                }

                if (IsColliding(other))
                {
                    HandleColliding(other);
                }
                else if (IsCollidedPair(other))
                {
                    HandleColliderExit(other);
                }
            });
        }

        /*
         * 当たり判定比較
         */

        /// <summary>
        /// 他方と重なっているか調べる
        /// </summary>
        /// <param name="other">比較対象</param>
        /// <returns>重なっているかどうか</returns>
        private bool IsColliding(SpriteCollider2D other)
        {
            return Math.Abs(X - other.X) < Width / 2 + other.Width / 2 &&
                   Math.Abs(Y - other.Y) < Height / 2 + other.Height / 2;
        }

        /// <summary>
        /// 前フレームで重なっていたかどうか調べる
        /// </summary>
        /// <param name="other">比較対象</param>
        /// <returns>重なっていたどうか</returns>
        private bool IsCollidedPair(SpriteCollider2D other)
        {
            return CollidedPairs.Any(it => it.IsEquals(this, other));
        }

        /*
         * コールバックのハンドリング
         */

        /// <summary>
        /// 重なった時のコールバックメソッドを実行します。
        /// 前フレームで重なっていなかったペアであればOnColliderEnterイベントもハンドルします。
        /// </summary>
        /// <param name="other">重なっているオブジェクト</param>
        private void HandleColliding(SpriteCollider2D other)
        {
            if (!IsCollidedPair(other))
            {
                CollidedPairs.Add(new CollidedPair(this, other));

                onColliderEnter.Invoke(other);
                other.onColliderEnter.Invoke(this);
            }

            onColliding.Invoke(other);
            other.onColliding.Invoke(this);
        }

        /// <summary>
        /// 重ならなくなった時のコールバックメソッドを実行します。
        /// </summary>
        /// <param name="other">重なっていたオブジェクト</param>
        private void HandleColliderExit(SpriteCollider2D other)
        {
            RemoveCollidedPair(other);

            onColliderExit.Invoke(other);
            other.onColliderExit.Invoke(this);
        }

        /*
         * 当たり判定計算からの除外
         */

        /// <summary>
        /// 重なっていたオブジェクトのペアを削除します
        /// </summary>
        /// <param name="other">重なっていたオブジェクト</param>
        private void RemoveCollidedPair(SpriteCollider2D other)
        {
            CollidedPair target = null;
            foreach (var it in CollidedPairs.Where(it => it.IsEquals(this, other)))
            {
                target = it;
            }

            if (target != null)
            {
                CollidedPairs.Remove(target);
            }
        }

        /// <summary>
        /// 重なっていたオブジェクトのペアからインスタンスが含まれているペアをすべて削除します
        /// </summary>
        private void RemoveContainCollidedPair()
        {
            var list = CollidedPairs.Where(it => it.IsContains(this)).ToList();
            list.ForEach(it => CollidedPairs.Remove(it));
        }

        /*
         * 多重判定の防止
         */

        /// <summary>
        /// 同一フレームで当たり判定処理をしているか判定します
        /// </summary>
        /// <param name="other">重なっているオブジェクト</param>
        /// <returns>同一フレームで当たり判定処理済みであるか否か</returns>
        private bool IsDecidedPairInFrame(SpriteCollider2D other)
        {
            return DecidedInFrame.Any(it => it.IsEquals(this, other));
        }

        /// <summary>
        /// 同一フレームでの当たり判定処理済みペアリストをクリアします
        /// </summary>
        private static void FreshCollided()
        {
            DecidedInFrame.Clear();
            _processFrameCount = Time.frameCount;
        }

        /// <summary>
        /// 同一フレームでの当たり判定処理済みペアとしてリストに追加します
        /// </summary>
        /// <param name="other">重なっているオブジェクト</param>
        private void AddSameFrameDecidedPair(SpriteCollider2D other)
        {
            DecidedInFrame.Add(new CollidedPair(this, other));
        }
    }
}