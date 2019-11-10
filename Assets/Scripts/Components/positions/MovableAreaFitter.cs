using System;
using UnityEngine;
using UnityEngine.Events;

namespace Components.positions
{
    [Serializable]
    public class OnMovableAreaExitEvent : UnityEvent<int>
    {
    }

    public class MovableAreaFitter : MonoBehaviour
    {
        [SerializeField] private int movableDistance = 15;

        [SerializeField] private OnMovableAreaExitEvent onExitMovableArea = new OnMovableAreaExitEvent();

        private float X => gameObject.transform.position.x;

        private float Y => gameObject.transform.position.y;

        private void Update()
        {
            if (Math.Sqrt(X * X + Y * Y) > movableDistance) onExitMovableArea.Invoke(movableDistance);
        }
    }
}