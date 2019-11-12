using System;
using System.Collections.Generic;
using UnityEngine;

namespace Components.levels
{
    public abstract class Level : MonoBehaviour
    {
        public abstract void Register(Dictionary<long, Action<LevelPlayer>> events);
    }
}