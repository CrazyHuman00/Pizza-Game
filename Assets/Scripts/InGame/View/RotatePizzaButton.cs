using UnityEngine;
using UnityEngine.Serialization;

namespace InGame.View
{
    /// <summary>
    /// ピザを回転させるボタン。
    /// </summary>
    public class RotatePizzaButton : MonoBehaviour
    {
        [SerializeField] private PizzaArrangementView pizzaArrangementView;
        [SerializeField] private Transform referenceObject;
        private const float RotationAngle = 45f;

        public void OnClickLeft()
        {
            RotateLeftPizzaSlices();
        }

        public void OnClickRight()
        {
            RotateRightPizzaSlices();
        }

        private void RotateLeftPizzaSlices()
        {
            var parentTransform = pizzaArrangementView.GetParentTransform();
            foreach (Transform child in parentTransform)
            {
                RotateAroundReference(child, -RotationAngle);
            }
        }

        private void RotateRightPizzaSlices()
        {
            var parentTransform = pizzaArrangementView.GetParentTransform();
            foreach (Transform child in parentTransform)
            {
                RotateAroundReference(child, RotationAngle);
            }
        }

        private void RotateAroundReference(Transform child, float angle)
        {
            child.RotateAround(referenceObject.position, Vector3.forward, angle);
        }
    }
}