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
        [NonSerialized] private bool _isDamaged;

        private bool IsDamaged
        {
            get => _isDamaged;
            set
            {
                _isDamaged = value;

                if (_isDamaged)
                {
                    OnDamaged();
                }
                else
                {
                    OnNonDamaged();
                }
            }
        }

        private void Start()
        {
            _animation = GetComponent<Animation>();
        }

        private void Update()
        {
            if (_stopwatch.ElapsedMilliseconds > 5000)
            {
                IsDamaged = false;
            }
        }

        public void OnEnterCollider(SpriteCollider2D other)
        {
            if (other.gameObject.CompareTag("Enemy") && !IsDamaged)
            {
                var obj = Instantiate(damagedParticle);
                obj.transform.position = gameObject.transform.position;
                IsDamaged = true;
            }
        }

        private void OnDamaged()
        {
            Debug.Log("ダメージを受けた");
            _stopwatch.Reset();
            _stopwatch.Start();

            _animation.wrapMode = WrapMode.Loop;
            _animation.Play();
        }

        private void OnNonDamaged()
        {
            Debug.Log("ダメージが消えた");
            _animation.wrapMode = WrapMode.Once;
//            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);

            _stopwatch.Stop();
            _stopwatch.Reset();
        }
    }
}