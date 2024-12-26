using UnityEngine;

namespace InGame.GameManager
{
    /// <summary>
    /// InGameのUIManager
    /// </summary>
    public class InGameUIManager : MonoBehaviour

    {
        [SerializeField] private GameObject initialPanel;
        [SerializeField] private GameObject inGamePanel;
        [SerializeField] private GameObject finishedPanel;
        [SerializeField] private GameObject loadingPanel;
        
        private void Start()
        {
            IsActiveInitialCountDownUI();
        }
        
        private void IsActiveInitialCountDownUI()
        {
            initialPanel.SetActive(true);
            inGamePanel.SetActive(false);
            finishedPanel.SetActive(false);
            loadingPanel.SetActive(false);
        }

        public void IsActiveInGameUI()
        {
            initialPanel.SetActive(false);
            inGamePanel.SetActive(true);
            finishedPanel.SetActive(false);
            loadingPanel.SetActive(false);
        }

        public void IsActiveFinishedUI()
        {
            initialPanel.SetActive(false);
            inGamePanel.SetActive(false);
            finishedPanel.SetActive(true);
            loadingPanel.SetActive(false);
        }
    }
}