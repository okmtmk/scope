using System;
using src.collisions;
using UnityEngine;

namespace Components.Shooters
{
    public class Enemy : CollidableBehaviour
    {
        [NonSerialized] private SpriteRenderer _spriteRenderer;
        
        public override void OnCollide(ICollidable collidable)
        {
            if (collidable is Bullet)
            {
                Debug.Log("撃たれた！！ (´；ω；｀)ｳｯ…");
            }
        }

        protected override void Start()
        {
            base.Start();

            sceneModel.Register(this);
            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }
    }
}