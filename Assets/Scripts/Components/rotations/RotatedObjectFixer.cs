using System;
using UnityEngine;

namespace Components.rotations
{
    public class RotatedObjectFixer : MonoBehaviour
    {
        [SerializeField] private MouseInputRotator rotator;

        [NonSerialized] private double _beforeFrameRadian = 0;


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

        private void Update()
        {
            var distance = Math.Sqrt(X * X + Y * Y);
            var radian = Math.Atan2(Y, X) + rotator.RadianZ - _beforeFrameRadian;

            X = (float) (Math.Cos(radian) * distance);
            Y = (float) (Math.Sin(radian) * distance);

            _beforeFrameRadian = rotator.RadianZ;
        }
    }
}