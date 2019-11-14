using System;
using System.Collections.Generic;
using Components.models;
using src.levels;
using UnityEngine;

namespace Components.levels
{
    public class Level1 : Level
    {
        public override void Register(Dictionary<long, Action<LevelPlayer>> events)
        {
            /*
             * 1パート目
             */
            const int firstPart = 0;

            _repository.SpawnCurveRightCube(events, 16, 16, firstPart + 1000, -45);
            _repository.SpawnCurveLeftCube(events, -16, 16, firstPart + 2000, 45);

            _repository.SpawnCurveRightCube(events, 18f, 14, firstPart + 5000, -45);
            _repository.SpawnCurveLeftCube(events, -18f, 14, firstPart + 7000, 45);

            _repository.SpawnCurveRightCube(events, 16, 16, firstPart + 10000, -45);
            _repository.SpawnCurveRightCube(events, 3, 16, firstPart + 12000, -15);

            _repository.SpawnCurveLeftCube(events, -16, 16, firstPart + 15000, 45);
            _repository.SpawnCurveLeftCube(events, -3, 16, firstPart + 17000, 15);

            _repository.SpawnVerticalLineAndCross(events, 0, 20, firstPart + 20000);
            _repository.SpawnVerticalLineAndCross(events, 16, 16, firstPart + 24000, -30);
            _repository.SpawnVerticalLineAndCross(events, -16, 16, firstPart + 28000, 30);


            /*
             * 2パート目
             */
            const int secondPart = 33000;
            _repository.SpawnGoStraightAndStopCube(events, 0, 20, secondPart + 1000);
            _repository.SpawnGoStraightAndStopCube(events, 7.5f, 16, secondPart + 3000);
            _repository.SpawnGoStraightAndStopCube(events, -7.5f, 16, secondPart + 5000);

            _repository.SpawnGoStraightAndStopCube(events, 16, 16, secondPart + 7000, -30);
            _repository.SpawnGoStraightAndStopCube(events, 7.5f, 15, secondPart + 9000, -45);

            _repository.SpawnGoStraightAndStopCube(events, -16, 16, secondPart + 11000, 30);
            _repository.SpawnGoStraightAndStopCube(events, -7.5f, 15, secondPart + 13000, 45);

            _repository.SpawnGoStraightAndStopCube(events, 7.5f, 16, secondPart + 15000);
            _repository.SpawnGoStraightAndStopCube(events, -16, 16, secondPart + 16000, 30);

            _repository.SpawnGoStraightAndStopCube(events, -7.5f, 16, secondPart + 19000);
            _repository.SpawnGoStraightAndStopCube(events, 16, 16, secondPart + 20000, -30);

            _repository.SpawnGoStraightAndStopCube(events, -7.5f, 16, secondPart + 23000);
            _repository.SpawnGoStraightAndStopCube(events, 0f, 16, secondPart + 25000);
            _repository.SpawnGoStraightAndStopCube(events, 7.5f, 16, secondPart + 27000);

            _repository.SpawnGoStraightAndStopCube(events, 7.5f, 16, secondPart + 30000);
            _repository.SpawnGoStraightAndStopCube(events, 0f, 16, secondPart + 32000);
            _repository.SpawnGoStraightAndStopCube(events, -7.5f, 16, secondPart + 34000);
        }
    }
}