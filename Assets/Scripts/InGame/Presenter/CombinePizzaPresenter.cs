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
        [SerializeField] private PizzaPlacementPresenter pizzaPlacementPresenter;
        [SerializeField] private PizzaArrangementView pizzaArrangementView;
        [SerializeField] private PizzaManager pizzaManager;
        
        
        private void Start()
        {
            _pizzaPiecesModel = new PizzaPiecesModel();
            _pizzaPiecesModel.ClearMainPizzaPieces();
            InitializePizzaPieces();
        }
        
        private void InitializePizzaPieces()
        {
            // Initialize pizza pieces from PizzaManager
            var allPizzaPieces = pizzaManager.GetSubPizzas();
            foreach (var piece in allPizzaPieces)
            {
                _pizzaPiecesModel.SetMainPizzaPieces(piece.transform);
            }
        }
        
        public void OnClickPizza(GameObject parentPizza)
        {
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
            _pizzaPiecesModel.SetMainPizzaPieces(parentPizza.transform);
            
            // サブピザを更新する。
            pizzaArrangementView.DeleteAllPizzaSlices();
            pizzaPlacementPresenter.PlacePizzas();
        }
    }
}