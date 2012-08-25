using System.Collections.Generic;

class StraightFlushSpecification : HandSpecification {

    public override bool isSatisfiedBy(Hand Hand) {
        return newHand(Hand) is StraightFlush;
    }

    public override Hand newHand(Hand Hand) {
        var SpadesCards = new List<Card>();
        var HeartsCards = new List<Card>();
        var ClubsCards = new List<Card>();
        var DiamondsCards = new List<Card>();

        var Cards = Hand.getCards().Sort((Card1, Card2) => { return Card1.compareTo(Card2); });

        foreach (var Card in Cards) {
            switch (Card.getSuit()) {
                case Suit::SPADES:
                    if (canAddCardTo(SpadesCards, Card)) {
                        SpadesCards.Add(Card);
                        if (count(SpadesCards) == 5) {
                            return new StraightFlush(SpadesCards);
                        }
                    }
                    break;

                case Suit::HEARTS:
                    if (canAddCardTo(HeartsCards, Card)) {
                        HeartsCards.Add(Card);
                        if (count(HeartsCards) == 5) {
                            return new StraightFlush(HeartsCards);
                        }
                    }
                    break;

                case Suit::CLUBS:
                    if (canAddCardTo(ClubsCards, Card)) {
                        ClubsCards.Add(Card);
                        if (count(ClubsCards) == 5) {
                            return new StraightFlush(ClubsCards);
                        }
                    }
                    break;

                case Suit::DIAMONDS:
                    if (canAddCardTo(DiamondsCards, Card)) {
                        DiamondsCards.Add(Card);
                        if (count(DiamondsCards) == 5) {
                            return new StraightFlush(DiamondsCards);
                        }
                    }
                    break;
            }
        }

        return null;
    }

    private bool canAddCardTo(List<Card> Cards, Card Card) {
        numCards = Cards.Count;

        if (numCards > 0) {
            PreviousCard = Cards.toArray()[numCards - 1];

            if (PreviousCard.isAce() && Card.getFaceValue() == 5) {
                return true;
            } else if (PreviousCard.getFaceValue() - 1 == Card.getFaceValue()) {
                return true;
            }  else {
                return false;
            }
        } else {
            return true;
        }
    }
}