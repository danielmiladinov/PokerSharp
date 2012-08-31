namespace PokerSharp.Cards {
    abstract class Card {
        public const int TWO = 2;
        public const int THREE = 3;
        public const int FOUR = 4;
        public const int FIVE = 5;
        public const int JACK = 11;
        public const int QUEEN = 12;
        public const int KING = 13;
        public const int ACE = 14;
        protected int faceValue;
        protected Suit Suit;

        public Card (int faceValue = 0) {
            this.faceValue = faceValue;
        }

        public int getFaceValue() {
            return faceValue;
        }

        public string getSuit() {
            return Suit.getName();
        }

        public int getSuitValue() {
            return Suit.getValue();
        }

        public bool isAce() {
            return faceValue == ACE;
        }

        public override string ToString() {
            string faceValue;

            switch (getFaceValue()) {
                case ACE:
                    faceValue = "A";
                    break;
                case KING:
                    faceValue = "K";
                    break;
                case QUEEN:
                    faceValue = "Q";
                    break;
                case JACK:
                    faceValue = "J";
                    break;
                default:
                    faceValue = getFaceValue().ToString();
                    break;
            }

            return faceValue + '-' + getSuit()[0];
        }

        public int compareTo(Card OtherCard) {
            int comparison;

            if (getFaceValue() == OtherCard.getFaceValue()) {
                comparison = compareSuit(OtherCard);
            } else {
                comparison = compareFaceValue(OtherCard);
            }

            return comparison;
        }

        public int compareSuit(Card OtherCard) {
            return OtherCard.getSuitValue() - getSuitValue();
        }

        public int compareFaceValue(Card OtherCard) {
            return OtherCard.getFaceValue() - getFaceValue();
        }

        public override bool Equals(object obj) {
            Card cardObj = obj as Card;

            if (cardObj == null) {
                return false;
            } else {
                return compareTo(cardObj) == 0;
            }
        }

        public override int GetHashCode() {
            return ToString().GetHashCode();
        }
    }
}
