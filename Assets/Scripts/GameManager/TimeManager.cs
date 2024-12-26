using System.Collections;
using InGame.Model;
using UnityEngine;
using TMPro;

namespace GameManager
{
    public class TimeManager : MonoBehaviour
    {
        private static TimeManager _instance;
        private TimeModel _timeModel;
        [SerializeField] private SceneLoader sceneLoader;
        [SerializeField] private InGameUIManager uiManager;
        [SerializeField] private int countdown = 3; 
        [SerializeField] private int gameTime = 60;
        [SerializeField] private TextMeshProUGUI countdownText;
        [SerializeField] private TextMeshProUGUI gameTimeText;
        [SerializeField] private TextMeshProUGUI finishedText;

        
        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        private void Start()
        {
            _timeModel = new TimeModel(gameTime);
            StartCoroutine(StartCountdown());
        }
        
        private IEnumerator StartCountdown()
        {
            while (countdown > 0)
            {
                countdownText.text = countdown.ToString();
                yield return new WaitForSeconds(1f);
                countdown--;
            }

            countdownText.text = "Go!";
            yield return new WaitForSeconds(1f);
            countdownText.text = "";
            StartCoroutine(GameTimer());
        }
        
        private IEnumerator GameTimer()
        {
            uiManager.StartGame();
            while (_timeModel.GetTime() > 0)
            {
                gameTimeText.text =  _timeModel.GetTime().ToString();
                yield return new WaitForSeconds(1f);
                _timeModel.DecreaseTime();
            }

            finishedText.text = "Time's up!";
            yield return new WaitForSeconds(1f);
            sceneLoader.LoadNextSceneAsync();
        }
    }
}