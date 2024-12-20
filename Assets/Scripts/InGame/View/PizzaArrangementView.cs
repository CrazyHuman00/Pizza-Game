using System;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace InGame.View
{
    public class PizzaArrangementView : MonoBehaviour
    {
        [SerializeField] private GameObject pizzaPiecePrefab;
        [SerializeField] private RectTransform canvasRectTransform;
        [SerializeField] private Vector2 centerPoint;
        
        private const int NumberOfSlices = 8;
        private const float AngleStep = 360f / NumberOfSlices;

        public void ArrangePizzaSlices(Vector2 pizzaPlace)
        {
            for (var i = 0; i < NumberOfSlices; i++)
            {
                var angle = i * AngleStep;
                var radians = angle * Mathf.Deg2Rad;
                
                var prefab = Instantiate(pizzaPiecePrefab, canvasRectTransform);
                var prefabRectTransform = prefab.GetComponent<RectTransform>();

                var rotatedPosition = new Vector2(
                    pizzaPlace.x + centerPoint.x * Mathf.Cos(radians) - centerPoint.y * Mathf.Sin(radians),
                    pizzaPlace.y + centerPoint.x * Mathf.Sin(radians) + centerPoint.y * Mathf.Cos(radians)
                );

                prefabRectTransform.anchoredPosition = rotatedPosition;
                prefabRectTransform.rotation = Quaternion.Euler(0, 0, angle);
                prefabRectTransform.pivot = new Vector2(0.5f, 0.5f);
            }
        }
    }
}
