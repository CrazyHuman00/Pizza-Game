using System.Linq;
using InGame.GameManager;
using InGame.Model.Pizza;
using UnityEngine;

namespace InGame.Presenter.Pizza
{
    /// <summary>
    /// ピザが完成した時のPresenter。
    /// ピザが完成したら、メインピザの中身を空にする。そして、Viewを更新する。
    /// スコアを加算させ、
    /// </summary>
    public class CompletePizzaPresenter : MonoBehaviour
    {
        private PizzaPiecesModel _pizzaPiecesModel;
        [SerializeField] private PizzaPresenter pizzaPresenter;
        [SerializeField] private Transform mainPizzaTransform;
        [SerializeField] private ScoreManager scoreManager;

        
        private void Start()
        {
            _pizzaPiecesModel = pizzaPresenter.GetPizzaPiecesModel();
        }
        
        private void Update()
        {
            if (_pizzaPiecesModel.GetMainPizzaPieces().Count != 8) return;
            
            // 金のピザピースが何個含まれているかチェック
            var goldPizzaPieceCount = _pizzaPiecesModel.GetMainPizzaPieces().Count(piece => piece.pizzaPiecesName.Contains("GoldPizzaPiece"));

            // スコアに加算
            scoreManager.AddScore(10 + 10 * goldPizzaPieceCount);

            // メインピザのリストを全て消す
            _pizzaPiecesModel.ClearMainPizzaPieces();
            
            // メインピザのオブジェクトを全て消す
            foreach (Transform child in mainPizzaTransform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}