using System.Collections.Generic;
using UnityEngine;

namespace Components.rotations
{
    public class RotationErrorSpriteColorChanger : MonoBehaviour
    {
        [SerializeField] private Color error;
        [SerializeField] private Color normal;
        [SerializeField] private MouseInputRotator rotator;
        [SerializeField] private List<SpriteRenderer> stateSprites = new List<SpriteRenderer>();

        private void Update()
        {
            if (rotator.IsInRange)
                stateSprites.ForEach(it => { it.color = normal; });
            else
                stateSprites.ForEach(it => { it.color = error; });
        }
    }
}