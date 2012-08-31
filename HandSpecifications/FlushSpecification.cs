using System.Collections.Generic;
using PokerSharp.Cards;
using PokerSharp.Hands;

namespace PokerSharp.HandBuilders {
    class FlushSpecification : HandSpecification {

        public override bool isSatisfiedBy(Hand Hand) {
            return newHand(Hand) is Flush;
        }

        public override Hand newHand(Hand Hand) {
            var SpadesCards = new List<Card>();
            var HeartsCards = new List<Card>();
            var ClubsCards = new List<Card>();
            var DiamondsCards = new List<Card>();

            foreach (var Card in Hand.getCards()) {
                switch (Card.getSuit()) {
                    case Suit.SPADES:
                        SpadesCards.Add(Card);
                        if (SpadesCards.Count == 5) {
                            return new Flush(SpadesCards);
                        }
                        break;

                    case Suit.HEARTS:
                        HeartsCards.Add(Card);
                        if (HeartsCards.Count == 5) {
                            return new Flush(HeartsCards);
                        }
                        break;

                    case Suit.CLUBS:
                        ClubsCards.Add(Card);
                        if (ClubsCards.Count == 5) {
                            return new Flush(ClubsCards);
                        }
                        break;

                    case Suit.DIAMONDS:
                        DiamondsCards.Add(Card);
                        if (DiamondsCards.Count == 5) {
                            return new Flush(DiamondsCards);
                        }
                        break;
                }
            }

            return null;
        }
    }
}