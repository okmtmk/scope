using System;
using System.Diagnostics;
using UnityEngine;

namespace Components.utilities
{
    public class SelfKiller : MonoBehaviour
    {
        [SerializeField] private long killMilliSecond = 1000;
        [NonSerialized] private readonly Stopwatch _stopwatch = new Stopwatch();

        private void Start()
        {
            _stopwatch.Start();
        }

        private void Update()
        {
            if (_stopwatch.ElapsedMilliseconds > killMilliSecond)
            {
                Destroy(gameObject);
            }
        }
    }
}