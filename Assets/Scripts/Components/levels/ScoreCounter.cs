using System;
using UnityEngine;

namespace Components.levels
{
    public class ScoreCounter : MonoBehaviour
    {
        [NonSerialized] public long Score = 0;

        [NonSerialized] public float ScoreRate = 0;
        [NonSerialized] public float ActiveScoreRate = 0;

        [NonSerialized] public long SpawnedEnemies = 0;
        [NonSerialized] public long DestroyedEnemies = 0;

        [NonSerialized] public long ShotBullets = 0;
        [NonSerialized] public long HitBullets = 0;

        public override string ToString()
        {
            return "ScoreCounter : {\n" +
                   $"\tScore : {Score}\n" +
                   $"\tScoreRate : {ScoreRate}\n" +
                   $"\tActiveScoreRate : {ActiveScoreRate}\n" +
                   $"\tSpawnedEnemies : {SpawnedEnemies}\n" +
                   $"\tDestroyedEnemies : {DestroyedEnemies}\n" +
                   $"\tShotBullets : {ShotBullets}\n" +
                   $"\tHitBullets : {HitBullets}\n" +
                   "}";
        }
    }
}