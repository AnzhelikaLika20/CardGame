using Models;
using UnityEngine;
using Views;

namespace Core
{
    public class CardLayout : MonoBehaviour
    {
        [SerializeField]public int LayoutId;
        [SerializeField]public Vector2 Offsеt;
        [SerializeField]private bool faceUp;


        private CardView GetCardView(CardInstance cardInstance)
        {
            return CardGame.Instance.GetCardView(cardInstance);
        }
        
        void Update()
        {
            var cardInstances = CardGame.Instance.GetCardsInLayout(LayoutId);
            foreach (var cardInstance in cardInstances)
            {
                var cardView = GetCardView(cardInstance);
                var cardTransform = (RectTransform)(cardView.transform);
                cardTransform.SetParent(transform, false);
                var vector = (cardInstance.CardPosition - 1) * Offsеt;
                cardTransform.anchoredPosition = vector;
                cardTransform.SetSiblingIndex(cardInstance.CardPosition);
                Rotate(faceUp, cardView);
            }
        
        }

        private void Rotate(bool up, CardView cardView)
        {
            cardView.Rotate(up);
        }
    }
}
