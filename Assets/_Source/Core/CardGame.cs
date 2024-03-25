using System.Collections.Generic;
using System.Linq;
using _ScriptableObjects;
using Models;
using UnityEngine;
using Views;

namespace Core
{
    public class CardGame : MonoBehaviour
    {
        private static CardGame _instance;
        private readonly Dictionary<CardInstance, CardView> _cards = new();
        [SerializeField] private List<CardAsset> cardAssets = new();
        [SerializeField] private GameObject cardPrefab;
        [SerializeField] private List<int> layouts = new();
        [SerializeField] public int handCapacity;
        [SerializeField] private List<CardAsset> deckAssets;
        [SerializeField] private int deckLayout;

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
            InitDeck();
            foreach (var layout in layouts)
            {
                foreach (var cardAsset in cardAssets)
                {
                    CreateCard(cardAsset, layout);
                }
            }
        }

        private void InitDeck()
        {
            foreach (var card in deckAssets)
            {
                CreateCard(card, deckLayout);
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
            MoveToLayout(layoutId, cardInstance);
        }

        public List<CardInstance> GetCardsInLayout(int layoutId)
        {
            return _cards
                .Select(x => x.Key)
                .Where(x => x.LayoutId == layoutId)
                .OrderBy(x => x.CardPosition)
                .ToList();
        }

        public CardView GetCardView(CardInstance cardInstance)
        {
            return _cards[cardInstance];
        }

        public void RecalculateLayout(int layoutId)
        {
            var cards = GetCardsInLayout(layoutId);
            int newPosition = 1;
            foreach (var card in cards)
            {
                card.CardPosition = newPosition++;
            }
        }
        
        private void MoveToLayout(int layoutId, CardInstance cardInstance)
        {
            var layout = cardInstance.LayoutId;
            cardInstance.MoveToLayout(layoutId);
            RecalculateLayout(layout);
        }

        public void StartTurn()
        {
            foreach (var layout in layouts)
            {
                var playerCards = GetCardsInLayout(layout);
                var deckCards = GetCardsInLayout(deckLayout);
                int i = 0;
                while (playerCards.Count + i < handCapacity)
                {
                    if (deckCards.Count == 0)
                        break;
                    MoveToLayout(layout, deckCards[0]);
                    deckCards.Remove(deckCards[0]);
                    i++;
                }
            }
        }

        public void ShuffleLayout(int layoutId)
        {
            var cards = GetCardsInLayout(layoutId);
            foreach (var t in cards)
            {
                var index = UnityEngine.Random.Range(0, cards.Count);
                (t.CardPosition, cards[index].CardPosition) = (cards[index].CardPosition, t.CardPosition);
            }
        }
    }
}