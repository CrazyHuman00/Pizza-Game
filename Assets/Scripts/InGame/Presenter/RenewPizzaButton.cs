using InGame.View;
using UnityEngine;

namespace InGame.Presenter
{
    /// <summary>
    /// ピザを再配置させるボタン。
    /// </summary>
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
