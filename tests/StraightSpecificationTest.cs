using NUnit.Framework;

[TestFixture]
class StraightSpecificationTest : PokerTestCase {

    [Test]
    private StraightSpecification Specification;

    [Setup]
    protected void setUp() {
        Specification = new StraightSpecification();
    }

    [Test]
    public void shouldBeSatisfiedByAStraight() {
        Hand = new Hand(theFiveCardsAre("2-H", "3-C", "4-D", "5-H", "6-S"));
        Assert.IsTrue(Specification->isSatisfiedBy(Hand), "This is a valid Straight, why did it not satisfy the specification?");
    }

    [Test, TestCaseSource("SomeHandsThatAreNotStraights")]
    public void shouldNotBeSatisfiedByHandsThatAreNotStraights(string card1, string card2, string card3, string card4, string card5) {
        Hand = new Hand(theFiveCardsAre(card1, card2, card3, card4, card5));
        Assert.IsFalse(Specification->isSatisfiedBy(Hand, "That is not a Straight! ({0}, {1}, {2}, {3}, {4})", card1, card2, card3, card4, card5));
    }

    static object[][] SomeHandsThatAreNotStraights = {
        new string[] { "2-S", "3-H", "4-C", "5-D", "7-S" },
        new string[] { "3-H", "4-C", "5-D", "6-S", "8-H" },
        new string[] { "4-C", "5-D", "6-S", "7-H", "9-C" },
        new string[] { "5-D", "6-S", "7-H", "8-C", "J-D" },
    };
}