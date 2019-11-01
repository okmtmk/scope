using System;
using System.Diagnostics;
using UnityEngine;

namespace Components.Shooters
{
    public class PlayerShooter : MonoBehaviour
    {
        [SerializeField] private Bullet bullet;
        [SerializeField] public long shotRangeMs = 30;
        [SerializeField] public long bulletSpeed = 100;
        [NonSerialized] private readonly Stopwatch _stopwatch = new Stopwatch();

        private void Start()
        {
            _stopwatch.Start();
        }

        private void Update()
        {
            if (_stopwatch.ElapsedMilliseconds > shotRangeMs)
            {
                _stopwatch.Stop();
            }

            if (Input.GetMouseButton(0) && _stopwatch.ElapsedMilliseconds > shotRangeMs)
            {
                Shot();
                _stopwatch.Restart();
            }
        }

        private void Shot()
        {
            var shotBullet = Instantiate(bullet);
            var gameObjectPosition = gameObject.transform.position;
            shotBullet.transform.position =
                new Vector3(gameObjectPosition.x, gameObjectPosition.y, 1);
            shotBullet.Speed = bulletSpeed;
            shotBullet.transform.rotation = gameObject.transform.rotation;
            shotBullet.Radius = (gameObject.transform.eulerAngles.z + 90) * Mathf.Deg2Rad;
        }
    }
}