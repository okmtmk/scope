using System;
using Components.levels;
using UnityEngine;
using UnityEngine.UI;

namespace Components.utilities
{
    public class CounterViewer : MonoBehaviour
    {
        [SerializeField] private ScoreCounter counter;
        [SerializeField] private Text viewer;

        private void Update()
        {
            viewer.text = counter.ToString();
        }
    }
}