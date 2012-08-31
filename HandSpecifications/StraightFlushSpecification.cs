using System.Collections.Generic;
using PokerSharp.Cards;
using PokerSharp.Hands;

namespace PokerSharp.HandBuilders {
    class StraightFlushSpecification : HandSpecification {

        public override bool isSatisfiedBy(Hand Hand) {
            return newHand(Hand) is StraightFlush;
        }

        public override Hand newHand(Hand Hand) {
            var SpadesCards = new List<Card>();
            var HeartsCards = new List<Card>();
            var ClubsCards = new List<Card>();
            var DiamondsCards = new List<Card>();

            var Cards = Hand.getCards();
            Cards.Sort((Card1, Card2) => { return Card1.compareTo(Card2); });

            foreach (var Card in Cards) {
                switch (Card.getSuit()) {
                    case Suit.SPADES:
                        if (canAddCardTo(SpadesCards, Card)) {
                            SpadesCards.Add(Card);
                            if (SpadesCards.Count == 5) {
                                return new StraightFlush(SpadesCards);
                            }
                        }
                        break;

                    case Suit.HEARTS:
                        if (canAddCardTo(HeartsCards, Card)) {
                            HeartsCards.Add(Card);
                            if (HeartsCards.Count == 5) {
                                return new StraightFlush(HeartsCards);
                            }
                        }
                        break;

                    case Suit.CLUBS:
                        if (canAddCardTo(ClubsCards, Card)) {
                            ClubsCards.Add(Card);
                            if (ClubsCards.Count == 5) {
                                return new StraightFlush(ClubsCards);
                            }
                        }
                        break;

                    case Suit.DIAMONDS:
                        if (canAddCardTo(DiamondsCards, Card)) {
                            DiamondsCards.Add(Card);
                            if (DiamondsCards.Count == 5) {
                                return new StraightFlush(DiamondsCards);
                            }
                        }
                        break;
                }
            }

            return null;
        }

        private bool canAddCardTo(List<Card> cards, Card Card) {
            var numCards = cards.Count;

            if (numCards > 0) {
                var PreviousCard = cards[cards.Count - 1];

                if (PreviousCard.isAce() && Card.getFaceValue() == 5) {
                    return true;
                } else if (PreviousCard.getFaceValue() - 1 == Card.getFaceValue()) {
                    return true;
                } else {
                    return false;
                }
            } else {
                return true;
            }
        }
    }
}