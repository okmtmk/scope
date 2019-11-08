using System;
using System.Diagnostics;
using src.collisions;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Components.Shooters
{
    public class PlayerShooter : CollidableBehaviour
    {
        [SerializeField] private Bullet bullet;
        [SerializeField] public long shotRangeMs = 30;
        [SerializeField] public long bulletSpeed = 100;

        [NonSerialized] private readonly Stopwatch _stopwatch = new Stopwatch();

        protected override void Start()
        {
            base.Start();

            sceneModel.Register(this);
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
            shotBullet.sceneModel = sceneModel;

            sceneModel.Register(shotBullet);
        }

        public override void OnCollide(ICollidable collidable)
        {
            if (collidable is Enemy)
            {
                Debug.Log("当たった");
            }
        }

        public override void OnEnterCollider(ICollidable collidable)
        {
            base.OnEnterCollider(collidable);

            if (collidable is Enemy)
            {
                Debug.Log("初回当たり判定");
            }
        }

        public override void OnExitCollider(ICollidable collidable)
        {
            base.OnExitCollider(collidable);

            if (collidable is Enemy)
            {
                Debug.Log("最後の当たり判定");
            }
        }
    }
}