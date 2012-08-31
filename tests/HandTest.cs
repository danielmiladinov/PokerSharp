using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;
using PokerSharp;
using PokerSharp.Cards;
using PokerSharp.Hands;

class HandTest : PokerTestCase {

    [Test, TestCaseSource("getSomeCardsAndTheirExpectedHighCards")]
    public void willReturnTheCorrectHighFaceValueCard(string card1, string card2, string card3, string card4, string card5, string expectedHighCard) {
        var Hand = new Hand(asCardArray(card1, card2, card3, card4, card5));
        Assert.AreEqual(makeCardFromString(expectedHighCard), Hand.getHighCard());
    }

    [Test, TestCaseSource("getSomeCardsAndTheirExpectedHighCards")]
    public void isWheelShouldReturnFalseWhenTheHandIsNotAWheel(string card1, string card2, string card3, string card4, string card5, string highCardSeemsToBeUnusedHere) {
        var Hand = new Hand(asCardArray(card1, card2, card3, card4, card5));
        Assert.IsFalse(Hand.isWheel());
    }

    public object[] getSomeCardsAndTheirExpectedHighCards() {
        return new object[] {
            new string[] { "K-C", "7-S", "3-D", "A-H", "10-C", "A-H", },
            new string[] { "2-S", "3-S", "4-S", "6-S", "2-H", "6-S", },
            new string[] { "4-D", "7-C", "6-S", "5-C", "3-H", "7-C", },
            new string[] { "J-H", "3-C", "Q-D", "K-D", "7-S", "K-D", },
        };
    }

    [Test]
    public void willReturnTheCorrectHighFaceValueCardWhenTheAceCanBePlayedLow() {
        var Hand = new Hand(asCardArray("5-C", "4-C", "3-C", "2-C", "A-C"));
        Assert.AreEqual(CardMaker.fiveOf(Suit.Clubs()), Hand.getHighCard());
    }

    [Test]
    public void twoHandsWithDifferentCardsShouldNotBeEqual() {
        var Hand = new Hand(asCardArray("J-H", "A-S", "5-C", "7-D", "3-C"));
        var OtherHand = new Hand(asCardArray("A-C", "K-D", "4-D", "3-S", "6-H"));

        Assert.IsFalse(Hand.Equals(OtherHand));
    }

    [Test]
    public void twoHandsWithTheSameCardsShouldBeEqual() {
        var Hand = new Hand(asCardArray("A-S", "K-H", "Q-D", "J-C", "10-S"));
        var OtherHand = new Hand(asCardArray("A-S", "K-H", "Q-D", "J-C", "10-S"));

        Assert.IsTrue(Hand.Equals(OtherHand));
    }

    [Test]
    public void twoHandsWithTheSameCardsInDifferentOrderShouldAlsoBeEqual() {
        var Hand = new Hand(asCardArray("A-S", "K-H", "Q-D", "J-C", "10-S"));
        var OtherHand = new Hand(asCardArray("Q-D", "10-S", "K-H", "A-S", "J-C"));

        Assert.IsTrue(Hand.Equals(OtherHand));
    }

    [Test]
    public void twoHandsThatAreEqualShouldHaveTheSameHashCode() {
        var Hand = new Hand(asCardArray("A-S", "K-H", "Q-D", "J-C", "10-S"));
        var OtherHand = new Hand(asCardArray("Q-D", "10-S", "K-H", "A-S", "J-C"));

        Assert.AreEqual(Hand.GetHashCode(), OtherHand.GetHashCode());
    }

    [Test]
    public void twoHandsThatAreNotEqualShouldHaveDifferentHashCodes() {
        var Hand = new Hand(asCardArray("A-S", "K-H", "Q-D", "J-C", "10-S"));
        var OtherHand = new Hand(asCardArray("Q-D", "10-C", "K-H", "A-S", "J-C"));

        Assert.AreNotEqual(Hand.GetHashCode(), OtherHand.GetHashCode());
    }

    [Test]
    public void aHandShouldBeAbleToProperlyRepresentItselfAsAString() {
        var Hand = new Hand(asCardArray("A-S", "K-H", "Q-D", "J-C", "10-S"));
        Assert.AreEqual("Hand(A-S, K-H, Q-D, J-C, 10-S)", Hand.ToString());
    }

    [Test]
    public void aHandWithAMultipleWordNameShouldBeAbleToProperlyRepresentItselfAsAStringAsWell() {
        var RoyalFlush = new RoyalFlush(asCardArray("A-S", "K-S", "Q-S", "J-S", "10-S"));
        Assert.AreEqual("Royal Flush(A-S, K-S, Q-S, J-S, 10-S)", RoyalFlush.ToString());
    }

    protected List<Card> asCardArray(params string[] cardStrings) {
        return cardStrings.Select(
            cardString => {
                var CardBuilder = new CardBuilder();
                return CardBuilder.fromString(cardString);
            }
        ).ToList();
    }
}