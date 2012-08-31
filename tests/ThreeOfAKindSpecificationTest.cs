using NUnit.Framework;
using PokerSharp.Hands;
using PokerSharp.HandBuilders;

[TestFixture]
class ThreeOfAKindSpecificationTest : PokerTestCase {

    private ThreeOfAKindSpecification Specification;

    [SetUp]
    protected void setUp() {
        Specification = new ThreeOfAKindSpecification();
    }

    [Test]
    public void shouldBeSatisfiedByAThreeOfAKind() {
        var Hand = new Hand(theFiveCardsAre("J-H", "J-C", "J-D", "3-S", "K-H"));
        Assert.IsTrue(Specification.isSatisfiedBy(Hand), "This is a valid ThreeOfAKind, why did it not satisfy the specification?");
    }

    [Test]
    public void shouldNotBeSatisfiedByATwoOfAKind() {
        var Hand = new Hand(theFiveCardsAre("J-H", "Q-C", "J-D", "3-S", "K-H"));
        Assert.IsFalse(Specification.isSatisfiedBy(Hand), "This is not a ThreeOfAKind!");
    }
}