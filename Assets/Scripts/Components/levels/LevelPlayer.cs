using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Components.models;
using UnityEngine;

namespace Components.levels
{
    public class LevelPlayer : MonoBehaviour
    {
        [SerializeField] private Level level;
        [SerializeField] private ScoreCounter counter;

        [NonSerialized] private readonly Dictionary<long, Action<LevelPlayer>> _spawnEvents
            = new Dictionary<long, Action<LevelPlayer>>();

        [NonSerialized] private readonly Stopwatch _stopwatch = new Stopwatch();
        [NonSerialized] private readonly List<long> _spawned = new List<long>();

        private void Start()
        {
            level.Register(_spawnEvents);
        }

        private void Update()
        {
            foreach (var it in _spawnEvents.Where(it =>
                it.Key < _stopwatch.ElapsedMilliseconds && !_spawned.Contains(it.Key)))
            {
                it.Value(this);
                _spawned.Add(it.Key);
            }
        }

        public Enemy SpawnEnemy(Enemy enemy, float x, float y, float rotationZ)
        {
            var obj = Instantiate(enemy);
            obj.transform.position = new Vector3(x, y, -1);
            obj.transform.rotation = Quaternion.Euler(0, 0, rotationZ);
            obj.counter = counter;

            counter.SpawnedEnemies++;

            return obj;
        }

        public void PlayLevel()
        {
            _stopwatch.Start();
        }

        public void StopLevel()
        {
            _stopwatch.Stop();
        }
    }
}