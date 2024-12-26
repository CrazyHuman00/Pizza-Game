using UnityEngine;
using InGame.Model;
using InGame.View;

namespace InGame.Presenter
{
    /// <summary>
    /// ピザを組み合わせるときに使うPresenter。
    /// サブピザをクリックしたときにメインピザに反映できるようにViewに反映する。
    /// そのあとサブピザにあった子ピザたちをメインピザのリストに格納する。
    /// </summary>
    public class CombinePizzaPresenter : MonoBehaviour
    {
        private PizzaPiecesModel _pizzaPiecesModel;
        
        [SerializeField] private Transform mainPizzaTransform;
        [SerializeField] private CombinedPizzaView combinedPizzaView;
        [SerializeField] private PizzaManager pizzaManager;
        [SerializeField] private PizzaPlacementPresenter pizzaPlacementPresenter;
        [SerializeField] private PizzaArrangementView pizzaArrangementView;
        
        
        private void Start()
        {
            _pizzaPiecesModel = pizzaManager.GetPizzaPiecesModel();
            _pizzaPiecesModel.ClearMainPizzaPieces();
        }
        
        public void OnClickPizza(GameObject parentPizza)
        {
            // 重複判定
            foreach (Transform child in parentPizza.transform)
            {
                if (_pizzaPiecesModel.ContainsPizzaPiece(child.name))
                {
                    Debug.Log("重複してます。");
                    return;
                }
            }

            // メインピザに配置する、リストに追加する。
            combinedPizzaView.PutAllPizzaToMainPizza(parentPizza.transform, mainPizzaTransform);
            
            foreach (Transform child in parentPizza.transform)
            {
                _pizzaPiecesModel.AddPizzaPiece(child);
            }
            
            pizzaArrangementView.DeleteAllPizzaSlices();
            pizzaPlacementPresenter.PlacePizzas();
        }
    }
}