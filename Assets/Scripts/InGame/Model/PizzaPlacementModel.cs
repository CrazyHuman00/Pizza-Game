using System.Collections.Generic;
using UnityEngine;

namespace InGame.Model
{
    /// <summary>
    /// ピザそれぞれの座標の情報。
    /// </summary>
    public class PizzaPlacementModel
    { 
        [System.Serializable]
        public struct PizzaPlacementData
        {
            public Vector3 position;
            public float rotationAngle;
        }
        
        private readonly List<PizzaPlacementData> _placements;
        private int PizzaCount => _placements.Count;

        public PizzaPlacementModel()
        {
            _placements = new List<PizzaPlacementData>();
        }
        
        public Vector2 GetPizzaPosition(int index)
        {
            if (index >= 0 && index < PizzaCount)
            {
                return _placements[index].position;
            }

            return Vector2.zero;
        }

        public void AddPizzaPlacement(Vector3 position, float rotationAngle)
        {
            var newPlacement = new PizzaPlacementData
            {
                position = position,
                rotationAngle = rotationAngle
            };
            _placements.Add(newPlacement);
        }
    }
}