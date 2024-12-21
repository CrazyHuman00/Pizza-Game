using UnityEngine;

namespace InGame.View
{
    public class CombinedPizzaView : MonoBehaviour
    {
        public void PutAllPizzaToMainPizza(Transform pizzaPiecePrefab, Transform mainPizzaTransform)
        {
            foreach (Transform child in pizzaPiecePrefab)
            {   
                Instantiate(child.gameObject, mainPizzaTransform);
            }
        }
    }
}