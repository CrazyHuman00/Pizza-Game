using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;

namespace InGame.View
{
    /// <summary>
    /// PizzaPlacementのView。
    /// </summary>
    public class PizzaArrangementView : MonoBehaviour
    {
        [SerializeField] private GameObject pizzaPiecePrefab;
        [SerializeField] private Vector2 centerPoint;
        
        private Transform _parentTransform;
        private const int NumberOfSlices = 8;
        private const float AngleStep = 45f;
        
        public void ArrangePizzaSlices(Vector2 parentPosition)
        {
            var random = new System.Random();
            var slicePlaced = 0;
            
            for (var i = 0; i < NumberOfSlices; i++)
            {
                if (random.NextDouble() < 0.7) { continue; }
                
                var angle = i * AngleStep;
                var radians = angle * Mathf.Deg2Rad;
                
                var prefab = Instantiate(pizzaPiecePrefab, _parentTransform);
                var prefabRectTransform = prefab.GetComponent<RectTransform>();

                var rotatedPosition = new Vector2(
                    parentPosition.x + centerPoint.x * Mathf.Cos(radians) - centerPoint.y * Mathf.Sin(radians),
                    parentPosition.y + centerPoint.x * Mathf.Sin(radians) + centerPoint.y * Mathf.Cos(radians)
                );
                
                prefab.name = "PizzaPiece" + i.ToString();

                prefabRectTransform.anchoredPosition = rotatedPosition;
                prefabRectTransform.rotation = Quaternion.Euler(0, 0, angle);
                prefabRectTransform.pivot = new Vector2(0.5f, 0.5f);

                slicePlaced++;
            }

            if (slicePlaced == 0)
            {
                var prefab = Instantiate(pizzaPiecePrefab, _parentTransform);
                var prefabRectTransform = prefab.GetComponent<RectTransform>();

                var rotatedPosition = new Vector2(
                    parentPosition.x + centerPoint.x * Mathf.Cos(0) - centerPoint.y * Mathf.Sin(0),
                    parentPosition.y + centerPoint.x * Mathf.Sin(0) + centerPoint.y * Mathf.Cos(0)
                );

                prefab.name = "PizzaPiece0";

                prefabRectTransform.anchoredPosition = rotatedPosition;
                prefabRectTransform.rotation = Quaternion.Euler(0, 0, 0);
                prefabRectTransform.pivot = new Vector2(0.5f, 0.5f);
            }
        }

        public void SetParentTransform(Transform parent)
        {
            _parentTransform = parent;
        }

        public Transform GetParentTransform()
        {
            return _parentTransform;
        }

        public void DeleteAllPizzaSlices()
        {
            foreach (Transform child in _parentTransform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
