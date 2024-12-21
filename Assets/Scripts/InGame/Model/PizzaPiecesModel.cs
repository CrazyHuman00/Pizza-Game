using System.Collections.Generic;
using UnityEngine;

namespace InGame.Model
{
    /// <summary>
    /// なんのピザのピースを持っているかの情報。
    /// </summary>
    public class PizzaPiecesModel
    {
        [System.Serializable]
        public struct PizzaPieceData
        {
            public GameObject pizzaPiecesObject;
            public string pizzaPiecesName;
        }
        
        private List<PizzaPieceData> _pieces;

        public PizzaPiecesModel()
        {
            _pieces = new List<PizzaPieceData>();
        }

        public void SetPizzaPieces(GameObject pizzaPieceObject, string pizzaPieceName)
        {
            var newPizzaPiece = new PizzaPieceData
            {
                pizzaPiecesObject = pizzaPieceObject,
                pizzaPiecesName = pizzaPieceName
            };
            _pieces.Add(newPizzaPiece);
        }

        public IEnumerable<PizzaPieceData> GetPizzaPieces()
        {
            return _pieces;
        }
    }
}