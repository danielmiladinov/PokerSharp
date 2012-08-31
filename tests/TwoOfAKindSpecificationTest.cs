using NUnit.Framework;
using PokerSharp.Hands;
using PokerSharp.HandBuilders;

[TestFixture]
class TwoOfAKindSpecificationTest : PokerTestCase {

    private TwoOfAKindSpecification Specification;

    [SetUp]
    protected void setUp() {
        Specification = new TwoOfAKindSpecification();
    }

    [Test]
    public void shouldBeSatisfiedByATwoOfAKind() {
        var Hand = new Hand(theFiveCardsAre("2-C", "3-C", "4-C", "5-C", "4-H"));
        Assert.IsTrue(Specification.isSatisfiedBy(Hand), "This is a valid TwoOfAKind, why did it not satisfy the specification?");
    }

    [Test]
    public void shouldNotBeSatisfiedByRandomJunkCards() {
        var Hand = new Hand(theFiveCardsAre("K-H", "10-S", "3-C", "5-D", "7-S"));
        Assert.IsFalse(Specification.isSatisfiedBy(Hand), "This is not a valid TwoOfAKind!");
    }

    [Test]
    public void shouldNotBeSatisfiedByAThreeOfAKind() {
        var Hand = new Hand(theFiveCardsAre("K-H", "K-S", "K-C", "5-D", "7-S"));
        Assert.IsFalse(Specification.isSatisfiedBy(Hand), "This is not a valid TwoOfAKind!");
    }

    [Test]
    public void shouldNotBeSatisfiedByAFourOfAKind() {
        var Hand = new Hand(theFiveCardsAre("K-H", "K-S", "K-C", "K-D", "7-S"));
        Assert.IsFalse(Specification.isSatisfiedBy(Hand), "This is not a valid TwoOfAKind!");
    }
}