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
        [SerializeField] private SceneLoader loader;

        public void ShowResult()
        {
            loader.isChangeable = true;
            resultText.text
                = $"スコア\t{counter.Score}\n" +
                  $"倒した数\t{counter.DestroyedEnemies}/{counter.SpawnedEnemies}" +
                  $"({(float) counter.DestroyedEnemies / counter.SpawnedEnemies * 100:#0.0}%)\n" +
                  $"命中率\t{(float) counter.HitBullets / counter.ShotBullets * 100:#0.0}%" +
                  $"({counter.HitBullets}/{counter.ShotBullets})";
        }
    }
}