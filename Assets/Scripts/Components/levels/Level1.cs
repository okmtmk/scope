using System;
using System.Collections.Generic;
using Components.models;
using UnityEngine;

namespace Components.levels
{
    public class Level1 : Level
    {
        [SerializeField] private Enemy goStraightAndStopEnemy;

        public override void Register(Dictionary<long, Action<LevelPlayer>> spawnEvent)
        {
            spawnEvent.Add(0, player =>
            {
                player.SpawnEnemy(goStraightAndStopEnemy,
                    -1, 30, 0);
                player.SpawnEnemy(goStraightAndStopEnemy,
                    -3, 30, 0);
                player.SpawnEnemy(goStraightAndStopEnemy,
                    1, 30, 0);
                player.SpawnEnemy(goStraightAndStopEnemy,
                    3, 30, 0);

                player.SpawnEnemy(goStraightAndStopEnemy,
                    -1, 32, 0);
                player.SpawnEnemy(goStraightAndStopEnemy,
                    -3, 32, 0);
                player.SpawnEnemy(goStraightAndStopEnemy,
                    1, 32, 0);
                player.SpawnEnemy(goStraightAndStopEnemy,
                    3, 32, 0);

                player.SpawnEnemy(goStraightAndStopEnemy,
                    -3, 34, 0);
                player.SpawnEnemy(goStraightAndStopEnemy,
                    -1, 34, 0);
                player.SpawnEnemy(goStraightAndStopEnemy,
                    1, 34, 0);
                player.SpawnEnemy(goStraightAndStopEnemy,
                    3, 34, 0);

                player.SpawnEnemy(goStraightAndStopEnemy,
                    -3, 36, 0);
                player.SpawnEnemy(goStraightAndStopEnemy,
                    -1, 36, 0);
                player.SpawnEnemy(goStraightAndStopEnemy,
                    1, 36, 0);
                player.SpawnEnemy(goStraightAndStopEnemy,
                    3, 36, 0);
            });

            spawnEvent.Add(2000, player =>
            {
                player.SpawnEnemy(goStraightAndStopEnemy,
                    -7, 30, 0);
                player.SpawnEnemy(goStraightAndStopEnemy,
                    -5, 30, 0);
                player.SpawnEnemy(goStraightAndStopEnemy,
                    5, 30, 0);
                player.SpawnEnemy(goStraightAndStopEnemy,
                    7, 30, 0);

                player.SpawnEnemy(goStraightAndStopEnemy,
                    -7, 32, 0);
                player.SpawnEnemy(goStraightAndStopEnemy,
                    -5, 32, 0);
                player.SpawnEnemy(goStraightAndStopEnemy,
                    5, 32, 0);
                player.SpawnEnemy(goStraightAndStopEnemy,
                    7, 32, 0);

                player.SpawnEnemy(goStraightAndStopEnemy,
                    -7, 34, 0);
                player.SpawnEnemy(goStraightAndStopEnemy,
                    -5, 34, 0);
                player.SpawnEnemy(goStraightAndStopEnemy,
                    7, 34, 0);
                player.SpawnEnemy(goStraightAndStopEnemy,
                    5, 34, 0);

                player.SpawnEnemy(goStraightAndStopEnemy,
                    -7, 36, 0);
                player.SpawnEnemy(goStraightAndStopEnemy,
                    -5, 36, 0);
                player.SpawnEnemy(goStraightAndStopEnemy,
                    5, 36, 0);
                player.SpawnEnemy(goStraightAndStopEnemy,
                    7, 36, 0);
            });
        }
    }
}