using _ScriptableObjects;
using Core;

namespace Models
{
    public class CardInstance
    {
        public CardAsset CardAsset { get; }
        public int LayoutId;
        public int CardPosition;
        public CardInstance(CardAsset cardAsset)
        {
            CardAsset = cardAsset;
        }

        public void MoveToLayout(int layoutId)
        {
            var oldLayout = LayoutId;
            LayoutId = layoutId;
            CardPosition = CardGame.Instance.GetCardsInLayout(layoutId).Count;
            CardGame.Instance.RecalculateLayout(layoutId);
            CardGame.Instance.RecalculateLayout(oldLayout);
        }
    }
}