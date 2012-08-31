using System.Collections.Generic;
using PokerSharp.Cards;
using PokerSharp.Hands;
using PokerSharp.HandBuilders;

namespace PokerSharp {
    class BestHandIdentifier {

        public Hand identify(List<Card> Cards) {
            Cards.Sort((Card1, Card2) => { return Card1.compareTo(Card2); });
            Hand Hand = new Hand(Cards);

            HandSpecification[] SpecsInValueOrder = {
                new RoyalFlushSpecification(),
                new SteelWheelSpecification(),
                new StraightFlushSpecification(),
                new FourOfAKindSpecification(),
                new FullHouseSpecification(),
                new FlushSpecification(),
                new WheelSpecification(),
                new StraightSpecification(),
                new ThreeOfAKindSpecification(),
                new TwoPairSpecification(),
                new TwoOfAKindSpecification(),
            };

            foreach (HandSpecification Specification in SpecsInValueOrder) {
                if (Specification.isSatisfiedBy(Hand)) {
                    return Specification.newHand(Hand);
                }
            }

            return new HighCard(Cards);
        }
    }
}