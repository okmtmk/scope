using System;
using UnityEngine;

namespace Components.rotations
{
    public class MouseInputRotator : MonoBehaviour
    {
        [SerializeField] private int rotateSpeed = 5;

        [NonSerialized] private float _mouseBasePositionX;

        public float RadianZ => gameObject.transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        private float Angle => -(Input.mousePosition.x - _mouseBasePositionX) / 10 * rotateSpeed;


        private void Start()
        {
            _mouseBasePositionX = Input.mousePosition.x;
        }

        private void Update()
        {
            gameObject.transform.rotation =
                Quaternion.Euler(0f, 0f, Angle);
        }
    }
}