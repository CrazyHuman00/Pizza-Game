using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;

namespace InGame.View
{
    public class PizzaArrangementView : MonoBehaviour
    {
        [SerializeField] private GameObject pizzaPiecePrefab;
        [SerializeField] private Vector2 centerPoint;
        private Transform _parentTransform;

        private const int NumberOfSlices = 8;
        private const float AngleStep = 360f / NumberOfSlices;

        public void SetParentTransform(Transform parentTransform)
        {
            this._parentTransform = parentTransform;
        }

        public void ArrangePizzaSlices(Vector2 parentPosition)
        {
            var random = new System.Random();
            
            for (var i = 0; i < NumberOfSlices; i++)
            {
                if (random.NextDouble() < 0.5) { continue; }
                
                var angle = i * AngleStep;
                var radians = angle * Mathf.Deg2Rad;
                
                var prefab = Instantiate(pizzaPiecePrefab, _parentTransform);
                var prefabRectTransform = prefab.GetComponent<RectTransform>();

                var rotatedPosition = new Vector2(
                    parentPosition.x + centerPoint.x * Mathf.Cos(radians) - centerPoint.y * Mathf.Sin(radians),
                    parentPosition.y + centerPoint.x * Mathf.Sin(radians) + centerPoint.y * Mathf.Cos(radians)
                );

                prefabRectTransform.anchoredPosition = rotatedPosition;
                prefabRectTransform.rotation = Quaternion.Euler(0, 0, angle);
                prefabRectTransform.pivot = new Vector2(0.5f, 0.5f);
            }
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
