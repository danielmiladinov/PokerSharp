using PokerSharp.Hands;

namespace PokerSharp.HandBuilders {
    abstract class HandSpecification {

        public abstract bool isSatisfiedBy(Hand Hand);

        public abstract Hand newHand(Hand Hand);
    }
}