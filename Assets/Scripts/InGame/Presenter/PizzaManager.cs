using System;
using InGame.Model;
using InGame.View;
using UnityEngine;

namespace InGame.Presenter
{
    public class PizzaManager : MonoBehaviour
    {
        private PizzaPiecesModel _pizzaPiecesModel;
        [SerializeField] private GameObject[] subPizzas;

        private void Start()
        {
            
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