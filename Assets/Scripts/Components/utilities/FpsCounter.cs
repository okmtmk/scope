using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

namespace Components.utilities
{
    public class FpsCounter : MonoBehaviour
    {
        [NonSerialized] private readonly Stopwatch _stopwatch = new Stopwatch();
        [SerializeField] private Text text;

        private double Fps => 1f / (_stopwatch.ElapsedMilliseconds / 1000f);

        private void Start()
        {
            _stopwatch.Start();
        }

        private void Update()
        {
            if (text != null)
                text.text = $"{Fps:#,0.00} , {_stopwatch.ElapsedMilliseconds / 1000f}";
            else
                Debug.Log("{Fps:#,0.00} , {_stopwatch.ElapsedMilliseconds / 1000f}");

            _stopwatch.Restart();
        }
    }
}