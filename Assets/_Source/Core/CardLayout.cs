using System.Collections;
using System.Collections.Generic;
using Core;
using Models;
using UnityEngine;
using UnityEngine.TextCore;
using Views;

public class CardLayout : MonoBehaviour
{
    [SerializeField]public int LayoutId;
    [SerializeField]public Vector2 Offsеt;
    private bool _faceUp;


    private CardView GetCardView(CardInstance cardInstance)
    {
        return CardGame.Instance.GetCardView(cardInstance);
    }

    private Vector2 GetCardPosition(CardInstance cardInstance)
    {
        var rectTransform = GetComponent<RectTransform>().rect;
        var widthMove = rectTransform.width / 2;
        var heightMove = rectTransform.height / 2;
        var absolutePos = cardInstance.CardPosition * Offsеt;
        return new Vector2(absolutePos.x - widthMove, absolutePos.y - heightMove);
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
            Rotate(false, cardView);
        }
        
    }

    private void Rotate(bool up, CardView cardView)
    {
        _faceUp = up;
        cardView.Rotate(up);
    }
}
