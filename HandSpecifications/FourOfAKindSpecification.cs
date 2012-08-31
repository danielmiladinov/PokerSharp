using System;
using System.Linq;
using System.Collections.Generic;
using PokerSharp.Cards;
using PokerSharp.Hands;

namespace PokerSharp.HandBuilders {
    class FourOfAKindSpecification : CardsOfAKindSpecification {

        public FourOfAKindSpecification() : base(4, typeof(FourOfAKind)) {
        }

        public override Hand newHand(Hand hand) {
            var groupedByValue = hand.getCardsGroupedByValues();
            var highestValue = groupedByValue.First().Value;
            groupedByValue.Remove(groupedByValue.First().Key);
            var handCards = new List<Card>();

            if (highestValue.Count == numberOfCards) {
                handCards.AddRange(highestValue);
                handCards.AddRange(groupedByValue.First().Value.Take(1));
            } else {
                handCards.AddRange(highestValue.Take(1));

                while (groupedByValue.Count > 0 && handCards.Count < 5) {
                    var cardsOfValue = groupedByValue.First().Value;
                    groupedByValue.Remove(groupedByValue.First().Key);

                    if (cardsOfValue.Count == numberOfCards) {
                        handCards.AddRange(cardsOfValue);
                    }
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