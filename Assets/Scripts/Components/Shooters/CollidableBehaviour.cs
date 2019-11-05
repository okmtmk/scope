using System;
using Components.SceneModels;
using src.collisions;
using UnityEngine;

namespace Components.Shooters
{
    public abstract class CollidableBehaviour : MonoBehaviour, ICollidable
    {
        [SerializeField] public CollidablesSceneModel sceneModel;

        [NonSerialized] protected SpriteRenderer SpriteRenderer;

        public float X => gameObject.transform.position.x;
        public float Y => gameObject.transform.position.y;
        public float Width => SpriteRenderer.bounds.size.x;
        public float Height => SpriteRenderer.bounds.size.y;
        public abstract void OnCollide(ICollidable collidable);

        public virtual void OnEnterCollider(ICollidable collidable)
        {
            
        }

        public virtual void OnExitCollider(ICollidable collidable)
        {
            
        }

        protected virtual void Start()
        {
            SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }

        protected void OnDisable()
        {
            sceneModel.Remove(this);
        }
    }
}