using UnityEngine;

namespace src.collisions
{
    public interface ICollidable
    {
        float X { get; }
        float Y { get; }

        float Width { get; }
        float Height { get; }

        /**
         * あたっている間の処理
         */
        void OnCollide(ICollidable collidable);

        /**
         * 初めてあたったときの処理
         */
        void OnEnterCollider(ICollidable collidable);

        /**
         * 当たり判定を抜けたときの処理
         */
        void OnExitCollider(ICollidable collidable);
    }
}