using System;
using System.Collections.Generic;
using UnityEngine;

namespace Components.rotations
{
    public class MouseInputRotator : MonoBehaviour
    {
        [SerializeField] private int rotateSpeed = 1;

        [NonSerialized] private float _mouseBasePositionX;
        [NonSerialized] private const float RotationLimit = 45;
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
                if (IsInRange)
                {
                    return InnerRotationZ;
                }

                if (InnerRotationZ > RotationLimit)
                {
                    return RotationLimit;
                }

                return -RotationLimit;
            }
        }

        public bool IsInRange => InnerRotationZ <= RotationLimit && InnerRotationZ >= -RotationLimit;

        protected virtual void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        protected virtual void Update()
        {
            InnerRotationZ += Angle;
            RotationZ = OuterRotationZ;

            if (Input.GetKeyDown(KeyCode.Q))
            {
                InnerRotationZ = 0;
            }
        }
    }
}