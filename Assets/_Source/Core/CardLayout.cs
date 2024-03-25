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

        private Vector2 GetCardPosition(CardInstance cardInstance)
        {
            var rect = GetComponent<RectTransform>().rect;
            var widthMove = rect.width / 2;
            var absolutePos = cardInstance.CardPosition * Offsеt;
            return new Vector2(absolutePos.x - widthMove, absolutePos.y);
        }
        void Update()
        {
            var cardInstances = CardGame.Instance.GetCardsInLayout(LayoutId);
            foreach (var cardInstance in cardInstances)
            {
                var cardView = GetCardView(cardInstance);
                Transform cardViewTransform = cardView.transform;
                cardViewTransform.SetParent(transform);
                cardViewTransform.localPosition = GetCardPosition(cardInstance);
                cardViewTransform.SetSiblingIndex(cardInstance.CardPosition);
                Rotate(faceUp, cardView);
            }
        
        }

        private void Rotate(bool up, CardView cardView)
        {
            cardView.Rotate(up);
        }
    }
}
