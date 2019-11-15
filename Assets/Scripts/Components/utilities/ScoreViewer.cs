using System;
using Components.levels;
using Components.models;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.UI;

namespace Components.utilities
{
    public class ScoreViewer : MonoBehaviour
    {
        [SerializeField] private ScoreCounter counter;
        [SerializeField] private Text scoreView;
        [NonSerialized] private long _beforeFrameScore;

        private long Score => counter.Score;

        private void Start()
        {
            scoreView.text = $"{Score:000000}";
        }

        private void Update()
        {
            if (Score != _beforeFrameScore)
            {
                _beforeFrameScore = Score;
                scoreView.text = $"{Score:000000}";
            }
        }
    }
}