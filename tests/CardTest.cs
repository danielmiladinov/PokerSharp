using NUnit.Framework;
using PokerSharp;
using PokerSharp.Cards;

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

    [Test]
    public void equalsShouldReturnTrueForTwoCardsWithTheSameSuitAndValue() {
        theCurrentCardIs("A-S");
        andTheOtherCardIs("A-S");
        Assert.IsTrue(CurrentCard.Equals(OtherCard));
    }

    [Test]
    public void equalsShouldReturnFalseForTwoCardsWithTheSameSuitButDifferentValue() {
        theCurrentCardIs("A-S");
        andTheOtherCardIs("K-S");
        Assert.IsFalse(CurrentCard.Equals(OtherCard));
    }

    [Test]
    public void equalsShouldReturnFalseForTwoCardsWithTheSameValueButDifferentSuit() {
        theCurrentCardIs("K-D");
        andTheOtherCardIs("K-C");
        Assert.IsFalse(CurrentCard.Equals(OtherCard));
    }

    [Test]
    public void twoEqualCardsShouldHaveTheSameHashCode() {
        theCurrentCardIs("A-S");
        andTheOtherCardIs("A-S");
        Assert.AreEqual(CurrentCard.GetHashCode(), OtherCard.GetHashCode());
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
        Assert.Greater(0, CurrentCard.compareTo(OtherCard));
    }

    private void theOtherCardShouldBeGreater() {
        Assert.Less(0, CurrentCard.compareTo(OtherCard));
    }
}
