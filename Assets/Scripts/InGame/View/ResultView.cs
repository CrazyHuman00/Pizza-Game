using System;
using GameManager;
using TMPro;
using UnityEngine;

namespace InGame.View
{
    public class ResultView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;

        private void Start()
        {
            scoreText.text = ScoreManager.Score.ToString();
        }
    }
}