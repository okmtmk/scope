using System;
using System.Diagnostics;
using src.positions;
using UnityEngine;

namespace Components.Shooters
{
    public class Bullet : MonoBehaviour
    {
        [NonSerialized] public float Speed = 50;

        [NonSerialized] public double Radius;
        [NonSerialized] private MovablePosition2 m_Position;
        [NonSerialized] private readonly Stopwatch m_Stopwatch = new Stopwatch();


        private void Start()
        {
            m_Position = new MovablePosition2(gameObject.transform.position, 20);
            m_Stopwatch.Start();
        }

        private void Update()
        {
            if (m_Position.IsOutside)
            {
                Destroy(gameObject);
            }

            m_Position.Move(Radius, Speed, m_Stopwatch.ElapsedMilliseconds);
            gameObject.transform.position = new Vector3(m_Position.Vector2.x, m_Position.Vector2.y, 1);

            m_Stopwatch.Restart();
        }
    }
}