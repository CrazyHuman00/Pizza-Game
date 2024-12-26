using UnityEngine;
using TMPro;

namespace InGame.View
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;

        public void SetScore(int score)
        {
            scoreText.text = score.ToString();
        }
    }
}