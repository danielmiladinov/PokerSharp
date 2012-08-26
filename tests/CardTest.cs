using NUnit.Framework;

[TestFixture]
class CardTest {
    private Card CurrentCard;
    private Card OtherCard;

    [Test]
    public void compareToShouldReturnZeroWhenTheOtherCardIsOfTheSameValueAndSuit() {
        theCurrentCardIs("A-S");
        andTheOtherCardIs("A-S");
        theCardsShouldBeEqual();
    }

    [Test]
    public void compareToShouldReturnLessThanZeroWhenTheOtherCardIsOfALesserFaceValueAndADifferentSuit() {
        theCurrentCardIs("7-D");
        andTheOtherCardIs("6-H");
        theCurrentCardShouldBeGreater();
    }

    [Test]
    public void compareToShouldReturnLessThanZeroWhenTheOtherCardIsOfALesserFaceValueAndTheSameSuit() {
        theCurrentCardIs("7-C");
        andTheOtherCardIs("6-C");
        theCurrentCardShouldBeGreater();
    }

    [Test]
    public void compareToShouldReturnGreaterThanZeroWhenTheOtherCardIsOfTheSameFaceValueButAGreaterSuit() {
        theCurrentCardIs("J-D");
        andTheOtherCardIs("J-C");
        theOtherCardShouldBeGreater();
    }

    private Card makeCardFromString(string cardString) {
        var CardBuilder = new CardBuilder();
        return CardBuilder.fromString(cardString);
    }

    private void theCurrentCardIs(string cardString) {
        CurrentCard = makeCardFromString(cardString);
    }

    private void andTheOtherCardIs(string cardString) {
        OtherCard = makeCardFromString(cardString);
    }

    private void theCardsShouldBeEqual() {
        Assert.AreEqual(0, CurrentCard.compareTo(OtherCard));
    }

    private void theCurrentCardShouldBeGreater() {
        Assert.Less(0, CurrentCard.compareTo(OtherCard));
    }

    private void theOtherCardShouldBeGreater() {
        Assert.Greater(0, CurrentCard.compareTo(OtherCard));
    }
}
