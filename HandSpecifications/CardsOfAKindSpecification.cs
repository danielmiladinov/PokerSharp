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
        var GroupedByValue = Hand.getCardsGroupedByValues();
        var faceValueCounts = new Dictionary<int, int>();

        foreach (KeyValuePair<int, List<Card>> cardsAndValue in GroupedByValue) {
            faceValueCounts.Add(cardsAndValue.Key, cardsAndValue.Value.Count);
        }

        int highestCount = 0;
        foreach (KeyValuePair<int, int> faceValueAndCount in faceValueCounts) {
            if (faceValueAndCount.Value > highestCount) {
                highestCount = faceValueAndCount.Value;
            }
        }

        return highestCount == numberOfCards;
    }

    public override Hand newHand(Hand Hand) {
        return null;
    }
}