using NUnit.Framework;

class HandTest : PokerTestCase {

    [Test, TestCaseFixture("SomeCardsAndTheirExpectedHighCards")]
    public void willReturnTheCorrectHighFaceValueCard(string card1, string card2, string card3, string card4, string card5, string expectedHighCard) {
        Hand = new Hand(asCardArray(card1, card2, card3, card4, card5));
        Assert.AreEqual(makeCardFromString(expectedHighCard), Hand.getHighCard());
    }

    [Test, TestCaseFixture("SomeCardsAndTheirExpectedHighCards")]
    public void isWheelShouldReturnFalseWhenTheHandIsNotAWheel(string card1, string card2, string card3, string card4, string card5) {
        Hand = new Hand(asCardArray(card1, card2, card3, card4, card5));
        Assert.IsFalse(Hand.isWheel());
    }

    static object[] getSomeCardsAndTheirExpectedHighCards = {
        new string[] { "K-C", "7-S", "3-D", "A-H", "10-C", "A-H", },
        new string[] { "2-S", "3-S", "4-S", "6-S", "2-H", "6-S", },
        new string[] { "4-D", "7-C", "6-S", "5-C", "3-H", "7-C", },
        new string[] { "J-H", "3-C", "Q-D", "K-D", "7-S", "K-D", },
    };

    [Test]
    public void willReturnTheCorrectHighFaceValueCardWhenTheAceCanBePlayedLow() {
        Hand = new Hand(asCardArray("5-C", "4-C", "3-C", "2-C", "A-C"));
        Assert.AreEqual(fiveOf(Clubs()), Hand.getHighCard());
    }

    [Test]
    public void twoHandsWithDifferentCardsShouldNotBeEqual() {
        Hand = new Hand(asCardArray("J-H", "A-S", "5-C", "7-D", "3-C"));
        OtherHand = new Hand(asCardArray("A-C", "K-D", "4-D", "3-S", "6-H"));

        Assert.IsFalse(Hand.equals(OtherHand));
    }

    [Test]
    public void twoHandsWithTheSameCardsShouldBeEqual() {
        Hand = new Hand(asCardArray("A-S", "K-H", "Q-D", "J-C", "10-S"));
        OtherHand = new Hand(asCardArray("A-S", "K-H", "Q-D", "J-C", "10-S"));

        Assert.IsTrue(Hand.equals(OtherHand));
    }

    [Test]
    public void twoHandsWithTheSameCardsInDifferentOrderShouldAlsoBeEqual() {
        Hand = new Hand(asCardArray("A-S", "K-H", "Q-D", "J-C", "10-S"));
        OtherHand = new Hand(asCardArray("Q-D", "10-S", "K-H", "A-S", "J-C"));

        Assert.IsTrue(Hand.equals(OtherHand));
    }

    [Test]
    public void aHandShouldBeAbleToProperlyRepresentItselfAsAString() {
        Hand = new Hand(asCardArray("A-S", "K-H", "Q-D", "J-C", "10-S"));
        Assert.AreEqual("Hand(A-S, K-H, Q-D, J-C, 10-S)", Hand.ToString());
    }


   [Test]
    public void aHandWithAMultipleWordNameShouldBeAbleToProperlyRepresentItselfAsAStringAsWell() {
        RoyalFlush = new RoyalFlush(asCardArray("A-S", "K-S", "Q-S", "J-S", "10-S"));
        Assert.AreEqual("Royal Flush(A-S, K-S, Q-S, J-S, 10-S)", RoyalFlush.ToString());
    }

    protected Card[] asCardArray(params string[] cardStrings) {
        return cardStrings.Select(
            cardString => {
                CardBuilder = new CardBuilder();
                return CardBuilder.fromString(cardString);
            }
        );
    }
}