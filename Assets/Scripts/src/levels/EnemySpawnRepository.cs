using System;
using System.Collections.Generic;
using Components.levels;
using Components.models;

namespace src.levels
{
    public class EnemySpawnRepository
    {
        private readonly Enemy _goStraightEnemy;
        private readonly Enemy _goStraightAndStopEnemy;
        private readonly Enemy _curveRightEnemy;
        private readonly Enemy _curveLeftEnemy;

        public EnemySpawnRepository(Enemy goStraightEnemy, Enemy goStraightAndStopEnemy, Enemy curveRightEnemy,
            Enemy curveLeftEnemy)
        {
            this._goStraightEnemy = goStraightEnemy;
            this._goStraightAndStopEnemy = goStraightAndStopEnemy;
            this._curveRightEnemy = curveRightEnemy;
            this._curveLeftEnemy = curveLeftEnemy;
        }

        public static void SpawnRow(
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

        public void SpawnGoStraightAndStopCube(
            Dictionary<long, Action<LevelPlayer>> spawnEvent,
            float baseX,
            float baseY,
            long baseMilliSecond,
            float rotationZ = 0)
        {
            SpawnRow(spawnEvent, _goStraightAndStopEnemy, baseX, baseY, baseMilliSecond, rotationZ);
            SpawnRow(spawnEvent, _goStraightAndStopEnemy, baseX, baseY + 1.5f, baseMilliSecond + 100, rotationZ);
            SpawnRow(spawnEvent, _goStraightAndStopEnemy, baseX, baseY + 3, baseMilliSecond + 200, rotationZ);
        }

        public void SpawnCurveRightCube(
            Dictionary<long, Action<LevelPlayer>> events,
            float baseX,
            float baseY,
            long baseMilliSecond,
            float rotationZ = 0)
        {
            SpawnRow(events, _curveRightEnemy, baseX, baseY, baseMilliSecond, rotationZ);
            SpawnRow(events, _curveRightEnemy, baseX, baseY + 1.5f, baseMilliSecond + 100, rotationZ);
            SpawnRow(events, _curveRightEnemy, baseX, baseY + 3, baseMilliSecond + 200, rotationZ);
        }

        public void SpawnCurveLeftCube(
            Dictionary<long, Action<LevelPlayer>> events,
            float baseX,
            float baseY,
            long baseMilliSecond,
            float rotationZ = 0)
        {
            SpawnRow(events, _curveLeftEnemy, baseX, baseY, baseMilliSecond, rotationZ);
            SpawnRow(events, _curveLeftEnemy, baseX, baseY + 1.5f, baseMilliSecond + 100, rotationZ);
            SpawnRow(events, _curveLeftEnemy, baseX, baseY + 3, baseMilliSecond + 200, rotationZ);
        }

        public void SpawnGoStraightDia(
            Dictionary<long, Action<LevelPlayer>> events,
            float baseX,
            float baseY,
            long baseMilliSecond,
            float rotationZ = 0)
        {
            events.Add(baseMilliSecond, player =>
            {
                player.SpawnEnemy(_goStraightEnemy, baseX, baseY, rotationZ);
                player.SpawnEnemy(_goStraightEnemy, baseX + 1.5f, baseY + 1.5f, rotationZ);
                player.SpawnEnemy(_goStraightEnemy, baseX - 1.5f, baseY + 1.5f, rotationZ);
                player.SpawnEnemy(_goStraightEnemy, baseX, baseY + 3, rotationZ);
                player.SpawnEnemy(_goStraightEnemy, baseX + 3f, baseY + 3f, rotationZ);
                player.SpawnEnemy(_goStraightEnemy, baseX - 3f, baseY + 3f, rotationZ);
                player.SpawnEnemy(_goStraightEnemy, baseX + 1.5f, baseY + 4.5f, rotationZ);
                player.SpawnEnemy(_goStraightEnemy, baseX - 1.5f, baseY + 4.5f, rotationZ);
                player.SpawnEnemy(_goStraightEnemy, baseX, baseY + 6f, rotationZ);
            });
        }

        public void SpawnVerticalLineAndCross(
            Dictionary<long, Action<LevelPlayer>> events,
            float baseX,
            float baseY,
            long baseMilliSecond,
            float rotationZ = 0
        )
        {
            events.Add(baseMilliSecond, it =>
            {
                it.SpawnEnemy(_curveLeftEnemy, baseX + 3f, baseY, rotationZ);
                it.SpawnEnemy(_curveRightEnemy, baseX - 3f, baseY, rotationZ);
            });

            events.Add(baseMilliSecond + 500, it =>
            {
                it.SpawnEnemy(_curveLeftEnemy, baseX + 3f, baseY, rotationZ);
                it.SpawnEnemy(_curveRightEnemy, baseX - 3f, baseY, rotationZ);
            });

            events.Add(baseMilliSecond + 1000, it =>
            {
                it.SpawnEnemy(_curveLeftEnemy, baseX + 3f, baseY, rotationZ);
                it.SpawnEnemy(_curveRightEnemy, baseX - 3f, baseY, rotationZ);
            });

            events.Add(baseMilliSecond + 1500, it =>
            {
                it.SpawnEnemy(_curveLeftEnemy, baseX + 3f, baseY, rotationZ);
                it.SpawnEnemy(_curveRightEnemy, baseX - 3f, baseY, rotationZ);
            });

            events.Add(baseMilliSecond + 2000, it =>
            {
                it.SpawnEnemy(_curveLeftEnemy, baseX + 3f, baseY, rotationZ);
                it.SpawnEnemy(_curveRightEnemy, baseX - 3f, baseY, rotationZ);
            });

            events.Add(baseMilliSecond + 2500, it =>
            {
                it.SpawnEnemy(_curveLeftEnemy, baseX + 3f, baseY, rotationZ);
                it.SpawnEnemy(_curveRightEnemy, baseX - 3f, baseY, rotationZ);
            });
        }
    }
}