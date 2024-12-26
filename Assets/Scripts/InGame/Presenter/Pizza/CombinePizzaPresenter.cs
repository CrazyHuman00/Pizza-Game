using System.Linq;
using InGame.Model.Pizza;
using InGame.View;
using InGame.View.Pizza;
using UnityEngine;
using UnityEngine.Serialization;

namespace InGame.Presenter.Pizza
{
    /// <summary>
    /// ピザを組み合わせるときに使うPresenter。
    /// サブピザをクリックしたときにメインピザに反映できるようにViewに反映する。
    /// そのあとサブピザにあった子ピザたちをメインピザのリストに格納する。
    /// </summary>
    public class CombinePizzaPresenter : MonoBehaviour
    {
        private PizzaPiecesModel _pizzaPiecesModel;
        
        [SerializeField] private CombinedPizzaView combinedPizzaView;
        [SerializeField] private Transform mainPizzaTransform;
        [SerializeField] private PizzaPresenter pizzaPresenter;
        [SerializeField] private PizzaPlacementPresenter pizzaPlacementPresenter;
        [SerializeField] private PizzaArrangementView pizzaArrangementView;
        
        
        private void Start()
        {
            _pizzaPiecesModel = pizzaPresenter.GetPizzaPiecesModel();
            _pizzaPiecesModel.ClearMainPizzaPieces();
        }
        
        public void OnClickPizza(GameObject parentPizza)
        {
            // 重複判定
            if (parentPizza.transform.Cast<Transform>().Any(child => _pizzaPiecesModel.ContainsPizzaPiece(child.name)))
            {
                Debug.Log("重複してます。");
                return;
            }

            // メインピザに配置する、リストに追加する。
            combinedPizzaView.PutAllPizzaToMainPizza(parentPizza.transform, mainPizzaTransform);
            
            foreach (Transform child in parentPizza.transform)
            {
                _pizzaPiecesModel.AddPizzaPiece(child);
            }
            
            // Viewも更新
            pizzaArrangementView.DeleteAllPizzaSlices();
            pizzaPlacementPresenter.PlacePizzas();
        }
    }
}