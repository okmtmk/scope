using System;
using System.Diagnostics;
using src.positions;
using UnityEngine;
using UnityEngine.Serialization;
using Debug = UnityEngine.Debug;

// ReSharper disable All

namespace Components.KeyInputs
{
    public class KeyInputtingMover : MonoBehaviour
    {
        private Stopwatch _stopwatch;
        private MovablePosition2 _position2;

        [SerializeField] private float moveSpeed = 15;

        private void Start()
        {
            _position2 = new MovablePosition2(gameObject.transform.position, 15);
            _stopwatch = new Stopwatch();
        }

        private void Update()
        {
            _position2.Sync(gameObject.transform.position);
            var direction = MovingKey.GetMovingDirection();

            if (!(direction.x == 0 && direction.y == 0))
            {
                float radius = (float) Math.Atan2(direction.y, direction.x) +
                               gameObject.transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
               
                _position2.Move(radius, moveSpeed, _stopwatch.ElapsedMilliseconds);
                _position2.FitMovableArea();
                _stopwatch.Restart();

                gameObject.transform.position = new Vector3(_position2.X, _position2.Y, 0);
            }
            else
            {
                _stopwatch.Stop();
                _stopwatch.Reset();
            }
        }
    }
}