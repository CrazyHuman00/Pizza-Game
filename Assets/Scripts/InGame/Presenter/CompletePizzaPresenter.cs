using GameManager;
using InGame.Model;
using InGame.View;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace InGame.Presenter
{
    /// <summary>
    /// ピザが完成した時のPresenter。
    /// ピザが完成したら、メインピザの中身を空にする。そして、Viewを更新する。
    /// スコアを加算させ、
    /// </summary>
    public class CompletePizzaPresenter : MonoBehaviour
    { 
        private PizzaPiecesModel _pizzaPiecesModel;
        private ScoreModel _scoreModel;
        [SerializeField] private ScoreView scoreView;
        [SerializeField] private PizzaManager pizzaManager;
        [SerializeField] private Transform mainPizzaTransform;

        private void Start()
        {
            _pizzaPiecesModel = pizzaManager.GetPizzaPiecesModel();
            _scoreModel = new ScoreModel(0);
        }
        
        private void Update()
        {
            if (_pizzaPiecesModel.GetMainPizzaPieces().Count == 8)
            {
                // スコアに加算
                _scoreModel.AddScore(10);
                
                // メインピザのリスト内を全て消す
                _pizzaPiecesModel.ClearMainPizzaPieces();
                
                // Viewも更新
                scoreView.SetScore(_scoreModel.GetScore());
                
                foreach (Transform child in mainPizzaTransform)
                {
                    Destroy(child.gameObject);
                }
            }
        }
    }
}