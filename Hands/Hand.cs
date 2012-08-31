using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using PokerSharp.Cards;

namespace PokerSharp.Hands {
    class Hand {

        private List<Card> cards;

        public Hand(List<Card> Cards) {
            cards = Cards;
        }

        public List<Card> getCards() {
            return cards;
        }

        public Card getHighCard() {
            Card HighCard = null;

            if (isWheel()) {
                HighCard = (from card in cards where card.getFaceValue() == 5 select card).First();
            } else {
                HighCard = (from card in cards orderby card.getFaceValue() descending select card).First();
            }

            return HighCard;
        }

        public Dictionary<int, List<Card>> getCardsGroupedByValues() {
            return CardMaker.getCardsGroupedByValue(getCards());
        }

        public override bool Equals(object obj) {
            Hand OtherHand = obj as Hand;

            if (OtherHand == null) {
                return false;
            } else {
                var CardsNotInOtherHand = OtherHand.getCards().Except(cards);
                var handsAreEqual = (CardsNotInOtherHand.Count() == 0);
                return handsAreEqual;
            }
        }

        public override int GetHashCode() {
            var faceValuesSum = cards.Sum(card => card.getFaceValue());
            var suitValuesSum = cards.Sum(card => card.getSuitValue());
            return faceValuesSum * suitValuesSum;
        }

        public bool isWheel() {
            return (
                cards.Count == 5 &&
                hasCardOfFaceValue(Card.FIVE) &&
                hasCardOfFaceValue(Card.FOUR) &&
                hasCardOfFaceValue(Card.THREE) &&
                hasCardOfFaceValue(Card.TWO) &&
                hasCardOfFaceValue(Card.ACE)
            );
        }

        public override string ToString() {
            var handString = new StringBuilder();
            handString.Append(getHandName());
            handString.Append("(");
            handString.Append(String.Join(", ", (from card in cards select card.ToString())));
            handString.Append(")");
            return handString.ToString();
        }

        protected string getHandName() {
            var handName = new StringBuilder();
            var className = GetType().Name;

            foreach (var c in className) {
                if (char.IsUpper(c) && handName.Length > 0) {
                    handName.Append(" ");
                }
                handName.Append(c);
            }

            return handName.ToString();
        }

        private bool hasCardOfFaceValue(int faceValue) {
            return (from card in cards where card.getFaceValue() == faceValue select card).Count() > 0;
        }
    }
}