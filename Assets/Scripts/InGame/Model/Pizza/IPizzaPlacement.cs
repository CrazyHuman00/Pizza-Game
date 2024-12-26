using System.Collections.Generic;
using UnityEngine;

namespace InGame.Model.Pizza
{
    public interface IPizzaPlacement
    {
        public Vector2 GetPizzaPosition(int index);

        public void AddPizzaPlacement(Vector3 position);
    }
}