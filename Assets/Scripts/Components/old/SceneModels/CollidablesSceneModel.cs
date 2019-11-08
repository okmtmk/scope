using System;
using System.Collections.Generic;
using System.Linq;
using src.collisions;
using UnityEngine;

namespace Components.old.SceneModels
{
    public class CollidablesSceneModel : MonoBehaviour
    {
        [NonSerialized] public readonly List<ICollidable> Collidables = new List<ICollidable>();

        [NonSerialized]
        private readonly Dictionary<ICollidable, ICollidable> _collideds = new Dictionary<ICollidable, ICollidable>();

        public void Register(ICollidable collidable)
        {
            Collidables.Add(collidable);
        }

        public void Remove(ICollidable collidable)
        {
            RemoveFromCollideds(collidable);
            Collidables.Remove(collidable);
        }

        private void RemoveFromCollideds(ICollidable collidable)
        {
            if (_collideds.ContainsKey(collidable))
            {
                _collideds.Remove(collidable);
            }

            if (_collideds.ContainsValue(collidable))
            {
                foreach (var it in _collideds.Where(it => it.Value == collidable))
                {
                    _collideds.Remove(it.Key);
                    break;
                }
            }
        }

        private void Update()
        {
//            Debug.Log($"Collidable Objects : {Collidables.Count}\nCollided Objects : {_collideds.Count}");
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
                        Collide(a, b);

                        collideds.Add(b);
                    }
                    else
                    {
                        HandleExitCollider(a);
                    }
                });
            });
        }

        private void Collide(ICollidable a, ICollidable b)
        {
            if (!_collideds.ContainsKey(a))
            {
                a.OnEnterCollider(b);
                _collideds.Add(a, b);
            }

            if (!_collideds.ContainsKey(b))
            {
                b.OnEnterCollider(a);
                _collideds.Add(b, a);
            }

            a.OnCollide(b);
            b.OnCollide(a);
        }

        private void HandleExitCollider(ICollidable obj)
        {
            if (_collideds.ContainsKey(obj))
            {
                var collidable = _collideds[obj];
                obj.OnExitCollider(collidable);
                _collideds.Remove(obj);
            }
        }
    }
}