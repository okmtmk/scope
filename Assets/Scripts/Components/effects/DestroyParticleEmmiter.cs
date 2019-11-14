using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Components.effects
{
    public class DestroyParticleEmmiter : MonoBehaviour
    {
        [SerializeField] private ParticleSystem particle;

        private void OnDestroy()
        {
            var obj = Instantiate(particle);
            obj.transform.position = gameObject.transform.position;
            obj.Play();
        }
    }
}