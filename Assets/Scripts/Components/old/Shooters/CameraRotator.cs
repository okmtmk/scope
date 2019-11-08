using System;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Components.old.Shooters
{
    public class CameraRotator : MonoBehaviour
    {
        [SerializeField] public int rotationSpeed = 10;
        [SerializeField] private Transform camera;

        [NonSerialized] private float _baseX;

        [NonSerialized] private float _beforeFrameRotated = 0;
        [NonSerialized] private double _beforeFrameRadian = 0;
        [NonSerialized] private readonly Stopwatch _stopwatch = new Stopwatch();

        private void Start()
        {
            _baseX = Input.mousePosition.x;
            _stopwatch.Start();
        }

        private void Update()
        {
//            gameObject.transform.Rotate(
//                0, 0, -(Input.mousePosition.x - _baseX) / 100 * rotationSpeed);
            gameObject.transform.rotation =
                Quaternion.Euler(0f, 0f, -(Input.mousePosition.x - _baseX) / 100 * rotationSpeed);
            camera.rotation = gameObject.transform.rotation;
            _beforeFrameRotated = Input.mousePosition.x - _baseX;


            Replace();


            if (Input.GetKeyDown(KeyCode.Q))
            {
                _baseX = Input.mousePosition.x;
            }

            _stopwatch.Restart();
        }

        private void Replace()
        {
            var position = gameObject.transform.position;

            var distance = Math.Sqrt(position.x * position.x + position.y * position.y);
            var radian =
                Math.Atan2(position.y, position.x) + camera.rotation.eulerAngles.z * Mathf.Deg2Rad;

            Debug.Log(
                $"x : {Math.Cos(radian) * distance}\ny : {Math.Sin(radian) * distance}\tradian : {Math.Sin(radian)}");

            gameObject.transform.position = new Vector2(
                (float) (Math.Cos(radian) * distance),
                (float) (Math.Sin(radian) * distance)
            );
        }
    }
}