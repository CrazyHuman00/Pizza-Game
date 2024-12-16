using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameManager
{
    /// <summary>
    /// Sceneの遷移を非同期でする。
    /// </summary>
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private string loadSceneName;
        [SerializeField] private GameObject loadingUI;

        public void LoadNextSceneAsync()
        {
            StartCoroutine(LoadSceneAsync(loadSceneName));
        }

        private IEnumerator LoadSceneAsync(string sceneName)
        {
            loadingUI.SetActive(true);
            
            var asyncLoad = SceneManager.LoadSceneAsync(sceneName);
            
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
            
            loadingUI.SetActive(false);
        }
    }
}
