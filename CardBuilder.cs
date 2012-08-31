using System;

namespace PokerSharp {
    using PokerSharp.Cards;

    class CardBuilder {

        public Card fromString(string cardString) {
            var cardStringAsArray = cardString.Split("-".ToCharArray());

            if (cardStringAsArray.Length != 2) {
                throw new CardBuilderException("Invalid card string");
            }

            var faceValue = cardStringAsArray[0];
            var suit = cardStringAsArray[1];

            var faceValueIntValue = convertValueFromLetterToNumber(faceValue);

            if (faceValueIntValue > Card.ACE || faceValueIntValue < 2) {
                throw new CardBuilderException("Invalid face value");
            }

            Card c;

            switch (suit) {
                case "D":
                    c = new Diamonds(faceValueIntValue);
                    break;

                case "H":
                    c = new Hearts(faceValueIntValue);
                    break;

                case "S":
                    c = new Spades(faceValueIntValue);
                    break;

                case "C":
                    c = new Clubs(faceValueIntValue);
                    break;

                default:
                    throw new CardBuilderException("Invalid suit");
            }

            return c;
        }

        private int convertValueFromLetterToNumber(string faceValue) {
            int faceValueIntValue = 0;

            switch (faceValue) {
                case "A":
                    faceValueIntValue = Card.ACE;
                    break;

                case "J":
                    faceValueIntValue = Card.JACK;
                    break;

                case "Q":
                    faceValueIntValue = Card.QUEEN;
                    break;

                case "K":
                    faceValueIntValue = Card.KING;
                    break;

                default:
                    int parsed = 0;

                    if (Int32.TryParse(faceValue, out parsed)) {
                        faceValueIntValue = parsed;
                    }
                    break;
            }

            return faceValueIntValue;
        }
    }
}