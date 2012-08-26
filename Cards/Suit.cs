using System;

class Suit {
    const string CLUBS = "Clubs";
    const string HEARTS = "Hearts";
    const string SPADES = "Spades";
    const string DIAMONDS = "Diamonds";

    private string suitName;
    private int suitValue;

    private Suit(string suitName, int suitValue) {
        this.suitName = suitName;
        this.suitValue = suitValue;
    }

    public static Suit Spades() {
        return new Suit(SPADES, 4);
    }

    public static Suit Hearts() {
        return new Suit(HEARTS, 3);
    }

    public static Suit Clubs() {
        return new Suit(CLUBS, 2);
    }

    public static Suit Diamonds() {
        return new Suit(DIAMONDS, 1);
    }

    public string getName() {
        return suitName;
    }

    public int getValue() {
        return suitValue;
    }

    public Card getCard(int cardValue) {
        return (Card) Activator.CreateInstance(GetType(), new {cardValue});
    }
}