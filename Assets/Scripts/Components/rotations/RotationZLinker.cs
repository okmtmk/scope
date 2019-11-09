using System;
using UnityEngine;

namespace Components.rotations
{
    public class RotationZLinker : MouseInputRotator
    {
        [SerializeField] private MouseInputRotator rotator;
        
        protected override void Update()
        {
            RotationZ = rotator.Angle;
        }
    }
}