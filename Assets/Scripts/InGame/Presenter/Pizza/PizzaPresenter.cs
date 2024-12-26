using InGame.Model.Pizza;
using UnityEngine;

namespace InGame.Presenter.Pizza
{
    /// <summary>
    /// PizzaのPresenter。
    /// </summary>
    public class PizzaPresenter : MonoBehaviour
    {
        private PizzaPiecesModel _pizzaPiecesModel;
        [SerializeField] private GameObject[] subPizzas;
        
        /// <summary>
        /// 最初の呼び出し。
        /// </summary>
        private void Awake()
        {
            _pizzaPiecesModel = new PizzaPiecesModel();
        }
        
        /// <summary>
        /// pizzaModelを取得する。
        /// </summary>
        /// <returns></returns>
        public PizzaPiecesModel GetPizzaPiecesModel()
        {
            return _pizzaPiecesModel;
        }
    }
}