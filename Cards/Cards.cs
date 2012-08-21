using System.Collections.Generic;

/**
 * A handy container for getting a particular face value of a given suit.
 */
class Cards {
    
    public static Card aceOf(Suit Suit) {
        return Suit.getCard(Card::ACE);
    }

    public static Card twoOf(Suit Suit) {
        return Suit.getCard(2);
    }

    public static Card threeOf(Suit Suit) {
        return Suit.getCard(3);
    }

    public static Card fourOf(Suit Suit) {
        return Suit.getCard(4);
    }

    public static function fiveOf(Suit Suit) {
        return Suit.getCard(5);
    }

    public static function sixOf(Suit Suit) {
        return Suit.getCard(6);
    }

    public static function sevenOf(Suit Suit) {
        return Suit.getCard(7);
    }

    public static function eightOf(Suit Suit) {
        return Suit.getCard(8);
    }

    public static function nineOf(Suit Suit) {
        return Suit.getCard(9);
    }

    public static function tenOf(Suit Suit) {
        return Suit.getCard(10);
    }

    public static function jackOf(Suit Suit) {
        return Suit.getCard(Card::JACK);
    }

    public static function queenOf(Suit Suit) {
        return Suit.getCard(Card::QUEEN);
    }

    public static function kingOf(Suit Suit) {
        return Suit.getCard(Card::KING);
    }

    public static Dictionary<int, List<Card>> getCardsGroupedByValue(List<Card> Cards) {
        var CardsGroupedByValues = new Dictionary<int, List<Card>>();

        foreach (var Card in Cards) {
            if (! CardsGroupedByValues.ContainsKey(Card.getFaceValue())) {
                CardsGroupedByValues.Add(Card.getFaceValue(), new List<Card>());
            }

            CardsGroupedByValues.TryGetValue(Card.getFaceValue()).Add(Card);
        }

        return CardsGroupedByValues;
    }
}