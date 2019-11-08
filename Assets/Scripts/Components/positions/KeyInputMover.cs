using System;
using System.Diagnostics;
using src.positions;
using UnityEngine;

namespace Components.positions
{
    public class KeyInputMover : MonoBehaviour
    {
        private Stopwatch _stopwatch;
        private MovablePosition2 _position2;

        [SerializeField] private float moveSpeed = 15;

        private float X
        {
            get => gameObject.transform.position.x;
            set
            {
                var position = gameObject.transform.position;
                position.Set(
                    value,
                    position.y,
                    position.z
                );
            }
        }

        private float Y
        {
            get => gameObject.transform.position.y;
            set
            {
                var position = gameObject.transform.position;
                position.Set(
                    position.x,
                    value,
                    position.z
                );
            }
        }

        private float RadianZ => gameObject.transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        private long ElapsedSecond => _stopwatch.ElapsedMilliseconds / 1000;

        private void Start()
        {
            _position2 = new MovablePosition2(gameObject.transform.position, 15);
            _stopwatch = new Stopwatch();
        }

        private void Update()
        {
            _position2.Sync(gameObject.transform.position);
            var direction = MovingKey.GetMovingDirection();

            if (Math.Abs(direction.x) > 0 || Math.Abs(direction.y) > 0)
            {
                var radian = (float) Math.Atan2(direction.y, direction.x) + RadianZ;
                Move(radian);
                
                _stopwatch.Restart();
            }
            else
            {
                _stopwatch.Stop();
                _stopwatch.Reset();
            }
        }

        private void Move(float radian)
        {
            X += (float) Math.Cos(radian) * moveSpeed * ElapsedSecond;
            Y += (float) Math.Sin(radian) * moveSpeed * ElapsedSecond;
        }
    }
}