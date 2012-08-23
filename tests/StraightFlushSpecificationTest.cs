using NUnit.Framework;

[TestFixture]
class StraightFlushSpecificationTest : PokerTestCase {

    private StraightFlushSpecification Specification;

    [Setup]
    protected function setUp() {
        Specification = new StraightFlushSpecification();
    }

    [Test]
    public function shouldBeSatisfiedByAHeartsStraightFlush() {
        Hand = new Hand(theFiveCardsAre("Q-H", "J-H", "10-H", "9-H", "8-H"));
        Assert.IsTrue(Specification.isSatisfiedBy(Hand), "This is a valid StraightFlush, why did it not satisfy the specification?");
    }

    [Test]
    public function shouldNotBeSatisfiedByJustAFlush() {
        Hand = new Hand(theFiveCardsAre("Q-C", "6-C", "10-C", "9-C", "8-C"));
        Assert.IsFalse(Specification.isSatisfiedBy(Hand), "Not just any Flush can be a StraightFlush!");
    }

    [Test]
    public function shouldNotBeSatisfiedByJustAStraight() {
        Hand = new Hand(theFiveCardsAre("Q-H", "J-C", "10-D", "9-S", "8-H"));
        Assert.IsFalse(Specification.isSatisfiedBy(Hand), "Not just any Straight can be a StraightFlush!");
    }
}