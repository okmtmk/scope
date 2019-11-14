using System;
using System.Diagnostics;
using Components.effects;
using Components.simpleColliders;
using src.scenes;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Components.models
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerEffect effect;
        [SerializeField] private SceneModel sceneModel;
        [NonSerialized] private readonly Stopwatch _stopwatch = new Stopwatch();

        private bool _isDamaged;
        private bool _isDamagedAvailable;

        private float X
        {
            get => gameObject.transform.position.x;
            set => gameObject.transform.position = new Vector2(value, Y);
        }

        private float Y
        {
            get => gameObject.transform.position.y;
            set => gameObject.transform.position = new Vector2(X, value);
        }

        public bool IsDamagedAvailable
        {
            get => _stopwatch.ElapsedMilliseconds > 1000 || !_stopwatch.IsRunning;
        }

        private bool IsDamaged
        {
            get => _isDamaged;
            set
            {
                _isDamaged = value;

                if (value)
                {
                    OnDamaged();
                }
                else
                {
                    OnNonDamaged();
                }
            }
        }

        private void Update()
        {
            if (_stopwatch.ElapsedMilliseconds > 5000)
            {
                IsDamaged = false;
                _stopwatch.Stop();
                _stopwatch.Reset();
            }
        }

        public void OnExitMovableArea(int movableDistance)
        {
            var radian = Math.Atan2(Y, X);
            X = (float) (Math.Cos(radian) * movableDistance);
            Y = (float) (Math.Sin(radian) * movableDistance);
        }

        public void OnSpriteCollisionEnter(SpriteCollider2D other)
        {
            if (other.gameObject.CompareTag("Enemy") && IsDamagedAvailable)
            {
                Debug.Log("ダメージを受けた");

                effect.PlayDamageEffect();
                _stopwatch.Start();


                if (IsDamaged)
                {
                    sceneModel.SceneState = SceneState.GameOver;
                    Destroy(gameObject);
                }
                else
                {
                    IsDamaged = true;
                }
            }
        }

        public void OnSpriteColliding(SpriteCollider2D other)
        {
        }

        public void OnSpriteColliderExit(SpriteCollider2D other)
        {
        }

        private void OnDamaged()
        {
            effect.PlayEffect();
        }

        private void OnNonDamaged()
        {
            effect.StopEffect();
        }
    }
}