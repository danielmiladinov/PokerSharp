using System;
using System.Linq;
using System.Collections.Generic;
using PokerSharp.Cards;
using PokerSharp.Hands;

namespace PokerSharp.HandBuilders {
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

        public override Hand newHand(Hand hand) {
            var groupedByValue = hand.getCardsGroupedByValues();
            var handCards = groupedByValue.First().Value;
            groupedByValue.Remove(groupedByValue.First().Key);

            if (handCards.Count == numberOfCards) {
                handCards.Add(groupedByValue.First().Value.First());
                groupedByValue.Remove(groupedByValue.First().Key);
            } else {
                handCards.AddRange(
                    groupedByValue.Where(
                        cardsOfValue => {
                    return cardsOfValue.Value.Count == numberOfCards;
                }
                    ).First().Value
                );
            }

            int cardsLeftToAdd = 5 - handCards.Count;

            while (cardsLeftToAdd > 0 && groupedByValue.Count > 0) {
                var cardsOfValue = groupedByValue.First().Value;
                groupedByValue.Remove(groupedByValue.First().Key);

                while (cardsLeftToAdd > 0 && cardsOfValue.Count > 0) {
                    var nextCard = cardsOfValue.First();
                    cardsOfValue.Remove(nextCard);
                    handCards.Add(nextCard);
                    cardsLeftToAdd--;
                }
            }

            if (handCards.Count == 5) {
                return (Hand) Activator.CreateInstance(handClass, new object[] { handCards });
            } else {
                return null;
            }
        }
    }
}