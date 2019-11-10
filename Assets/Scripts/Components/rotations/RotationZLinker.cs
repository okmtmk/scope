using UnityEngine;

namespace Components.rotations
{
    public class RotationZLinker : MouseInputRotator
    {
        [SerializeField] private bool isFix;
        [SerializeField] private MouseInputRotator rotator;

        protected override void Update()
        {
            if (isFix)
                RotationZ = 0;
            else
                RotationZ = rotator.OuterRotationZ;
        }
    }
}