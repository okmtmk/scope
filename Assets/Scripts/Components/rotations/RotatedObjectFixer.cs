using System;
using UnityEngine;

namespace Components.rotations
{
    public class RotatedObjectFixer : MonoBehaviour
    {
        [SerializeField] private MouseInputRotator rotator;

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

        private void Update()
        {
            var distance = Math.Sqrt(X * X + Y * Y);
            var radian = Math.Atan2(Y, X) + rotator.RadianZ;

            X = (float) (Math.Cos(radian) * distance);
            Y = (float) (Math.Sin(radian) * distance);
        }
    }
}