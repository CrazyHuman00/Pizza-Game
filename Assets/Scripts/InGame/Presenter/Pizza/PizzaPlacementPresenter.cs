using InGame.Model.Pizza;
using InGame.View;
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

        private void InitializePizzaPlacements()
        {
            _model.AddPizzaPlacement(parentPositions, 0);
        }

        public void PlacePizzas()
        {
            pizzaArrangementView.SetParentTransform(parentObject.transform);
            pizzaArrangementView.ArrangePizzaSlices(_model.GetPizzaPosition(parentNumber));
        }
    }
}