using UnityEngine;

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
        
        private static string RenamePizzaPiece(string pizzaName, int pieceIndex)
        {
            var numberPart = pizzaName.Replace("PizzaPiece", "");
            var pieceNumber = int.Parse(numberPart);
            
            pieceNumber += pieceIndex;
            pieceNumber %= 8;

            if (pieceNumber < 0) { pieceNumber = 7; }
            if (pieceNumber > 7) { pieceNumber = 0; }
            
            return "PizzaPiece" + pieceNumber.ToString();
        }

        private void RotateLeftPizzaSlices()
        {
            var parentTransform = pizzaArrangementView.GetParentTransform();
            foreach (Transform child in parentTransform)
            {
                child.name = RenamePizzaPiece(child.name,-1);
                RotateAroundReference(child, -RotationAngle);
            }
        }

        private void RotateRightPizzaSlices()
        {
            var parentTransform = pizzaArrangementView.GetParentTransform();
            foreach (Transform child in parentTransform)
            {
                child.name = RenamePizzaPiece(child.name,1);
                RotateAroundReference(child, RotationAngle);
            }
        }

        private void RotateAroundReference(Transform child, float angle)
        {
            child.RotateAround(referenceObject.position, Vector3.forward, angle);
        }
    }
}