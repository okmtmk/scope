using System;
using UnityEngine;

namespace Components.rotations
{
    public class MouseInputRotator : MonoBehaviour
    {
        [SerializeField] private int rotateSpeed = 1;

        [NonSerialized] private float _mouseBasePositionX;

        private float RotationZ
        {
            get => gameObject.transform.rotation.eulerAngles.z;
            set => gameObject.transform.rotation = Quaternion.Euler(0f, 0f, value);
        }

        public float RadianZ => RotationZ * Mathf.Deg2Rad;

        private float Angle => -(Input.mousePosition.x - _mouseBasePositionX) / 10 * rotateSpeed;

        private void Start()
        {
            SetMouseBasePosition();
        }

        private void Update()
        {
            RotationZ = Angle;

            if (Input.GetKeyDown(KeyCode.Q))
            {
                SetMouseBasePosition();
            }
        }

        private void SetMouseBasePosition()
        {
            _mouseBasePositionX = Input.mousePosition.x;
        }
    }
}