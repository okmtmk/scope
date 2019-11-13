using System;
using System.Diagnostics;
using Components.simpleColliders;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Components.models
{
    public class Bullet : MonoBehaviour
    {
        [NonSerialized] private readonly Stopwatch _stopwatch = new Stopwatch();
        [NonSerialized] public float RotationZ;
        [SerializeField] public int speed;

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

        private float ElapsedSecond => _stopwatch.ElapsedMilliseconds / 1000f;

        private double RadianZ => (RotationZ + 90) * Mathf.Deg2Rad;

        private void Start()
        {
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, RotationZ);
            _stopwatch.Start();
        }

        private void Update()
        {
            Move(RadianZ);

            _stopwatch.Restart();
        }

        public void OnSpriteColliderEnter(SpriteCollider2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("敵にダメージを与えた！");
                Destroy(gameObject);
            }
        }

        public void OnExitMovableArea(int distance)
        {
            Destroy(gameObject);
        }

        private void Move(double radian)
        {
            X += (float) Math.Cos(radian) * speed * ElapsedSecond;
            Y += (float) Math.Sin(radian) * speed * ElapsedSecond;
        }
    }
}