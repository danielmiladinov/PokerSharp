using NUnit.Framework;
using PokerSharp.Hands;
using PokerSharp.HandBuilders;

[TestFixture]
class RoyalFlushSpecificationTest : PokerTestCase {

    private RoyalFlushSpecification Specification;

    [SetUp]
    protected void setUp() {
        Specification = new RoyalFlushSpecification();
    }

    [Test]
    public void shouldBeSatisfiedByASpadesRoyalFlush() {
        var Hand = new Hand(theFiveCardsAre("A-S", "K-S", "Q-S", "J-S", "10-S"));
        Assert.IsTrue(Specification.isSatisfiedBy(Hand), "This is a valid RoyalFlush, why did it not satisfy the specification?");
    }

    [Test]
    public void shouldNotBeSatisfiedByAStraightFlush() {
        var Hand = new Hand(theFiveCardsAre("K-S", "Q-S", "J-S", "10-S", "9-S"));
        Assert.IsFalse(Specification.isSatisfiedBy(Hand), "Not just any StraightFlush can be a RoyalFlush!");
    }

    [Test]
    public void shouldNotBeSatisfiedByAnAceHighCard() {
        var Hand = new Hand(theFiveCardsAre("A-H", "2-S", "3-C", "J-D", "7-D"));
        Assert.IsFalse(Specification.isSatisfiedBy(Hand), "Not just any Ace HighCard can be a RoyalFlush!");
    }

    [Test]
    public void shouldNotBeSatisfiedByAnAceHighNonFlushStraight() {
        var Hand = new Hand(theFiveCardsAre("A-H", "K-H", "Q-C", "J-H", "10-H"));
        Assert.IsFalse(Specification.isSatisfiedBy(Hand), "Not just any Ace high Straight can be a RoyalFlush!");
    }
}