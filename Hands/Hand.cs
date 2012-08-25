using System.Linq;
using System.Collections.Generic;

class Hand {

    private Card[] Cards;

    public Hand(Card[] Cards) {
        this.Cards = Cards;
    }

    public Card[] getCards() {
        return Cards;
    }

    public Card getHighCard() {
        Card HighCard = null;

        if (isWheel()) {
            HighCard = (from Card in Cards where Card.getFaceValue() == 5 select Card).First();
        } else {
            HighCard = (from Card in Cards orderby Card.getFaceValue() descending select Card).First();
        }

        return HighCard;
    }

    public Dictionary<int, List<Card>> getCardsGroupedByValues() {
        return Cards.getCardsGroupedByValue(getCards());
    }

    public bool equals(Hand OtherHand) {
        CardsNotInOtherHand = array_diff(getCards(), OtherHand->getCards());
        handsAreEqual = count(CardsNotInOtherHand) == 0;
        return handsAreEqual;
    }

    public bool isWheel() {
        return (
            Cards.Count == 5 &&
            hasCardOfFaceValue(Card::FIVE) &&
            hasCardOfFaceValue(Card::FOUR) &&
            hasCardOfFaceValue(Card::THREE) &&
            hasCardOfFaceValue(Card::TWO) &&
            hasCardOfFaceValue(Card::ACE)
        );
    }

    public override string ToString() {
        return "Fix Me When It Builds!";
    }

    protected string getHandType() {
        return "What's My Hand Type?";
    }

    private bool hasCardOfFaceValue(int faceValue) {
        return (from Card in Cards where Card.getFaceValue() == faceValue select Card).Count() > 0;
    }
}