using NUnit.Framework;
using PokerSharp.Hands;
using PokerSharp.HandBuilders;

[TestFixture]
class SteelWheelSpecificationTest : PokerTestCase {

    private SteelWheelSpecification Specification;

    [SetUp]
    protected void setUp() {
        Specification = new SteelWheelSpecification();
    }

    [Test]
    public void shouldBeAbleToIdentifyAClubsSteelWheel() {
        var Hand = new Hand(theFiveCardsAre("5-C", "4-C", "3-C", "2-C", "A-C"));
        Assert.IsTrue(Specification.isSatisfiedBy(Hand), "This is a valid SteelWheel, why did it not satisfy the specification?");
    }

    [Test]
    public void shouldNotBeSatisfiedByJustAFlush() {
        var Hand = new Hand(theFiveCardsAre("Q-C", "6-C", "10-C", "9-C", "8-C"));
        Assert.IsFalse(Specification.isSatisfiedBy(Hand), "Not just any Flush can be a SteelWheel!");
    }

    [Test]
    public void shouldNotBeSatisfiedByJustAStraight() {
        var Hand = new Hand(theFiveCardsAre("5-C", "4-C", "3-C", "2-C", "A-D"));
        Assert.IsFalse(Specification.isSatisfiedBy(Hand), "Not just any Straight can be a SteelWheel!");
    }

    [Test]
    public void shouldNotBeSatisfiedByJustAStraightFlush() {
        var Hand = new Hand(theFiveCardsAre("J-C", "10-C", "9-C", "8-C", "7-C"));
        Assert.IsFalse(Specification.isSatisfiedBy(Hand), "Not just any StraightFlush can be a SteelWheel!");
    }
}