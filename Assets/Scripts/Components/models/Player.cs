using System;
using Components.simpleColliders;
using UnityEngine;
using UnityEngine.Serialization;

namespace Components.models
{
    public class Player : MonoBehaviour
    {
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

        public void OnExitMovableArea(int movableDistance)
        {
            var radian = Math.Atan2(Y, X);
            X = (float) (Math.Cos(radian) * movableDistance);
            Y = (float) (Math.Sin(radian) * movableDistance);
        }

        public void OnSpriteCollisionEnter(SpriteCollider2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("敵にあたった！");
            }
        }

        public void OnSpriteColliding(SpriteCollider2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("敵にめり込んでる");
            }
        }

        public void OnSpriteColliderExit(SpriteCollider2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("敵から離れた");
            }
        }
    }
}