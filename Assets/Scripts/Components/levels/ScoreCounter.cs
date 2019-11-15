using System;
using UnityEngine;

namespace Components.levels
{
    public class ScoreCounter : MonoBehaviour
    {
        [NonSerialized] public long Score;

        [NonSerialized] public float ScoreRate;
        [NonSerialized] public float ActiveScoreRate;

        [NonSerialized] public long SpawnedEnemies;
        [NonSerialized] public long DestroyedEnemies;

        [NonSerialized] public long ShotBullets;
        [NonSerialized] public long HitBullets;
    }
}