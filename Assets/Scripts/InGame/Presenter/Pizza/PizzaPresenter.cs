using InGame.Model.Pizza;
using UnityEngine;

namespace InGame.Presenter.Pizza
{
    public class PizzaPresenter : MonoBehaviour
    {
        private PizzaPiecesModel _pizzaPiecesModel;
        [SerializeField] private GameObject[] subPizzas;
        
        private void Awake()
        {
            _pizzaPiecesModel = new PizzaPiecesModel();
        }
        
        public GameObject[] GetSubPizzas()
        {
            return subPizzas;
        }

        public PizzaPiecesModel GetPizzaPiecesModel()
        {
            return _pizzaPiecesModel;
        }
    }
}