using System;
using System.Diagnostics;
using src.positions;
using UnityEngine;

namespace Components.positions
{
    public class KeyInputMover : MonoBehaviour
    {
        private readonly Stopwatch _stopwatch = new Stopwatch();

        [SerializeField] private float moveSpeed = 20;

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

        private float RadianZ => gameObject.transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        private float ElapsedSecond => _stopwatch.ElapsedMilliseconds / 1000f;

        private void Start()
        {
            _stopwatch.Start();
        }

        private void Update()
        {
            var direction = MovingKey.GetMovingDirection();

            if (Math.Abs(direction.x) > 0 || Math.Abs(direction.y) > 0)
            {
                var radian = Math.Atan2(direction.y, direction.x) + RadianZ;
                Move(radian);

                _stopwatch.Restart();
            }
            else
            {
                _stopwatch.Stop();
                _stopwatch.Reset();
            }
        }

        private void Move(double radian)
        {
            X += (float) Math.Cos(radian) * moveSpeed * ElapsedSecond;
            Y += (float) Math.Sin(radian) * moveSpeed * ElapsedSecond;
        }
    }
}