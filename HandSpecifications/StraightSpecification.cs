using System.Collections.Generic;
using PokerSharp.Cards;
using PokerSharp.Hands;

namespace PokerSharp.HandBuilders {
    class StraightSpecification : HandSpecification {

        public override bool isSatisfiedBy(Hand Hand) {
            return newHand(Hand) is Straight;
        }

        public override Hand newHand(Hand Hand) {
            var StraightCards = new List<Card>();
            Card PreviousCard = null;

            var Cards = Hand.getCards();
            Cards.Sort((Card1, Card2) => { return Card1.compareTo(Card2); });

            foreach (var Card in Cards) {
                if (PreviousCard is Card) {
                    if (Card.compareFaceValue(PreviousCard) == 0) {
                        continue;
                    } else if (PreviousCard.isAce() && Card.getFaceValue() == 5) { // Wheels are Straights too, you know
                        StraightCards.Add(Card);
                    } else if (PreviousCard.getFaceValue() - 1 == Card.getFaceValue()) {
                        StraightCards.Add(Card);
                    } else {
                        StraightCards = new List<Card> { Card };
                    }
                } else {
                    StraightCards.Add(Card);
                }

                PreviousCard = Card;
                if (StraightCards.Count == 5) {
                    return new Straight(StraightCards);
                }
            }

            return null;
        }
    }
}