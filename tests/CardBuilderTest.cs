using System;
using NUnit.Framework;
using PokerSharp;
using PokerSharp.Cards;

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
        var ExpectedCard = new Clubs(2);
        var ActualCard = CardBuilder.fromString(validString);

        Assert.AreEqual(ExpectedCard, ActualCard);
    }

    [Test]
    public void willGetACardWithFaceCard() {
        var validString = "Q-S";
        var ExpectedCard = new Spades(Card.QUEEN);
        var ActualCard = CardBuilder.fromString(validString);

        Assert.AreEqual(ExpectedCard, ActualCard);
    }

    [Test]
    public void willGetACardWithJacks() {
        var validString = "J-H";
        var ExpectedCard = new Hearts(Card.JACK);
        var ActualCard = CardBuilder.fromString(validString);

        Assert.AreEqual(ExpectedCard, ActualCard);
    }

    [Test]
    public void willGetACardWithKings() {
        var validString = "K-D";
        var ExpectedCard = new Diamonds(Card.KING);
        var ActualCard = CardBuilder.fromString(validString);

        Assert.AreEqual(ExpectedCard, ActualCard);
    }

    [Test]
    public void willGetACardWithAce() {
        var validString = "A-C";
        var ExpectedCard = new Clubs(Card.ACE);
        var ActualCard = CardBuilder.fromString(validString);

        Assert.AreEqual(ExpectedCard, ActualCard);
    }
}
