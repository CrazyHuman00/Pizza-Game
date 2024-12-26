using InGame.Model;
using InGame.View;
using UnityEngine;

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
        [SerializeField] private CompletePizzaView completePizzaView;
        [SerializeField] private ScoreView scoreView;

        private void Start()
        {
            _pizzaPiecesModel = new PizzaPiecesModel();
        }

        private void Update()
        {
            if (_pizzaPiecesModel.GetMainPizzaPieces().Count == 8)
            {
                completePizzaView.gameObject.SetActive(true);
            }
        }
    }
}