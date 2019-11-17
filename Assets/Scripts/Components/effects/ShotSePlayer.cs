using System;
using System.Diagnostics;
using UnityEngine;

namespace Components.effects
{
    public class ShotSePlayer : MonoBehaviour
    {
        [SerializeField] private long playRangeMilliSecond = 80;
        [NonSerialized] private AudioSource _audioSource;
        [NonSerialized] private readonly Stopwatch _stopwatch = new Stopwatch();

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.loop = false;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _stopwatch.Start();
            }

            if (Input.GetMouseButtonUp(0))
            {
                _stopwatch.Stop();
            }

            if (Input.GetMouseButton(0) && _stopwatch.ElapsedMilliseconds > playRangeMilliSecond)
            {
                _audioSource.Stop();
                _audioSource.time = 0.15f;
                _audioSource.Play();

                _stopwatch.Restart();
            }
        }
    }
}