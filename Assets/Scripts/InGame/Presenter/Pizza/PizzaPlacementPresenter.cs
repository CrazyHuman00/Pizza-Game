using InGame.Model.Pizza;
using InGame.View.Pizza;
using UnityEngine;

namespace InGame.Presenter.Pizza
{
    /// <summary>
    /// modelからピザの座標を取得してviewに反映させるPresenter。
    /// </summary>
    public class PizzaPlacementPresenter : MonoBehaviour
    {
        [SerializeField] private PizzaArrangementView pizzaArrangementView;
        [SerializeField] private GameObject parentObject;
        [SerializeField] private Vector2 parentPositions;
        [SerializeField] private int parentNumber;
        private PizzaPlacementModel _model;

        private void Start()
        {
            _model = new PizzaPlacementModel();
            InitializePizzaPlacements();
            PlacePizzas();
        }

        
        /// <summary>
        /// 初期設定。
        /// </summary>
        private void InitializePizzaPlacements()
        {
            _model.AddPizzaPlacement(parentPositions);
        }

        
        /// <summary>
        /// ピザの配置。
        /// </summary>
        public void PlacePizzas()
        {
            pizzaArrangementView.SetParentTransform(parentObject.transform);
            pizzaArrangementView.ArrangePizzaSlices(_model.GetPizzaPosition(parentNumber));
        }
    }
}