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
            _repository.SpawnGoStraightAndStopCube(events, 0, 20, 1000);
            _repository.SpawnGoStraightAndStopCube(events, 6, 20, 3000);
            _repository.SpawnGoStraightAndStopCube(events, -6, 20, 5000);

            _repository.SpawnCurveRightCube(events, 16, 16, 7000, -45);
            _repository.SpawnCurveLeftCube(events, -16, 16, 9000, 45);

            _repository.SpawnGoStraightDia(events, 0, 20, 11000);
            _repository.SpawnGoStraightDia(events, 6, 20, 14000);
            _repository.SpawnGoStraightDia(events, -6, 20, 17000);

            _repository.SpawnGoStraightDia(events, 16, 16, 21000, -30);
            _repository.SpawnGoStraightDia(events, 16, 19, 24000, -30);

            _repository.SpawnGoStraightDia(events, -16, 16, 27000, 30);
            _repository.SpawnGoStraightDia(events, -16, 19, 30000, 30);

            _repository.SpawnVerticalLineAndCross(events, 0, 20, 33000);
            _repository.SpawnVerticalLineAndCross(events, 16, 16, 37000, -30);
            _repository.SpawnVerticalLineAndCross(events, -16, 16, 41000, 30);
        }
    }
}