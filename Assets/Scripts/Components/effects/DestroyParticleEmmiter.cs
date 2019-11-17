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

        public void PlayEffect()
        {
            var obj = Instantiate(particle);
            obj.transform.position = gameObject.transform.position;
            obj.Play();
        }
    }
}