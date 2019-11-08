using System;
using UnityEngine;

namespace Components.models
{
    public class Shooter : MonoBehaviour
    {
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

        public void OnExitMovableArea(int movableDistance)
        {
            var radian = Math.Atan2(Y, X);
            X = (float) (Math.Cos(radian) * movableDistance);
            Y = (float) (Math.Sin(radian) * movableDistance);
        }
    }
}