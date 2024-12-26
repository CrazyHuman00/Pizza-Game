using TMPro;
using UnityEngine;

namespace InGame.GameManager
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        private int _score;

        private void Start()
        {
            _score = 0;
        }

        private void Update()
        {
            scoreText.text = _score.ToString();
        }

        public void AddScore(int scoreToAdd)
        {
            _score += scoreToAdd;
        }
    }
}