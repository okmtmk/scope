using System;
using UnityEngine;

namespace Components.rotations
{
    public class RotationDisplayer : MonoBehaviour
    {
        [SerializeField] private MouseInputRotator rotator;
        [SerializeField] private TextMesh textMesh;

        private void Update()
        {
            textMesh.text = $"{Math.Abs(rotator.InnerRotationZ):#00.0}";
        }
    }
}