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
            SpawnGoStraightAndStopCube(events, 0, 20, 1000);
            SpawnGoStraightAndStopCube(events, 6, 20, 3000);
            SpawnGoStraightAndStopCube(events, -6, 20, 5000);

            SpawnCurveRightCube(events, 16, 16, 7000, -45);
            SpawnCurveLeftCube(events, -16, 16, 9000, 45);

            SpawnGoStraightDia(events, 0, 20, 11000);
            SpawnGoStraightDia(events, 6, 20, 14000);
            SpawnGoStraightDia(events, -6, 20, 17000);

            SpawnGoStraightDia(events, 16, 16, 21000, -30);
            SpawnGoStraightDia(events, 16, 19, 24000, -30);

            SpawnGoStraightDia(events, -16, 16, 27000, 30);
            SpawnGoStraightDia(events, -16, 19, 30000, 30);

            SpawnVerticalLineAndCurve(events, 0, 20, 33000);
            SpawnVerticalLineAndCurve(events, 3, 16, 37000);
            SpawnVerticalLineAndCurve(events, -3, 16, 41000);
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

        private void SpawnVerticalLineAndCurve(
            Dictionary<long, Action<LevelPlayer>> events,
            float baseX,
            float baseY,
            long baseMilliSecond,
            float rotationZ = 0
        )
        {
            events.Add(baseMilliSecond, it =>
            {
                it.SpawnEnemy(
                    curveLeftEnemy,
                    baseX + 3f,
                    baseY,
                    rotationZ);

                it.SpawnEnemy(
                    curveRightEnemy,
                    baseX - 3f,
                    baseY,
                    rotationZ);
            });

            events.Add(baseMilliSecond + 500, it =>
            {
                it.SpawnEnemy(
                    curveLeftEnemy,
                    baseX + 3f,
                    baseY,
                    rotationZ);

                it.SpawnEnemy(
                    curveRightEnemy,
                    baseX - 3f,
                    baseY,
                    rotationZ);
            });

            events.Add(baseMilliSecond + 1000, it =>
            {
                it.SpawnEnemy(
                    curveLeftEnemy,
                    baseX + 3f,
                    baseY,
                    rotationZ);

                it.SpawnEnemy(
                    curveRightEnemy,
                    baseX - 3f,
                    baseY,
                    rotationZ);
            });

            events.Add(baseMilliSecond + 1500, it =>
            {
                it.SpawnEnemy(
                    curveLeftEnemy,
                    baseX + 3f,
                    baseY,
                    rotationZ);

                it.SpawnEnemy(
                    curveRightEnemy,
                    baseX - 3f,
                    baseY,
                    rotationZ);
            });

            events.Add(baseMilliSecond + 2000, it =>
            {
                it.SpawnEnemy(
                    curveLeftEnemy,
                    baseX + 3f,
                    baseY,
                    rotationZ);

                it.SpawnEnemy(
                    curveRightEnemy,
                    baseX - 3f,
                    baseY,
                    rotationZ);
            });

            events.Add(baseMilliSecond + 2500, it =>
            {
                it.SpawnEnemy(
                    curveLeftEnemy,
                    baseX + 3f,
                    baseY,
                    rotationZ);

                it.SpawnEnemy(
                    curveRightEnemy,
                    baseX - 3f,
                    baseY,
                    rotationZ);
            });
        }
    }
}