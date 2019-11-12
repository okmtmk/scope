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

        public override void Register(Dictionary<long, Action<LevelPlayer>> events)
        {
            SpawnGoStraightAndStopCube(events, 0, 20, 500);
            SpawnGoStraightAndStopCube(events, 6, 20, 2500);
            SpawnGoStraightAndStopCube(events, -6, 20, 4500);
            
            SpawnCurveRightCube(events, 16, 16, 6000, -45);
            SpawnCurveLeftCube(events, -16, 16, 8000, 45);
            
            SpawnGoStraightDia(events, 0, 20, 9500);
            SpawnGoStraightDia(events, 6, 20, 11500);
            SpawnGoStraightDia(events, -6, 20, 13500);
            
            SpawnGoStraightDia(events, 16, 16, 16000,-30);
            SpawnGoStraightDia(events, 16, 19, 17000,-30);
            
            SpawnGoStraightDia(events, -16, 16, 20000,30);
            SpawnGoStraightDia(events, -16, 19, 21000,30);
        }

        private void SpawnRow(
            Dictionary<long, Action<LevelPlayer>> spawnEvent,
            Enemy enemy,
            float baseX,
            float baseY,
            long baseMilliSecond,
            float rotationZ = 0)
        {
            spawnEvent.Add(baseMilliSecond, player =>
            {
                var x = baseX;
                var y = baseY;
                player.SpawnEnemy(enemy, x - 1.5f, y, rotationZ);
                player.SpawnEnemy(enemy, x, y, rotationZ);
                player.SpawnEnemy(enemy, x + 1.5f, y, rotationZ);
            });
        }

        private void SpawnGoStraightAndStopCube(
            Dictionary<long, Action<LevelPlayer>> spawnEvent,
            float baseX,
            float baseY,
            long baseMilliSecond,
            float rotationZ = 0)
        {
            SpawnRow(spawnEvent, goStraightAndStopEnemy, baseX, baseY, baseMilliSecond, rotationZ);
            SpawnRow(spawnEvent, goStraightAndStopEnemy, baseX, baseY + 1.5f, baseMilliSecond + 100, rotationZ);
            SpawnRow(spawnEvent, goStraightAndStopEnemy, baseX, baseY + 3, baseMilliSecond + 200, rotationZ);
        }

        private void SpawnCurveRightCube(
            Dictionary<long, Action<LevelPlayer>> events,
            float baseX,
            float baseY,
            long baseMilliSecond,
            float rotationZ = 0)
        {
            SpawnRow(events, curveRightEnemy, baseX, baseY, baseMilliSecond, rotationZ);
            SpawnRow(events, curveRightEnemy, baseX, baseY + 1.5f, baseMilliSecond + 100, rotationZ);
            SpawnRow(events, curveRightEnemy, baseX, baseY + 3, baseMilliSecond + 200, rotationZ);
        }

        private void SpawnCurveLeftCube(
            Dictionary<long, Action<LevelPlayer>> events,
            float baseX,
            float baseY,
            long baseMilliSecond,
            float rotationZ = 0)
        {
            SpawnRow(events, curveLeftEnemy, baseX, baseY, baseMilliSecond, rotationZ);
            SpawnRow(events, curveLeftEnemy, baseX, baseY + 1.5f, baseMilliSecond + 100, rotationZ);
            SpawnRow(events, curveLeftEnemy, baseX, baseY + 3, baseMilliSecond + 200, rotationZ);
        }

        private void SpawnGoStraightDia(
            Dictionary<long, Action<LevelPlayer>> events,
            float baseX,
            float baseY,
            long baseMilliSecond,
            float rotationZ = 0)
        {
            events.Add(baseMilliSecond, player =>
            {
                player.SpawnEnemy(
                    goStraightEnemy,
                    baseX,
                    baseY,
                    rotationZ
                );

                player.SpawnEnemy(
                    goStraightEnemy,
                    baseX + 1.5f,
                    baseY + 1.5f,
                    rotationZ
                );

                player.SpawnEnemy(
                    goStraightEnemy,
                    baseX - 1.5f,
                    baseY + 1.5f,
                    rotationZ
                );

                player.SpawnEnemy(
                    goStraightEnemy,
                    baseX,
                    baseY + 3,
                    rotationZ
                );

                player.SpawnEnemy(
                    goStraightEnemy,
                    baseX + 3f,
                    baseY + 3f,
                    rotationZ
                );

                player.SpawnEnemy(
                    goStraightEnemy,
                    baseX - 3f,
                    baseY + 3f,
                    rotationZ
                );

                player.SpawnEnemy(
                    goStraightEnemy,
                    baseX + 1.5f,
                    baseY + 4.5f,
                    rotationZ
                );

                player.SpawnEnemy(
                    goStraightEnemy,
                    baseX - 1.5f,
                    baseY + 4.5f,
                    rotationZ
                );

                player.SpawnEnemy(
                    goStraightEnemy,
                    baseX,
                    baseY + 6f,
                    rotationZ
                );
            });
        }
    }
}