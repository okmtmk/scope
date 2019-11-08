using System;
using UnityEngine;

namespace Components.positions
{
    public class MovableAreaFitter : MonoBehaviour
    {
        [SerializeField] private int movableDistance = 15;

        private float X
        {
            get => gameObject.transform.position.x;
            set => gameObject.transform.position = new Vector2(value, gameObject.transform.position.y);
        }

        private float Y
        {
            get => gameObject.transform.position.y;
            set => gameObject.transform.position = new Vector2(gameObject.transform.position.x, value);
        }

        private void Update()
        {
            if (Math.Sqrt(X * X + Y * Y) > 15)
            {
                var radian = Math.Atan2(Y, X);
                X = (float) (Math.Cos(radian) * movableDistance);
                Y = (float) (Math.Sin(radian) * movableDistance);
            }
        }
    }
}