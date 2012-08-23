using System.Collections.Generic;

class Deck {

    private List<Card> Cards;

    public Deck() {
        Cards = new List<Card>();
    }

    public void add(Card Card) {
        if (Cards.Contains(Card)) {
            throw new DeckIntegrityException("Cannot contain the same card twice!");
        } else {
            Cards.Add(Card);
        }
    }

    public int size() {
        return Cards.Length;
    }

    public void populate() {
        var Suits = new Suit[] {
            Suit::Spades(),
            Suit::Hearts(),
            Suit::Clubs(),
            Suit::Diamonds(),
        };

        foreach (var Suit in Suits) {
            Cards.Add(Cards::aceOf(Suit));
            Cards.Add(Cards::twoOf(Suit));
            Cards.Add(Cards::threeOf(Suit));
            Cards.Add(Cards::fourOf(Suit));
            Cards.Add(Cards::fiveOf(Suit));
            Cards.Add(Cards::sixOf(Suit));
            Cards.Add(Cards::sevenOf(Suit));
            Cards.Add(Cards::eightOf(Suit));
            Cards.Add(Cards::nineOf(Suit));
            Cards.Add(Cards::tenOf(Suit));
            Cards.Add(Cards::jackOf(Suit));
            Cards.Add(Cards::queenOf(Suit));
            Cards.Add(Cards::kingOf(Suit));
        }
    }

    public Card[] getCards() {
        return Cards.ToArray();
    }
}