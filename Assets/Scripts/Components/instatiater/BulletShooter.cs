using System;
using System.Diagnostics;
using Components.models;
using UnityEngine;

namespace Components.instatiater
{
    public class BulletShooter : MonoBehaviour
    {
        [NonSerialized] private readonly Stopwatch _stopwatch = new Stopwatch();
        [SerializeField] private Bullet bullet;
        [SerializeField] private long shotRangeMs;
        [SerializeField] private int speed;

        private float X => gameObject.transform.position.x;
        private float Y => gameObject.transform.position.y;

        private float RotationZ => gameObject.transform.rotation.eulerAngles.z;

        private bool IsShotAvailable => _stopwatch.ElapsedMilliseconds > shotRangeMs;

        private void Start()
        {
            _stopwatch.Start();
        }

        private void Update()
        {
            if (Input.GetMouseButton(0) && IsShotAvailable)
            {
                Shot();
                _stopwatch.Restart();
            }
            else if (IsShotAvailable)
            {
                _stopwatch.Stop();
            }
        }

        private void Shot()
        {
            var shotBullet = Instantiate(bullet);
            shotBullet.transform.position = new Vector3(X, Y, 1);
            shotBullet.speed = speed;
            shotBullet.RotationZ = RotationZ;
        }
    }
}