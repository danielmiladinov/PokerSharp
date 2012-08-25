class TwoPairSpecification : HandSpecification {

    public override bool isSatisfiedBy(Hand Hand) {
        int numPairsSeen = 0;
        var CardsGroupedByValues = Hand.getCardsGroupedByValues();
        foreach (var Cards in CardsGroupedByValues) {
            if (Cards.Count == 2) {
                numPairsSeen++;
            }
        }

        var canMakeTwoPair = (2 == numPairsSeen);
        return canMakeTwoPair;
    }

    public override Hand newHand(Hand Hand) {
        return new TwoPair(Hand.getCards());
    }
}