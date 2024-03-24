using Models;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class CardView : MonoBehaviour
    {
        private CardInstance _cardInstance;

        [SerializeField] GameObject _cardBack;
        [SerializeField] GameObject _cardFront;
        public void Init(CardInstance cardInstance)
        {
            _cardInstance = cardInstance;
            var image = _cardFront.GetComponent<Image>();
            image.color = _cardInstance.CardAsset.cardColor;
            image.sprite = _cardInstance.CardAsset.cardImage;
            image.name = _cardInstance.CardAsset.cardName;
        }

        public void Rotate(bool up)
        {
            _cardBack.SetActive(!up);
            _cardFront.SetActive(up);
        }
    }
}