using System;
using System.Diagnostics;
using Components.simpleColliders;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Components.effects
{
    public class PlayerEffect : MonoBehaviour
    {
        [SerializeField] private ParticleSystem damagedParticle;
        [NonSerialized] private Animation _animation;
        [NonSerialized] private Stopwatch _stopwatch = new Stopwatch();

        private void Start()
        {
            _animation = GetComponent<Animation>();
        }

        public void PlayEffect()
        {
            Debug.Log("ダメージを受けた");
            _stopwatch.Reset();
            _stopwatch.Start();

            _animation.wrapMode = WrapMode.Loop;
            _animation.Play();
        }

        public void StopEffect()
        {
            Debug.Log("ダメージが消えた");
            _animation.wrapMode = WrapMode.Once;

            _stopwatch.Stop();
            _stopwatch.Reset();
        }

        public void PlayDamageEffect()
        {
            var obj = Instantiate(damagedParticle);
            obj.transform.position = gameObject.transform.position;
        }
    }
}