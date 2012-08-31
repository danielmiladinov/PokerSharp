using PokerSharp.Cards;
using PokerSharp.Hands;

namespace PokerSharp.HandBuilders {
    class RoyalFlushSpecification : StraightFlushSpecification {

        public override bool isSatisfiedBy(Hand Hand) {
            var handIsARoyalFlush = (
                (Hand.getHighCard().getFaceValue() == Card.ACE) &&
                base.isSatisfiedBy(Hand)
            );

            return handIsARoyalFlush;
        }

        public override Hand newHand(Hand Hand) {
            var StraightFlush = base.newHand(Hand);

            if (StraightFlush is StraightFlush && StraightFlush.getHighCard().getFaceValue() == Card.ACE) {
                return new RoyalFlush(StraightFlush.getCards());
            }

            return null;
        }
    }
}