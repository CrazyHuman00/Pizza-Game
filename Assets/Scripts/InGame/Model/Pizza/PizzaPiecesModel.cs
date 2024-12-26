using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace InGame.Model.Pizza
{
    /// <summary>
    /// なんのピザのピースを持っているかの情報。
    /// </summary>
    public class PizzaPiecesModel
    {
        /// <summary>
        /// PizzaPieceの構造体
        /// </summary>
        [System.Serializable]
        public struct PizzaPieceData
        {
            public GameObject pizzaPiecesPrefab;
            public string pizzaPiecesName;
        }
        
        
        /// <summary>
        /// メインピザのリスト。
        /// </summary>
        private readonly List<PizzaPieceData> _mainPizzaPiece = new();
        
        
        /// <summary>
        /// メインピザのリストを返す。
        /// </summary>
        /// <returns></returns>
        public List<PizzaPieceData> GetMainPizzaPieces()
        {
            return _mainPizzaPiece;
        }

        
        /// <summary>
        /// メインピザのリストに情報をセットする。
        /// </summary>
        /// <param name="parentTransform"></param>
        public void SetMainPizzaPieces(Transform parentTransform)
        {
            foreach (Transform child in parentTransform)
            {
                var newPizzaPiece = new PizzaPieceData
                {
                    pizzaPiecesPrefab = child.gameObject,
                    pizzaPiecesName = child.name,
                };
                _mainPizzaPiece.Add(newPizzaPiece);
            }
        }
        
        
        /// <summary>
        /// ピザの子オブジェクトをリストに追加する。
        /// </summary>
        /// <param name="pizzaPiece"></param>
        public void AddPizzaPiece(Transform pizzaPiece)
        {
            _mainPizzaPiece.Add(new PizzaPieceData
            {
                pizzaPiecesPrefab = pizzaPiece.gameObject,
                pizzaPiecesName = pizzaPiece.name
            });
        }
        
        
        /// <summary>
        /// リスト内に同じオブジェクトがあるかの判定。
        /// </summary>
        /// <param name="pizzaPieceName"></param>
        /// <returns></returns>
        public bool ContainsPizzaPiece(string pizzaPieceName)
        {
            return _mainPizzaPiece.Any(p => p.pizzaPiecesName == pizzaPieceName);
        }
        
        
        /// <summary>
        /// メインピザの削除。
        /// </summary>
        public void ClearMainPizzaPieces()
        {
            _mainPizzaPiece.Clear();
        }
    }
}