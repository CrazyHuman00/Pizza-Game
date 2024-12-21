using UnityEngine;
using InGame.Model;
using InGame.View;
using UnityEngine.Serialization;

namespace InGame.Presenter
{
    /// <summary>
    /// ピザを組み合わせるときに使うPresenter。
    /// modelからピザのピース情報を取得し、メイン配置したものに配置できるかを確かめる。
    /// 配置が可能ならば、viewに反映させピザを配置し、modelを更新する。
    /// </summary>
    public class CombinePizzaPresenter : MonoBehaviour
    {
        private PizzaPiecesModel _pizzaPiecesModel;
        [SerializeField] private CombinedPizzaView combinedPizzaView;
        [SerializeField] private Transform mainPizzaTransform;

        private void Start()
        {
            _pizzaPiecesModel = new PizzaPiecesModel();
            InitializePizzaPieces();
        }

        private void InitializePizzaPieces()
        {
            foreach (Transform child in this.transform)
            {
                var o = child.gameObject;
                _pizzaPiecesModel.SetPizzaPieces(o, o.name);
                
            }
        }
        
        public void OnClickPizza(GameObject parentPizza)
        {
            combinedPizzaView.PutAllPizzaToMainPizza(parentPizza.transform, mainPizzaTransform);
        }
    }
    
}