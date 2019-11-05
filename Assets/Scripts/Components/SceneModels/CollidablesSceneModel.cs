using System;
using System.Collections.Generic;
using src.collisions;
using UnityEngine;

namespace Components.SceneModels
{
    public class CollidablesSceneModel : MonoBehaviour
    {
        [NonSerialized] public readonly List<ICollidable> Collidables = new List<ICollidable>();
        [NonSerialized] private readonly Dictionary<ICollidable,ICollidable> _collideds = new Dictionary<ICollidable,ICollidable>();

        public void Register(ICollidable collidable)
        {
            Collidables.Add(collidable);
        }

        public void Remove(ICollidable collidable)
        {
            Collidables.Remove(collidable);
        }

        private void Update()
        {
            Debug.Log($"size : {Collidables.Count}");
            var listA = new List<ICollidable>(Collidables);
            var collideds = new List<ICollidable>();

            listA.ForEach(a =>
            {
                if (collideds.Contains(a))
                {
                    return;
                }

                var listB = new List<ICollidable>(listA);
                listB.Remove(a);

                listB.ForEach(b =>
                {
                    if (CollisionRepository.IsColliding(a, b))
                    {
                        if (!_collideds.ContainsKey(a))
                        {
                            a.OnEnterCollider(b);
                            _collideds.Add(a,b);
                        }

                        if (!_collideds.ContainsKey(b))
                        {
                            b.OnEnterCollider(a);
                            _collideds.Add(b,a);
                        }

                        a.OnCollide(b);
                        b.OnCollide(a);

                        collideds.Add(b);
                    }
                    else
                    {
                        if (_collideds.ContainsKey(a))
                        {
                            var collidable = _collideds[a];
                            a.OnExitCollider(collidable);
                            _collideds.Remove(a);
                        }
                    }
                });
            });
        }
    }
}