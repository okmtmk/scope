using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using src.positions;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using Debug = UnityEngine.Debug;

namespace Components.KeyInputs
{
    public class KeyInputtingMover : MonoBehaviour
    {
        private Stopwatch _stopwatch;
        private MovablePosition2 _position2;

        private void Start()
        {
            _position2 = new MovablePosition2(gameObject.transform.position);
            _stopwatch = new Stopwatch();
        }

        private void Update()
        {
            var direction = MovingKey.GetMovingDirection();

            if (!(direction.x == 0 && direction.y == 0))
            {
                _position2.Move(direction, 5, _stopwatch.ElapsedMilliseconds);
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