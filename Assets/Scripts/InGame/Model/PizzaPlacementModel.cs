using UnityEngine;
using UnityEngine.Serialization;

namespace InGame.Model
{
    /// <summary>
    /// ピザの座標のmodel
    /// </summary>
    public class PizzaPlacementModel : MonoBehaviour
    {
        [System.Serializable]
        public struct PizzaPlacementData
        {
            public Vector2 position;
            public float rotationAngle;
        }

        [SerializeField] private PizzaPlacementData[] placements;

        public int PizzaCount => placements.Length;

        public Vector2 GetPizzaPosition(int index)
        {
            if (index >= 0 && index < placements.Length)
            {
                return placements[index].position;
            }

            return Vector2.zero;
        }

        public float GetPizzaRotation(int index)
        {
            if (index >= 0 && index < placements.Length)
            {
                return placements[index].rotationAngle;
            }

            return 0f;
        }
    }
}