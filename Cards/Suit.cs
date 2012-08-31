using System;

namespace PokerSharp.Cards {
    class Suit {
        public const string CLUBS = "Clubs";
        public const string HEARTS = "Hearts";
        public const string SPADES = "Spades";
        public const string DIAMONDS = "Diamonds";
        private string suitName;
        private int suitValue;

        private Suit (string suitName, int suitValue) {
            this.suitName = suitName;
            this.suitValue = suitValue;
        }

        public static Suit Spades() {
            return new Suit(SPADES, 4);
        }

        public static Suit Hearts() {
            return new Suit(HEARTS, 3);
        }

        public static Suit Clubs() {
            return new Suit(CLUBS, 2);
        }

        public static Suit Diamonds() {
            return new Suit(DIAMONDS, 1);
        }

        public string getName() {
            return suitName;
        }

        public int getValue() {
            return suitValue;
        }

        public Card getCard(int cardValue) {
            switch (suitName) {
                case SPADES:
                    return new Spades(cardValue);
                case HEARTS:
                    return new Hearts(cardValue);
                case CLUBS:
                    return new Clubs(cardValue);
                case DIAMONDS:
                    return new Diamonds(cardValue);
                default:
                    return null;
            }
        }
    }
}