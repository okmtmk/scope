using System;
using System.Diagnostics;
using Components.levels;
using src.scenes;
using UnityEngine;
using UnityEngine.UI;

namespace Components.models
{
    public class SceneModel : MonoBehaviour
    {
        [SerializeField] public LevelPlayer levelPlayer;

        [NonSerialized] private SceneState _sceneState = SceneState.Wait;
        [NonSerialized] private readonly Stopwatch _stopwatch = new Stopwatch();

        public SceneState SceneState
        {
            get => _sceneState;
            set
            {
                _sceneState = value;

                switch (value)
                {
                    case SceneState.Wait:
                        OnStateWait();
                        break;

                    case SceneState.Shooting:
                        OnStateShooting();
                        break;

                    case SceneState.GameOver:
                        OnStateGameOver();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(value), value, null);
                }
            }
        }

        private void Start()
        {
            _stopwatch.Start();
        }

        private void Update()
        {
            if (SceneState == SceneState.Wait && _stopwatch.ElapsedMilliseconds > 1000)
            {
                SceneState = SceneState.Shooting;
                _stopwatch.Stop();
            }
        }

        private void OnStateWait()
        {
        }

        private void OnStateShooting()
        {
            levelPlayer.PlayLevel();
        }

        private void OnStateGameOver()
        {
            levelPlayer.StopLevel();
        }
    }
}