using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;

namespace InGame.View.Pizza
{
    /// <summary>
    /// PizzaPlacementのView。
    /// </summary>
    public class PizzaArrangementView : MonoBehaviour
    {
        [SerializeField] private GameObject pizzaPiecePrefab;
        [SerializeField] private GameObject goldPizzaPiecePrefab;
        [SerializeField] private Vector2 centerPoint;
        
        private Transform _parentTransform;
        private const int NumberOfSlices = 8;
        private const float AngleStep = 45f;
   
        
        /// <summary>
        /// サブピザを8等分に配置する。
        /// </summary>
        /// <param name="parentPosition"></param>
        public void ArrangePizzaSlices(Vector2 parentPosition)
        {
            var slicePlaced = 0;

            for (var i = 0; i < NumberOfSlices; i++)
            {
                if (!ShouldPlaceSlice(20)) continue;
                PlacePizzaSlice(i, parentPosition);
                slicePlaced++;
            }

            if (slicePlaced == 0)
            {
                PlacePizzaSlice(0, parentPosition);
            }
        }

        
        /// <summary>
        /// 確率調整。
        /// </summary>
        /// <param name="percent"></param>
        /// <returns></returns>
        private static bool ShouldPlaceSlice(int percent)
        {
            return Random.Range(0, 100) < percent;
        }

        
        /// <summary>
        /// ピザを配置する。
        /// </summary>
        /// <param name="index"></param>
        /// <param name="parentPosition"></param>
        private void PlacePizzaSlice(int index, Vector2 parentPosition)
        {
            var angle = index * AngleStep;
            var radians = angle * Mathf.Deg2Rad;

            var isGoldPizza = ShouldPlaceSlice(1);
            var prefab = Instantiate(isGoldPizza ? goldPizzaPiecePrefab : pizzaPiecePrefab, _parentTransform);
            
            var prefabRectTransform = prefab.GetComponent<RectTransform>();
            var rotatedPosition = CalculateRotatedPosition(parentPosition, radians);

            prefab.name = (isGoldPizza ? "GoldPizzaPiece" : "PizzaPiece") + index.ToString();
            prefabRectTransform.anchoredPosition = rotatedPosition;
            prefabRectTransform.rotation = Quaternion.Euler(0, 0, angle);
            prefabRectTransform.pivot = new Vector2(0.5f, 0.5f);
        }

        
        /// <summary>
        /// 回転させて配置する。
        /// </summary>
        /// <param name="parentPosition"></param>
        /// <param name="radians"></param>
        /// <returns></returns>
        private Vector2 CalculateRotatedPosition(Vector2 parentPosition, float radians)
        {
            return new Vector2(
                parentPosition.x + centerPoint.x * Mathf.Cos(radians) - centerPoint.y * Mathf.Sin(radians),
                parentPosition.y + centerPoint.x * Mathf.Sin(radians) + centerPoint.y * Mathf.Cos(radians)
            );
        }

        
        /// <summary>
        /// 親オブジェクトをセットする。
        /// </summary>
        /// <param name="parent"></param>
        public void SetParentTransform(Transform parent)
        {
            _parentTransform = parent;
        }

        
        /// <summary>
        /// 親オブジェクトを取得する。
        /// </summary>
        /// <returns></returns>
        public Transform GetParentTransform()
        {
            return _parentTransform;
        }

        
        /// <summary>
        /// ピザを全て消す。
        /// </summary>
        public void DeleteAllPizzaSlices()
        {
            foreach (Transform child in _parentTransform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
