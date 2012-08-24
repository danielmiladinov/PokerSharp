using System;
using System.Collections.Generic;

abstract class CardsOfAKindSpecification : HandSpecification {

    protected int numberOfCards;
    protected Type handClass;

    protected CardsOfAKindSpecification(int numberOfCards, Type handClass) {
        this.numberOfCards = numberOfCards;
        this.handClass = handClass;
    }

    public override bool isSatisfiedBy(Hand Hand) {
        GroupedByValue = Hand.getCardsGroupedByValues();
        var faceValueCounts = new Dictionary<int, int>();

        foreach (KeyValuePair<int, List<Card>> cardsAndValue in GroupedByValue) {
            faceValueCounts.Add(cardsAndValue.Key, cardsAndValue.Value.Count);
        }

        var highestCount = (from count in faceValueCounts orderby count descending select count).First();
        return highestCount == numberOfCards;
    }

    public override Hand newHand(Hand Hand) {
        return null;
    }
}