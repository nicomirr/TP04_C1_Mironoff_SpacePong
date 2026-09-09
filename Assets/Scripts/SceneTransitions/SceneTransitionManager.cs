using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Game.Data;

namespace Game.SceneTransitions
{
    public class SceneTransitionManager : MonoBehaviour
    {
        [SerializeField] private FadeBackgroundController _fadeBackground;

        private void Awake()
        {
            SceneTransitionEvents.OnSceneChangeRequested += ChangeScene;
        }

        private void OnDestroy()
        {
            SceneTransitionEvents.OnSceneChangeRequested -= ChangeScene;
        }

        private void ChangeScene(SceneToLoadSo sceneToLoad)
        {
            StartCoroutine(ChangeSceneRoutine(sceneToLoad.sceneToLoadName, sceneToLoad.TransitionTime));
        }

        private IEnumerator ChangeSceneRoutine(string sceneName, float transitionTime)
        {
            _fadeBackground.FadeOut();

            yield return new WaitForSeconds(transitionTime);

            SceneManager.LoadSceneAsync(1);
        }
    }
}

