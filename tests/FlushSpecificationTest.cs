using NUnit.Framework;
using PokerSharp.Hands;
using PokerSharp.HandBuilders;

[TestFixture]
class FlushSpecificationTest : PokerTestCase {

    private FlushSpecification Specification;

    [SetUp]
    protected void setUp() {
        Specification = new FlushSpecification();
    }

    [Test, TestCaseSource("getSomePossibleFlushes")]
    public void shouldBeAbleToIdentifyAFlush(string card1, string card2, string card3, string card4, string card5) {
        var Hand = new Hand(theFiveCardsAre(card1, card2, card3, card4, card5));
        Assert.IsTrue(Specification.isSatisfiedBy(Hand), "This is a valid Flush, why did it not satisfy the specification?");
    }

    [Test]
    public void shouldNotBeSatisfiedByAHandWithCardsFromMoreThanOneSuit() {
        var Hand = new Hand(theFiveCardsAre("A-C", "2-C", "3-H", "4-C", "5-C"));
        Assert.IsFalse(Specification.isSatisfiedBy(Hand), "That is not a Flush!");
    }

    public object[] getSomePossibleFlushes() {
        return new object[] {
            new string[] { "A-S", "7-S", "3-S", "9-S", "5-S", },
            new string[] { "7-H", "8-H", "9-H", "2-H", "5-H", },
            new string[] { "3-C", "4-C", "5-C", "6-C", "8-C", },
            new string[] { "K-D", "Q-D", "J-D", "9-D", "8-D", },
        };
    }
}
