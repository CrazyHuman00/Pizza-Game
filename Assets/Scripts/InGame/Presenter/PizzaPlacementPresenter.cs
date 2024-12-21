using UnityEngine;
using InGame.Model;
using InGame.View;

namespace InGame.Presenter
{
    /// <summary>
    /// modelからピザの座標を取得してviewに反映させる。
    /// </summary>
    public class PizzaPlacementPresenter : MonoBehaviour
    {
        [SerializeField] private PizzaPlacementModel model;
        [SerializeField] private PizzaArrangementView view;
        [SerializeField] private GameObject parentObject;
        [SerializeField] private int parentNumber;

        private void Start()
        {
            PlacePizzas();
        }

        public void PlacePizzas()
        {
            var place = model.GetPizzaPosition(parentNumber);
            view.SetParentTransform(parentObject.transform);
            view.ArrangePizzaSlices(place);
        }
    }
}