using Components.simpleColliders;
using UnityEngine;

namespace Components.models
{
    public class Enemy : MonoBehaviour
    {
        public void OnColliderEnter(SpriteCollider2D other)
        {
            if (other.gameObject.CompareTag("Bullet"))
            {
                Destroy(gameObject);
            }
        }
    }
}