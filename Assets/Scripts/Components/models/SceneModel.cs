using System;
using System.Diagnostics;
using Components.levels;
using Components.utilities;
using src.scenes;
using UnityEngine;
using UnityEngine.UI;

namespace Components.models
{
    public class SceneModel : MonoBehaviour
    {
        [SerializeField] private long gameStartDelay = 1500;
        [SerializeField] public LevelPlayer levelPlayer;
        [SerializeField] private Animator canvasAnimator;
        [SerializeField] private ResultViewer result;

        [NonSerialized] private SceneState _sceneState = SceneState.Wait;
        [NonSerialized] private readonly Stopwatch _stopwatch = new Stopwatch();

        private static readonly int GameOver = Animator.StringToHash("GameOver");

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

                    case SceneState.Result:
                        OnStateResult();
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
            if (SceneState == SceneState.Wait && _stopwatch.ElapsedMilliseconds > gameStartDelay)
            {
                SceneState = SceneState.Shooting;
                _stopwatch.Stop();
            }

            if (SceneState == SceneState.GameOver && Input.GetMouseButtonDown(0))
            {
                // todo タイトルにもどる
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
            canvasAnimator.SetTrigger(GameOver);
        }

        private void OnStateResult()
        {
            result.ShowResult();
        }
    }
}