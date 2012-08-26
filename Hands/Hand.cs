using System.Linq;
using System.Collections.Generic;

class Hand {

    private List<Card> cards;

    public Hand(List<Card> Cards) {
        cards = Cards;
    }

    public List<Card> getCards() {
        return cards;
    }

    public Card getHighCard() {
        Card HighCard = null;

        if (isWheel()) {
            HighCard = (from card in cards where card.getFaceValue() == 5 select card).First();
        } else {
            HighCard = (from card in cards orderby card.getFaceValue() descending select card).First();
        }

        return HighCard;
    }

    public Dictionary<int, List<Card>> getCardsGroupedByValues() {
        return Cards.getCardsGroupedByValue(getCards());
    }

    public bool equals(Hand OtherHand) {
        var CardsNotInOtherHand = OtherHand.getCards().Except(cards);
        var handsAreEqual = (CardsNotInOtherHand.Count() == 0);
        return handsAreEqual;
    }

    public bool isWheel() {
        return (
            cards.Count == 5 &&
            hasCardOfFaceValue(Card.FIVE) &&
            hasCardOfFaceValue(Card.FOUR) &&
            hasCardOfFaceValue(Card.THREE) &&
            hasCardOfFaceValue(Card.TWO) &&
            hasCardOfFaceValue(Card.ACE)
        );
    }

    public override string ToString() {
        return "Fix Me When It Builds!";
    }

    protected string getHandType() {
        return "What's My Hand Type?";
    }

    private bool hasCardOfFaceValue(int faceValue) {
        return (from card in cards where card.getFaceValue() == faceValue select card).Count() > 0;
    }
}