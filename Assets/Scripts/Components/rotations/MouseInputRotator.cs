using System;
using UnityEngine;

namespace Components.rotations
{
    public class MouseInputRotator : MonoBehaviour
    {
        [SerializeField] private int rotateSpeed = 1;

        [NonSerialized] private float _mouseBasePositionX;

        protected float RotationZ
        {
            get => gameObject.transform.rotation.eulerAngles.z;
            set => gameObject.transform.rotation = Quaternion.Euler(0f, 0f, value);
        }

        public float RadianZ => RotationZ * Mathf.Deg2Rad;

        public float Angle => -(Input.mousePosition.x - _mouseBasePositionX) / 100 * rotateSpeed;

        protected virtual void Start()
        {
            SetMouseBasePosition();
        }

        protected virtual void Update()
        {
            RotationZ = Angle;

            if (Input.GetKeyDown(KeyCode.Q))
            {
                SetMouseBasePosition();
            }
        }

        protected void SetMouseBasePosition()
        {
            _mouseBasePositionX = Input.mousePosition.x;
        }
    }
}