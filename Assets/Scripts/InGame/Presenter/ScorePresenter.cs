using UnityEngine;
using InGame.Model;
using InGame.View;
using GameManager;

namespace InGame.Presenter
{
    public class ScorePresenter : MonoBehaviour
    {
        private ScoreModel _scoreModel;
        [SerializeField] private ScoreView scoreView;

        private void Start()
        {
            _scoreModel = new ScoreModel(ScoreManager.Score);
            scoreView.SetScore(_scoreModel.GetScore());
        }

        private void Update()
        {
            scoreView.SetScore(_scoreModel.GetScore());
        }
        
        public void AddScore(int score)
        {
            _scoreModel.AddScore(score);
            ScoreManager.Score = _scoreModel.GetScore(); 
            scoreView.SetScore(_scoreModel.GetScore());
        }

    }
}