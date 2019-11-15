using System;
using Components.levels;
using UnityEngine;
using UnityEngine.UI;

namespace Components.utilities
{
    public class ResultViewer : MonoBehaviour
    {
        [SerializeField] private Text resultText;
        [SerializeField] private ScoreCounter counter;

        [NonSerialized] private new Animation _animation;

        private void Start()
        {
            _animation = GetComponent<Animation>();
        }

        public void ShowResult()
        {
            _animation.Play();
            resultText.text
                = $"スコア\t{counter.Score}\n" +
                  $"倒した数\t{counter.DestroyedEnemies}/{counter.SpawnedEnemies}" +
                  $"({(float) counter.DestroyedEnemies / counter.SpawnedEnemies * 100:#0.0}%)\n" +
                  $"命中率\t{(float) counter.HitBullets / counter.ShotBullets * 100:#0.0}%" +
                  $"({counter.HitBullets}/{counter.ShotBullets})";
        }
    }
}