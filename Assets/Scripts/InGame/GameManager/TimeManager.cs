using System;
using System.Collections;
using System.Globalization;
using TMPro;
using UnityEngine;

namespace InGame.GameManager
{
    public class TimeManager : MonoBehaviour
    {
        [SerializeField] private float initialTime = 3f;
        [SerializeField] private float inGameCountDownTime = 60f;
        [SerializeField] private TextMeshProUGUI initialTimeText;
        [SerializeField] private TextMeshProUGUI inGameCountDownText;
        
        [SerializeField] private InGameUIManager inGameUIManager;

        private void Start()
        {
            StartCoroutine(CountDown());
        }

        private IEnumerator CountDown()
        {
            while (initialTime > 0)
            {
                UpdateCountDownText(initialTime, initialTimeText);
                initialTime -= Time.deltaTime;
                yield return null;
            }
            
            inGameUIManager.IsActiveInGameUI();

            while (inGameCountDownTime > 0)
            {
                UpdateCountDownText(inGameCountDownTime, inGameCountDownText);
                inGameCountDownTime -= Time.deltaTime;
                yield return null;
            }
            
            inGameUIManager.IsActiveFinishedUI();
        }

        private static void UpdateCountDownText(float time, TextMeshProUGUI text)
        {
            text.text = time.ToString("0",CultureInfo.InvariantCulture);
        }
    }
}