using System.Linq;
using System.Collections.Generic;
using PokerSharp.Cards;

namespace PokerSharp {
    class Deck {

        private List<Card> cards;

        public Deck() {
            cards = new List<Card>();
        }

        public void add(Card card) {
            if (cards.Contains(card)) {
                throw new DeckIntegrityException("Cannot contain the same card twice!");
            } else {
                cards.Add(card);
            }
        }

        public int size() {
            return cards.Count;
        }

        public void populate() {
            var Suits = new Suit[] {
                Suit.Spades(),
                Suit.Hearts(),
                Suit.Clubs(),
                Suit.Diamonds(),
            };

            foreach (var suit in Suits) {
                cards.Add(CardMaker.aceOf(suit));
                cards.Add(CardMaker.twoOf(suit));
                cards.Add(CardMaker.threeOf(suit));
                cards.Add(CardMaker.fourOf(suit));
                cards.Add(CardMaker.fiveOf(suit));
                cards.Add(CardMaker.sixOf(suit));
                cards.Add(CardMaker.sevenOf(suit));
                cards.Add(CardMaker.eightOf(suit));
                cards.Add(CardMaker.nineOf(suit));
                cards.Add(CardMaker.tenOf(suit));
                cards.Add(CardMaker.jackOf(suit));
                cards.Add(CardMaker.queenOf(suit));
                cards.Add(CardMaker.kingOf(suit));
            }
        }

        public List<Card> getCards() {
            return cards;
        }
    }
}