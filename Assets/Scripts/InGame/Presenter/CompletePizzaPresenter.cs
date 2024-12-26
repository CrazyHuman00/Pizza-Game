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
        [SerializeField] private PizzaManager pizzaManager;
        [SerializeField] private Transform mainPizzaTransform;
        [SerializeField] private ScorePresenter scorePresenter;

        
        private void Start()
        {
            _pizzaPiecesModel = pizzaManager.GetPizzaPiecesModel();
        }
        
        private void Update()
        {
            if (_pizzaPiecesModel.GetMainPizzaPieces().Count == 8)
            {
                // スコアに加算
                scorePresenter.AddScore(10);
                
                // メインピザのリスト内を全て消す
                _pizzaPiecesModel.ClearMainPizzaPieces();
                
                foreach (Transform child in mainPizzaTransform)
                {
                    Destroy(child.gameObject);
                }
            }
        }
    }
}