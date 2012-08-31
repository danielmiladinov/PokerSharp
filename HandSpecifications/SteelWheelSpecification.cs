using PokerSharp.Hands;

namespace PokerSharp.HandBuilders {
    class SteelWheelSpecification : StraightFlushSpecification {

        public override bool isSatisfiedBy(Hand Hand) {
            return base.isSatisfiedBy(Hand) && Hand.isWheel();
        }

        public override Hand newHand(Hand Hand) {
            var StraightFlush = base.newHand(Hand);

            if (StraightFlush is Hand && StraightFlush.isWheel()) {
                return new SteelWheel(StraightFlush.getCards());
            } else {
                return null;
            }
        }
    }
}