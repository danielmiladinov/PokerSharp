class CardBuilder {

    public Card fromString(string cardString) {
        var cardStringAsArray = cardString.Split("-");

        if (cardStringAsArray.Length != 2) {
            throw new CardBuilderException("Invalid card string");
        }

        var faceValue = cardStringAsArray[0];
        var suit = cardStringAsArray[1];

        faceValue = convertValueFromLetterToNumber(faceValue);

        if (faceValue > Card::ACE || faceValue < 2) {
            throw new CardBuilderException("Invalid face value");
        }

        switch (suit) {
            case "D":
                Card = new Diamonds(faceValue);
                break;

            case "H":
                Card = new Hearts(faceValue);
                break;

            case "S":
                Card = new Spades(faceValue);
                break;

            case "C":
                Card = new Clubs(faceValue);
                break;

            default:
                throw new CardBuilderException("Invalid suit");
        }

        return Card;
    }

    private int convertValueFromLetterToNumber(string faceValue) {
        switch (faceValue) {
            case "A":
                faceValue = Card::ACE;
                break;

            case "J":
                faceValue = Card::JACK;
                break;

            case "Q":
                faceValue = Card::QUEEN;
                break;

            case "K":
                faceValue = Card::KING;
                break;
        }

        return faceValue;
    }
}