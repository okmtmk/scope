using System;
using UnityEngine;

namespace Components.rotations
{
    public class MouseInputRotator : MonoBehaviour
    {
        [SerializeField] private int rotateSpeed = 1;
        [SerializeField] private float rotationLimit = 45;
        [SerializeField] private CursorLockMode cursorLockMode = CursorLockMode.Locked;

        [NonSerialized] private float _mouseBasePositionX;
        [NonSerialized] public float InnerRotationZ;


        protected float RotationZ
        {
            get => gameObject.transform.rotation.eulerAngles.z;
            set => gameObject.transform.rotation = Quaternion.Euler(0f, 0f, value);
        }

        public float RadianZ => RotationZ * Mathf.Deg2Rad;

        private float Angle => Input.GetAxis("Mouse X") * -rotateSpeed * 0.1f;

        public float OuterRotationZ
        {
            get
            {
                if (IsInRange) return InnerRotationZ;

                if (InnerRotationZ > rotationLimit) return rotationLimit;

                return -rotationLimit;
            }
        }

        public bool IsInRange => InnerRotationZ <= rotationLimit && InnerRotationZ >= -rotationLimit;

        protected virtual void Start()
        {
            Cursor.lockState = cursorLockMode;
        }

        protected virtual void Update()
        {
            InnerRotationZ += Angle;
            RotationZ = OuterRotationZ;

            if (Input.GetKeyDown(KeyCode.Q)) InnerRotationZ = 0;
        }
    }
}