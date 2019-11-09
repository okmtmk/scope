using System;
using UnityEngine;

namespace Components.rotations
{
    public class RotationZLinker : MouseInputRotator
    {
        [SerializeField] private MouseInputRotator rotator;
        [SerializeField] private bool isFix;

        protected override void Update()
        {
            if (isFix)
            {
                RotationZ = 0;
            }
            else
            {
                RotationZ = rotator.OuterRotationZ;
            }
        }
    }
}