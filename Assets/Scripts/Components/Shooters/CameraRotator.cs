using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using Debug = UnityEngine.Debug;

namespace Components.Shooters
{
    public class CameraRotator : MonoBehaviour
    {
        [SerializeField] public int rotationSpeed = 10;
        [SerializeField] private Transform camera;

        [NonSerialized] private float _baseX;

        [NonSerialized] private float beforeFrameRotated = 0;
        [NonSerialized] private readonly Stopwatch _stopwatch = new Stopwatch();

        private void Start()
        {
            _baseX = Input.mousePosition.x;
        }

        private void Update()
        {
//            Debug.Log(Input.mousePosition.x - _baseX);
            gameObject.transform.Rotate(
                0, 0, -(Input.mousePosition.x - _baseX - beforeFrameRotated) / 100 * rotationSpeed);
            camera.rotation = gameObject.transform.rotation;
            
            beforeFrameRotated = Input.mousePosition.x - _baseX;

            if (Input.GetKeyDown(KeyCode.Q))
            {
                _baseX = Input.mousePosition.x;
            }

            _stopwatch.Restart();
        }
    }
}