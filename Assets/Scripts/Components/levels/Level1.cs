using System;
using System.Collections.Generic;
using Components.models;
using UnityEngine;

namespace Components.levels
{
    public class Level1 : Level
    {
        [SerializeField] private Enemy goStraightEnemy;
        [SerializeField] private Enemy goStraightAndStopEnemy;
        [SerializeField] private Enemy curveRightEnemy;
        [SerializeField] private Enemy curveLeftEnemy;

        public override void Register(Dictionary<long, Action<LevelPlayer>> spawnEvent)
        {
            spawnEvent.Add(1000, player =>
            {
                const float num = 0f;
                const float y = 30f;
                player.SpawnEnemy(goStraightAndStopEnemy,
                    num - 1.5f, y, 0);
                player.SpawnEnemy(goStraightAndStopEnemy,
                    num, y, 0);
                player.SpawnEnemy(goStraightAndStopEnemy,
                    num + 1.5f, y, 0);
            });

            spawnEvent.Add(1100, player =>
            {
                const float num = 0f;
                const float y = 31.5f;
                player.SpawnEnemy(goStraightAndStopEnemy,
                    num - 1.5f, y, 0);
                player.SpawnEnemy(goStraightAndStopEnemy,
                    num, y, 0);
                player.SpawnEnemy(goStraightAndStopEnemy,
                    num + 1.5f, y, 0);
            });

            spawnEvent.Add(1200, player =>
            {
                const float num = 0f;
                const float y = 33f;
                player.SpawnEnemy(goStraightAndStopEnemy,
                    num - 1.5f, y, 0);
                player.SpawnEnemy(goStraightAndStopEnemy,
                    num, y, 0);
                player.SpawnEnemy(goStraightAndStopEnemy,
                    num + 1.5f, y, 0);
            });


            spawnEvent.Add(3200, player =>
            {
                const float num = 3f;
                const float y = 30f;
                player.SpawnEnemy(goStraightAndStopEnemy,
                    num - 1.5f, y, 0);
                player.SpawnEnemy(goStraightAndStopEnemy,
                    num, y, 0);
                player.SpawnEnemy(goStraightAndStopEnemy,
                    num + 1.5f, y, 0);
            });

            spawnEvent.Add(3300, player =>
            {
                const float num = 3f;
                const float y = 31.5f;
                player.SpawnEnemy(goStraightAndStopEnemy,
                    num - 1.5f, y, 0);
                player.SpawnEnemy(goStraightAndStopEnemy,
                    num, y, 0);
                player.SpawnEnemy(goStraightAndStopEnemy,
                    num + 1.5f, y, 0);
            });

            spawnEvent.Add(3400, player =>
            {
                const float num = 3f;
                const float y = 33f;
                player.SpawnEnemy(goStraightAndStopEnemy,
                    num - 1.5f, y, 0);
                player.SpawnEnemy(goStraightAndStopEnemy,
                    num, y, 0);
                player.SpawnEnemy(goStraightAndStopEnemy,
                    num + 1.5f, y, 0);
            });


            spawnEvent.Add(5400, player =>
            {
                const float num = -3f;
                const float y = 30f;
                player.SpawnEnemy(goStraightAndStopEnemy,
                    num - 1.5f, y, 0);
                player.SpawnEnemy(goStraightAndStopEnemy,
                    num, y, 0);
                player.SpawnEnemy(goStraightAndStopEnemy,
                    num + 1.5f, y, 0);
            });

            spawnEvent.Add(5500, player =>
            {
                const float num = -3f;
                const float y = 31.5f;
                player.SpawnEnemy(goStraightAndStopEnemy,
                    num - 1.5f, y, 0);
                player.SpawnEnemy(goStraightAndStopEnemy,
                    num, y, 0);
                player.SpawnEnemy(goStraightAndStopEnemy,
                    num + 1.5f, y, 0);
            });

            spawnEvent.Add(5600, player =>
            {
                const float num = -3f;
                const float y = 33f;
                player.SpawnEnemy(goStraightAndStopEnemy,
                    num - 1.5f, y, 0);
                player.SpawnEnemy(goStraightAndStopEnemy,
                    num, y, 0);
                player.SpawnEnemy(goStraightAndStopEnemy,
                    num + 1.5f, y, 0);
            });

            spawnEvent.Add(7600, player =>
            {
                const float num = 15f;
                const float y = 25f;
                player.SpawnEnemy(curveRightEnemy,
                    num - 1.5f, y, -30);
                player.SpawnEnemy(curveRightEnemy,
                    num, y, -30);
                player.SpawnEnemy(curveRightEnemy,
                    num + 1.5f, y, -30);
            });
            spawnEvent.Add(7700, player =>
            {
                const float num = 15f;
                const float y = 26.5f;
                player.SpawnEnemy(curveRightEnemy,
                    num - 1.5f, y, -30);
                player.SpawnEnemy(curveRightEnemy,
                    num, y, -30);
                player.SpawnEnemy(curveRightEnemy,
                    num + 1.5f, y, -30);
            });
            spawnEvent.Add(7800, player =>
            {
                const float num = 15f;
                const float y = 28f;
                player.SpawnEnemy(curveRightEnemy,
                    num - 1.5f, y, -30);
                player.SpawnEnemy(curveRightEnemy,
                    num, y, -30);
                player.SpawnEnemy(curveRightEnemy,
                    num + 1.5f, y, -30);
            });


            spawnEvent.Add(9800, player =>
            {
                const float x = -15f;
                const float y = 25f;
                player.SpawnEnemy(curveLeftEnemy,
                    x - 1.5f, y, 30);
                player.SpawnEnemy(curveLeftEnemy,
                    x, y, 30);
                player.SpawnEnemy(curveLeftEnemy,
                    x + 1.5f, y, 30);
            });
            spawnEvent.Add(9900, player =>
            {
                const float x = -15f;
                const float y = 26.5f;
                player.SpawnEnemy(curveLeftEnemy,
                    x - 1.5f, y, 30);
                player.SpawnEnemy(curveLeftEnemy,
                    x, y, 30);
                player.SpawnEnemy(curveLeftEnemy,
                    x + 1.5f, y, 30);
            });
            spawnEvent.Add(10000, player =>
            {
                const float x = -15f;
                const float y = 28f;
                player.SpawnEnemy(curveLeftEnemy,
                    x - 1.5f, y, 30);
                player.SpawnEnemy(curveLeftEnemy,
                    x, y, 30);
                player.SpawnEnemy(curveLeftEnemy,
                    x + 1.5f, y, 30);
            });
        }
    }
}