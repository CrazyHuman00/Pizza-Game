using UnityEngine;

namespace InGame.View
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMesh _scoreText;

        public void SetScore(int score)
        {
            _scoreText.text = score.ToString();
        }
    }
}