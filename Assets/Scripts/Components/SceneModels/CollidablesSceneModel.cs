using System;
using System.Collections.Generic;
using src.collisions;
using UnityEngine;

namespace Components.SceneModels
{
    public abstract class CollidablesSceneModel : MonoBehaviour
    {
        [NonSerialized] public readonly List<Collidable> Collidables = new List<Collidable>();

        public void Register(Collidable collidable)
        {
            Collidables.Add(collidable);
        }

        public void Remove(Collidable collidable)
        {
            Collidables.Remove(collidable);
        }

        private void Update()
        {
            var listA = new List<Collidable>(Collidables);

            listA.ForEach(a =>
            {
                var listB = new List<Collidable>(listA);
                listB.Remove(a);

                listB.ForEach(b =>
                {
                    if (CollisionRepository.IsColliding(a, b))
                    {
                        a.OnCollide(b);
                        b.OnCollide(a);

                        listA.Remove(b);
                    }
                });
            });
        }
    }
}