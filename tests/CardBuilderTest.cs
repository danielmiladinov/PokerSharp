using System;
using NUnit.Framework;

[TestFixture]
class CardBuilderTest {

    private CardBuilder CardBuilder;

    [SetUp]
    public void setUp() {
        CardBuilder = new CardBuilder();
    }

    [Test]
    [ExpectedException(typeof(CardBuilderException))]
    public void willThrowAnExceptionFromInvalidString() {
        var invalidString = "aa";
        CardBuilder.fromString(invalidString);
    }


    [Test]
    [ExpectedException(typeof(CardBuilderException))]
    public void willThrowAnExceptionFromInvalidNumberTooHigh() {
        var invalidString = "15-C";
        CardBuilder.fromString(invalidString);
    }

    [Test]
    [ExpectedException(typeof(CardBuilderException))]
    public void willThrowAnExceptionFromInvalidNumberTooLow() {
        var invalidString = "1-C";
        CardBuilder.fromString(invalidString);
    }

    [Test]
    [ExpectedException(typeof(CardBuilderException))]
    public void willThrowAnExceptionFromInvalidSuit() {
        var invalidString = "2-Z";
        CardBuilder.fromString(invalidString);
    }

    [Test]
    public void willGetACardWithValidParameters() {
        var validString = "2-C";
        ExpectedCard = new Clubs(2);

        ActualCard = CardBuilder.fromString(validString);

        Assert.AreEqual(ExpectedCard, ActualCard);
    }

    [Test]
    public void willGetACardWithFaceCard() {
        var validString = "Q-S";
        ExpectedCard = new Spades(Card::QUEEN);

        ActualCard = CardBuilder.fromString(validString);

        Assert.AreEqual(ExpectedCard, ActualCard);
    }

    [Test]
    public void willGetACardWithJacks() {
        var validString = "J-H";
        ExpectedCard = new Hearts(Card::JACK);

        ActualCard = CardBuilder.fromString(validString);

        Assert.AreEqual(ExpectedCard, ActualCard);
    }

    [Test]
    public void willGetACardWithKings() {
        var validString = "K-D";
        ExpectedCard = new Diamonds(Card::KING);

        ActualCard = CardBuilder.fromString(validString);

        Assert.AreEqual(ExpectedCard, ActualCard);
    }

    [Test]
    public void willGetACardWithAce() {
        var validString = "A-C";
        ExpectedCard = new Clubs(Card::ACE);

        ActualCard = CardBuilder.fromString(validString);

        Assert.AreEqual(ExpectedCard, ActualCard);
    }
}
