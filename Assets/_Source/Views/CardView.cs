using Models;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Views
{
    public class CardView : MonoBehaviour, IPointerDownHandler
    {
        private CardInstance _cardInstance;

        [SerializeField] GameObject cardBack;
        [SerializeField] private GameObject cardFront;
        [SerializeField]private int fieldLayout;
        public void Init(CardInstance cardInstance)
        {
            _cardInstance = cardInstance;
            var image = cardFront.GetComponent<Image>();
            image.color = _cardInstance.CardAsset.cardColor;
            image.sprite = _cardInstance.CardAsset.cardImage;
            image.name = _cardInstance.CardAsset.cardName;
        }

        public void Rotate(bool up)
        {
            cardBack.SetActive(!up);
            cardFront.SetActive(up);
        }

        private void PlayCard()
        {
            _cardInstance.MoveToLayout(fieldLayout);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            PlayCard();
        }
    }
}