using System.Linq;
using UnityEngine;
using InGame.Model;
using InGame.View;
using UnityEngine.Serialization;

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
        [SerializeField] private CombinedPizzaView combinedPizzaView;
        [SerializeField] private Transform mainPizzaTransform;
        [SerializeField] private PizzaManager pizzaManager;

        private void Start()
        {
            _pizzaPiecesModel = new PizzaPiecesModel();
            InitializePizzaPieces();
        }
        
        private void InitializePizzaPieces()
        {
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

            combinedPizzaView.PutAllPizzaToMainPizza(parentPizza.transform, mainPizzaTransform);
            _pizzaPiecesModel.SetMainPizzaPieces(parentPizza.transform);
            
        }
    }
}