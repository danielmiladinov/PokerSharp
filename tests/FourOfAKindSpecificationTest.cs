using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using PokerSharp.Hands;
using PokerSharp.HandBuilders;

[TestFixture]
class FourOfAKindSpecificationTest : PokerTestCase {

    private FourOfAKindSpecification Specification;

    [SetUp]
    protected void setUp() {
        Specification = new FourOfAKindSpecification();
    }

    [Test, TestCaseSource("getAllPossibleFoursOfAKindEachWithARandomKicker")]
    public void shouldBeAbleToIdentifyAFourOfAKind(string card1, string card2, string card3, string card4, string card5) {
        var Hand = new Hand(theFiveCardsAre(card1, card2, card3, card4, card5));
        Assert.IsTrue(Specification.isSatisfiedBy(Hand), "This is a valid FourOfAKind, why did it not satisfy the specification?");
    }

    [Test]
    public void shouldNotBeSatisfiedByJustAThreeOfAKind() {
        var Hand = new Hand(theFiveCardsAre("A-S", "A-H", "A-C", "J-D", "3-S"));
        Assert.IsFalse(Specification.isSatisfiedBy(Hand), "No ThreeOfAKind can be a FourOfAKind!");
    }

    public object[] getAllPossibleFoursOfAKindEachWithARandomKicker() {
        var suits = new string[] { "S", "H", "C", "D" };
        var values = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        var foursOfAKind = new List<string[]>();
        var random = new Random();

        foreach (var faceValue in values) {
            var fourOfAKind = new List<string>();

            foreach (var suit in suits) {
                var cardString = new StringBuilder(faceValue);
                cardString.Append("-");
                cardString.Append(suit);
                fourOfAKind.Add(cardString.ToString());
            }

            var kickerString = new StringBuilder();
            var otherValues = values.Except(new string[] { faceValue }).ToArray();
            kickerString.Append(otherValues[random.Next(0, otherValues.Length)]);
            kickerString.Append("-");
            kickerString.Append(suits[random.Next(0, suits.Length)]);

            fourOfAKind.Add(kickerString.ToString());
            foursOfAKind.Add(fourOfAKind.ToArray());
        }

        return foursOfAKind.ToArray();
    }
}