abstract class Card {
    const int TWO = 2;
    const int THREE = 3;
    const int FOUR = 4;
    const int FIVE = 5;
    const int JACK = 11;
    const int QUEEN = 12;
    const int KING = 13;
    const int ACE = 14;

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

    public function getSuitValue() {
        return Suit.getValue();
    }

    public bool isAce() {
        return faceValue == Card::ACE;
    }

    public override string ToString() {
        string faceValue;

        switch (getFaceValue()) {
            case self::ACE:
                faceValue = "A";
                break;
            case self::KING:
                faceValue = "K";
                break;
            case self::QUEEN:
                faceValue = "Q";
                break;
            case self::JACK:
                faceValue = "J";
                break;
            default:
                faceValue = getFaceValue();
                break;
        }

        return faceValue + '-'  + getSuit();
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
}