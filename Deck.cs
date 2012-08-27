using System.Linq;
using System.Collections.Generic;

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
            cards.Add(Cards.aceOf(suit));
            cards.Add(Cards.twoOf(suit));
            cards.Add(Cards.threeOf(suit));
            cards.Add(Cards.fourOf(suit));
            cards.Add(Cards.fiveOf(suit));
            cards.Add(Cards.sixOf(suit));
            cards.Add(Cards.sevenOf(suit));
            cards.Add(Cards.eightOf(suit));
            cards.Add(Cards.nineOf(suit));
            cards.Add(Cards.tenOf(suit));
            cards.Add(Cards.jackOf(suit));
            cards.Add(Cards.queenOf(suit));
            cards.Add(Cards.kingOf(suit));
        }
    }

    public List<Card> getCards() {
        return cards;
    }
}