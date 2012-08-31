using System.Linq;
using NUnit.Framework;
using PokerSharp;
using PokerSharp.Hands;
using PokerSharp.HandBuilders;

[TestFixture]
class WheelSpecificationTest : PokerTestCase {

    private WheelSpecification Specification;

    [SetUp]
    protected void setUp() {
        Specification = new WheelSpecification();
    }

    [Test]
    public void shouldBeSatisfiedByAWheel() {
        var Hand = new Hand(theFiveCardsAre("5-H", "4-C", "3-S", "2-D", "A-H"));
        Assert.IsTrue(Specification.isSatisfiedBy(Hand), "This is a valid Wheel, why did it not satisfy the specification?");
    }

    [Test, TestCaseSource("getSomeNonWheelHands")]
    public void shouldNotBeSatisfiedByOtherRandomCards(string card1, string card2, string card3, string card4, string card5) {
        var Hand = new Hand(theFiveCardsAre(card1, card2, card3, card4, card5));
        Assert.IsFalse(Specification.isSatisfiedBy(Hand), "That is not a Wheel! ({card1}, {card2}, {card3}, {card4}, {card5})");
    }

    public object[] getSomeNonWheelHands() {
        return new object[] {
            new string[] { "6-S", "10-H", "A-C", "5-D", "9-S" },
            new string[] { "7-H", "J-C", "2-D", "6-S", "10-H" },
            new string[] { "8-C", "Q-D", "3-S", "7-H", "J-C" },
            new string[] { "9-D", "K-S", "4-H", "8-C", "Q-D" },
        };
    }

    [Test]
    public void shouldNotBeSatisfiedByHandsWithMoreThanFiveCardsButThatHaveAllTheWheelCards() {
        var Hand = new Hand(
            new string[] { "5-H", "4-C", "3-S", "2-D", "A-H", "3-D", }.Select(
                cardString => {
                    var CardBuilder = new CardBuilder();
                    return CardBuilder.fromString(cardString);
                }
            ).ToList()
        );
        Assert.IsFalse(Specification.isSatisfiedBy(Hand), "A Hand with more than 5 cards cannot be a Wheel!");
    }
}