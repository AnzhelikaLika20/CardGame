using _ScriptableObjects;

namespace Models
{
    public class CardInstance
    {
        private CardAsset _cardAsset;
        public int LayoutId;
        public int CardPosition;
        public CardInstance(CardAsset cardAsset)
        {
            _cardAsset = cardAsset;
        }

        public void MoveToLayout(int layoutId)
        {
            LayoutId = layoutId;
            //как ставить позицию
            CardPosition = 0;
        }
    }
}