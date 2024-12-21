using System;
using UnityEngine;
using InGame.Presenter;

namespace InGame.View
{
    public class RenewPizzaButton : MonoBehaviour
    {
        [SerializeField] private PizzaPlacementPresenter pizzaPlacementPresenter;
        [SerializeField] private PizzaArrangementView pizzaArrangementView;
        
        public void OnClick()
        {
            
            Debug.Log("pushed");
            pizzaArrangementView.DeleteAllPizzaSlices();
            pizzaPlacementPresenter.PlacePizzas();
        }
    }
}
