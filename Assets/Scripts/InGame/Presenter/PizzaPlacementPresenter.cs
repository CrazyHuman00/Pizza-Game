using UnityEngine;
using InGame.Model;
using InGame.View;

namespace InGame.Presenter
{
    /// <summary>
    /// modelからピザの座標を取得してviewに反映させるPresenter。
    /// </summary>
    public class PizzaPlacementPresenter : MonoBehaviour
    {
        [SerializeField] private PizzaArrangementView view;
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
            var place = _model.GetPizzaPosition(parentNumber);
            view.SetParentTransform(parentObject.transform);
            view.ArrangePizzaSlices(place);
        }
    }
}