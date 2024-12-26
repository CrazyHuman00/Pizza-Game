using System.Collections.Generic;
using UnityEngine;

namespace InGame.Model.Pizza
{
    /// <summary>
    /// ピザそれぞれの座標の情報。
    /// </summary>
    public class PizzaPlacementModel
    { 
        /// <summary>
        /// PizzaPlacementの情報
        /// </summary>
        [System.Serializable]
        public struct PizzaPlacementData
        {
            public Vector3 position;
        }
        
        /// <summary>
        /// ピザの場所の情報
        /// </summary>
        private readonly List<PizzaPlacementData> _placements = new();
        
        /// <summary>
        /// ピザのカウント
        /// </summary>
        private int PizzaCount => _placements.Count;

        
        /// <summary>
        /// indexをもとに子ピザを取得する。
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Vector2 GetPizzaPosition(int index)
        {
            if (index >= 0 && index < PizzaCount)
            {
                return _placements[index].position;
            }

            return Vector2.zero;
        }

        
        /// <summary>
        /// ピザの場所をリストに追加する。
        /// </summary>
        /// <param name="position"></param>
        public void AddPizzaPlacement(Vector3 position)
        {
            var newPlacement = new PizzaPlacementData
            {
                position = position,
            };
            _placements.Add(newPlacement);
        }
    }
}