using System.Linq;
using System.Collections.Generic;
using PokerSharp.Cards;
using PokerSharp.Hands;

namespace PokerSharp.HandBuilders {
    class FullHouseSpecification : HandSpecification {

        public override bool isSatisfiedBy(Hand Hand) {
            return newHand(Hand) is FullHouse;
        }

        public override Hand newHand(Hand hand) {
            var handCards = new List<Card>();
            var groupedByValue = hand.getCardsGroupedByValues();
            var faceValueCounts = new Dictionary<int, int>();

            foreach (KeyValuePair<int, List<Card>> cardsOfValue in groupedByValue) {
                var faceValue = cardsOfValue.Key;
                var faceValueCount = cardsOfValue.Value.Count;

                if (faceValueCount >= 2) {
                    faceValueCounts[faceValue] = faceValueCount;
                }
            }

            if (faceValueCounts.Count >= 2) {
                faceValueCounts.Keys.ToList().Sort((x, y) => { return y - x; });

                var faceValue = faceValueCounts.First().Key;
                var faceValueCount = faceValueCounts.First().Value;

                if (faceValueCount == 3) {
                    handCards.AddRange(groupedByValue[faceValue]);
                    faceValueCounts.Remove(faceValue);

                    faceValue = faceValueCounts.First().Key;
                    faceValueCount = faceValueCounts.First().Value;

                    if (faceValueCount >= 2) {
                        handCards.AddRange(groupedByValue[faceValue].Take(2));
                        return new FullHouse(handCards);
                    }
                } else if (faceValueCount == 2) {
                    handCards.AddRange(groupedByValue[faceValue]);
                    faceValueCounts.Remove(faceValue);

                    faceValue = faceValueCounts.First().Key;
                    faceValueCount = faceValueCounts.First().Value;

                    if (faceValueCount == 3) {
                        handCards.AddRange(groupedByValue[faceValue].Take(3));
                        return new FullHouse(handCards);
                    }
                }
            }

            return null;
        }
    }
}