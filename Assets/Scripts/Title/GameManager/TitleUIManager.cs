using UnityEngine;

namespace Title.GameManager
{
    /// <summary>
    /// UIの管理をする。
    /// </summary>
    public class TitleUIManager : MonoBehaviour
    {
        [SerializeField] private GameObject menuPanel;
        [SerializeField] private GameObject loadingPanel;
        [SerializeField] private GameObject settingPanel;

        private void Start()
        {
            BackToMenuUI();
        }
        
        private void BackToMenuUI()
        {
            menuPanel.SetActive(true);
            loadingPanel.SetActive(false);
            settingPanel.SetActive(false);
        }

        public void SelectSettingDescriptionUI()
        {
            menuPanel.SetActive(false);
            settingPanel.SetActive(true);
        }
    }
}
