using System;
using UnityEngine;

namespace Components.rotations
{
    public class MouseInputRotator : MonoBehaviour
    {
        [SerializeField] private int rotateSpeed = 1;

        [NonSerialized] private float _mouseBasePositionX;

        public float RotationZ
        {
            get => gameObject.transform.rotation.eulerAngles.z;
            set => gameObject.transform.rotation = Quaternion.Euler(0f, 0f, value);
        }

        public float RadianZ => RotationZ * Mathf.Deg2Rad;

        public float Angle => Input.GetAxis("Mouse X") * -rotateSpeed;

        protected virtual void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        protected virtual void Update()
        {
            RotationZ += Angle;

            if (Input.GetKeyDown(KeyCode.Q))
            {
                RotationZ = 0;
            }
        }
    }
}