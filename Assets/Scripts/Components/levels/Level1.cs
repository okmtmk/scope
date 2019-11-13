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

//            _repository.SpawnGoStraightAndStopCube(events, 0, 20, 1000);
//            _repository.SpawnGoStraightAndStopCube(events, 7.5f, 16, 3000);
//            _repository.SpawnGoStraightAndStopCube(events, -7.5f, 16, 5000);
//
//            _repository.SpawnGoStraightAndStopCube(events, 16, 16, 7000, -30);
//            _repository.SpawnGoStraightAndStopCube(events, 7.5f, 15, 9000, -45);
//
//            _repository.SpawnGoStraightAndStopCube(events, -16, 16, 11000, 30);
//            _repository.SpawnGoStraightAndStopCube(events, -7.5f, 15, 13000, 45);
//
//            _repository.SpawnGoStraightAndStopCube(events, 7.5f, 16, 15000);
//            _repository.SpawnGoStraightAndStopCube(events, -16, 16, 16000, 30);
//
//            _repository.SpawnGoStraightAndStopCube(events, -7.5f, 16, 19000);
//            _repository.SpawnGoStraightAndStopCube(events, 16, 16, 20000, -30);
//            
//            _repository.SpawnGoStraightAndStopCube(events, -7.5f, 16, 23000);
//            _repository.SpawnGoStraightAndStopCube(events, 0f, 16, 25000);
//            _repository.SpawnGoStraightAndStopCube(events, 7.5f, 16, 27000);
//            
//            _repository.SpawnGoStraightAndStopCube(events, 7.5f, 16, 30000);
//            _repository.SpawnGoStraightAndStopCube(events, 0f, 16, 32000);
//            _repository.SpawnGoStraightAndStopCube(events, -7.5f, 16, 34000);

            /*
             * 2パート目
             */
            const int secondBase = 0; //38000;

            _repository.SpawnCurveRightCube(events, 16, 16, secondBase + 1000, -45);
            _repository.SpawnCurveLeftCube(events, -16, 16, secondBase + 2000, 45);

            _repository.SpawnCurveRightCube(events, 18f, 14, secondBase + 5000, -45);
            _repository.SpawnCurveLeftCube(events, -18f, 14, secondBase + 7000, 45);

            _repository.SpawnCurveRightCube(events, 16, 16, secondBase + 10000, -45);
            _repository.SpawnCurveRightCube(events, 3, 16, secondBase + 12000, -15);

            _repository.SpawnCurveLeftCube(events, -16, 16, secondBase + 15000, 45);
            _repository.SpawnCurveLeftCube(events, -3, 16, secondBase + 17000, 15);
            
            _repository.SpawnVerticalLineAndCross(events, 0, 20, secondBase + 20000);
            _repository.SpawnVerticalLineAndCross(events, 16, 16, secondBase + 24000, -30);
            _repository.SpawnVerticalLineAndCross(events, -16, 16, secondBase + 28000, 30);
//
//            _repository.SpawnGoStraightDia(events, 0, 20, 11000);
//            _repository.SpawnGoStraightDia(events, 6, 20, 14000);
//            _repository.SpawnGoStraightDia(events, -6, 20, 17000);
//
//            _repository.SpawnGoStraightDia(events, 16, 16, 21000, -30);
//            _repository.SpawnGoStraightDia(events, 16, 19, 24000, -30);
//
//            _repository.SpawnGoStraightDia(events, -16, 16, 27000, 30);
//            _repository.SpawnGoStraightDia(events, -16, 19, 30000, 30);
        }
    }
}