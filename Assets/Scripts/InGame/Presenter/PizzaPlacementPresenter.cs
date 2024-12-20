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

        private void Start()
        {
            PlacePizzas();
        }

        private void PlacePizzas()
        {
            for (var i = 0; i < model.PizzaCount; i++)
            {
                var place = model.GetPizzaPosition(i);
                view.ArrangePizzaSlices(place);
            }
        }
    }
}