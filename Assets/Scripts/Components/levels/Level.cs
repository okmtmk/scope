using System;
using System.Collections.Generic;
using Components.models;
using src.levels;
using UnityEngine;

namespace Components.levels
{
    public abstract class Level : MonoBehaviour
    {
        [SerializeField] private Enemy goStraightEnemy;
        [SerializeField] private Enemy goStraightAndStopEnemy;
        [SerializeField] private Enemy curveRightEnemy;
        [SerializeField] private Enemy curveLeftEnemy;

        [NonSerialized] protected EnemySpawnRepository _repository;
        public abstract void Register(Dictionary<long, Action<LevelPlayer>> events);

        private void Start()
        {
            _repository
                = new EnemySpawnRepository(goStraightEnemy, goStraightAndStopEnemy, curveRightEnemy, curveLeftEnemy);
        }
    }
}