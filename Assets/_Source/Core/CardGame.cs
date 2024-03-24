using System.Collections.Generic;
using _ScriptableObjects;
using Models;
using UnityEngine;
using Views;

namespace Core
{
    public class CardGame : MonoBehaviour
    {
        private static CardGame _instance;
        private Dictionary<CardInstance, CardView> _cards = new();
        [SerializeField]private List<CardAsset> cardAssets = new();
        [SerializeField]private GameObject cardPrefab;
        [SerializeField]private List<int> _layouts = new();

        public static CardGame Instance
        {
            get => _instance;
            set
            {
                if (_instance == null)
                {
                    _instance = value;
                }
            }
        }

        private void Start()
        {
            StartGame();
        }

        private void Awake()
        {
            _instance = this;
        }

        private void StartGame()
        {
            foreach (var layout in _layouts)
            {
                foreach (var cardAsset in cardAssets)
                {
                    CreateCard(cardAsset, layout);
                }
            }
        }

        private void CreateCardView(CardInstance cardInstance)
        {
            var cardView = Instantiate(cardPrefab, transform).GetComponent<CardView>();
            cardView.Init(cardInstance);
            _cards[cardInstance] = cardView;
        }
        

        private void CreateCard(CardAsset cardAsset, int layoutId)
        {
            var cardInstance = new CardInstance(cardAsset);
            CreateCardView(cardInstance);
            cardInstance.MoveToLayout(layoutId);
        }
    }
}