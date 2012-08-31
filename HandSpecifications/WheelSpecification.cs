using PokerSharp.Hands;

namespace PokerSharp.HandBuilders {
    class WheelSpecification : StraightSpecification {

        public override bool isSatisfiedBy(Hand Hand) {
            return Hand.isWheel();
        }

        public override Hand newHand(Hand Hand) {
            var Straight = base.newHand(Hand);

            if (Straight is Hand && Straight.isWheel()) {
                return new Wheel(Straight.getCards());
            } else {
                return null;
            }
        }
    }
}