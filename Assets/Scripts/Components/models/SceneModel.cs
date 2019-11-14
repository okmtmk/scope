using System;
using Components.levels;
using src.scenes;
using UnityEngine;

namespace Components.models
{
    public class SceneModel : MonoBehaviour
    {
        [SerializeField] public LevelPlayer levelPlayer;
        [NonSerialized] private SceneState _sceneState = SceneState.Wait;

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
            levelPlayer.PlayLevel();
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