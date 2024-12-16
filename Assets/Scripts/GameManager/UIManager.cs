using UnityEngine;

namespace GameManager
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject menuPanel;
        [SerializeField] private GameObject loadingPanel;
        [SerializeField] private GameObject settingPanel;

        private void Start()
        {
            BackToMenu();
        }

        public void SelectSettingDescription()
        {
            menuPanel.SetActive(false);
            settingPanel.SetActive(true);
        }

        public void BackToMenu()
        {
            menuPanel.SetActive(true);
            loadingPanel.SetActive(false);
            settingPanel.SetActive(false);
        }
    }
}
