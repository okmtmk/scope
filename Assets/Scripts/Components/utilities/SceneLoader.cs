using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Components.utilities
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private string sceneName;
        [SerializeField] private float animationSecond = 0.5f;
        [SerializeField] public bool isChangeable = false;
        
        [NonSerialized] private readonly Stopwatch _stopwatch = new Stopwatch();

        private static readonly int OnExit = Animator.StringToHash("OnExit");

        private void Start()
        {
            _stopwatch.Start();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && isChangeable)
            {
                animator.SetTrigger(OnExit);
                StartCoroutine(LoadScene());
            }
        }

        private IEnumerator LoadScene()
        {
            yield return new WaitForSeconds(animationSecond);
            SceneManager.LoadScene(sceneName);
        }
    }
}