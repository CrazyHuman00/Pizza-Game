using UnityEngine;

namespace GameManager
{
    public class InGameUIManager : MonoBehaviour

    {
        [SerializeField] private GameObject inGamePanel;
        [SerializeField] private GameObject loadingPanel;
        [SerializeField] private GameObject startPanel;
        
        private void Start()
        {
            InitialCountDown();
        }

        public void StartGame()
        {
            inGamePanel.SetActive(true);
            loadingPanel.SetActive(false);
            startPanel.SetActive(false);
        }

        private void InitialCountDown()
        {
            inGamePanel.SetActive(false);
            loadingPanel.SetActive(false);
            startPanel.SetActive(true);
        }
    }
}