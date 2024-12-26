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
        [SerializeField] private float countdown = 3;
        [SerializeField] private float gameTime = 60;
        [SerializeField] private TextMeshProUGUI countdownText;
        [SerializeField] private TextMeshProUGUI gameTimeText;
        [SerializeField] private TextMeshProUGUI finishedText;

        private void Start()
        {
            _timeModel = new TimeModel(gameTime);
        }

        private void Update()
        {
            gameTime -= Time.deltaTime;
        }
    }
}