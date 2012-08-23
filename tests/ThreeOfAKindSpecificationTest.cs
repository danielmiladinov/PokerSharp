using NUnit.Framework;

[TestFixture]
class ThreeOfAKindSpecificationTest : PokerTestCase {

    private ThreeOfAKindSpecification Specification;

    [Setup]
    protected void setUp() {
        Specification = new ThreeOfAKindSpecification();
    }

    [Test]
    public void shouldBeSatisfiedByAThreeOfAKind() {
        Hand = new Hand(theFiveCardsAre("J-H", "J-C", "J-D", "3-S", "K-H"));
        Assert.IsTrue(Specification.isSatisfiedBy(Hand), "This is a valid ThreeOfAKind, why did it not satisfy the specification?");
    }

    [Test]
    public void shouldNotBeSatisfiedByATwoOfAKind() {
        Hand = new Hand(theFiveCardsAre("J-H", "Q-C", "J-D", "3-S", "K-H"));
        Assert.IsFalse(Specification.isSatisfiedBy(Hand), "This is not a ThreeOfAKind!");
    }
}