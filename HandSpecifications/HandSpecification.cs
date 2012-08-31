using PokerSharp.Hands;

abstract class HandSpecification {

    public abstract bool isSatisfiedBy(Hand Hand);

    public abstract Hand newHand(Hand Hand);
}