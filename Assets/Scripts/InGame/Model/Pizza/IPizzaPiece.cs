using UnityEngine;

namespace InGame.Model.Pizza
{
    public interface IPizzaPiece
    {
        public void SetMainPizzaPieces(Transform parentTransform);

        public void AddPizzaPiece(Transform pizzaPiece);

        public bool ContainsPizzaPiece(string pizzaPieceName);

        public void ClearMainPizzaPieces();
    }
}