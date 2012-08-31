using NUnit.Framework;
using PokerSharp.Hands;
using PokerSharp.HandBuilders;

[TestFixture]
class TwoPairSpecificationTest : PokerTestCase {

    private TwoPairSpecification Specification;

    [SetUp]
    protected void setUp() {
        Specification = new TwoPairSpecification();
    }

    [Test]
    public void shouldBeSatisfiedByATwoPair() {
        var Hand = new Hand(theFiveCardsAre("A-S", "9-C", "9-D", "3-C", "3-H"));
        Assert.IsTrue(Specification.isSatisfiedBy(Hand), "This is a valid TwoPair, why did it not satisfy the specification?");
    }

    [Test]
    public void shouldNotBeSatisfiedByAFullHouse() {
        var Hand = new Hand(theFiveCardsAre("3-H", "3-D", "3-S", "K-C", "K-D"));
        Assert.IsFalse(Specification.isSatisfiedBy(Hand), "This is not a valid TwoPair!");
    }
}