using System;
using System.Text;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;
using PokerSharp.Hands;
using PokerSharp.HandBuilders;

[TestFixture]
class FullHouseSpecificationTest : PokerTestCase {

    private FullHouseSpecification Specification;

    [SetUp]
    protected void setUp() {
        Specification = new FullHouseSpecification();
    }

    [Test, TestCaseSource("getManyPossibleFullHouses")]
    public void shouldBeAbleToIdentifyAnyFullHouse(string card1, string card2, string card3, string card4, string card5) {
        var Hand = new Hand(theFiveCardsAre(card1, card2, card3, card4, card5));
        Assert.IsTrue(Specification.isSatisfiedBy(Hand), "This is a valid FullHouse({0}, {1}, {2}, {3}, {4}), why did not satisfy the specification?", card1, card2, card3, card4, card5);
    }

    [Test]
    public void shouldNotBeSatisfiedByJustAThreeOfAKind() {
        var Hand = new Hand(theFiveCardsAre("A-S", "A-H", "A-C", "J-D", "3-S"));
        Assert.IsFalse(Specification.isSatisfiedBy(Hand), "No ThreeOfAKind can be a FullHouse!");
    }

    public object[] getManyPossibleFullHouses() {
        var values = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        Func<int, string[]> getRandomSuits = delegate(int numSuits) {
            var suits = new string[] { "S", "H", "C", "D", };
            var rand = new Random();
            var randomSuits = new List<string>();

            for (int i = 0; i < numSuits; i++) {
                randomSuits.Add(suits[rand.Next(0, suits.Length)]);
            }

            return randomSuits.ToArray();
        };

        var fullHouses = new List<string[]>();

        foreach (var trioValue in values) {
            var otherValues = values.Except(new string[] { trioValue });

            IEnumerable<string> trio = getRandomSuits.Invoke(3).Select(
                suit => {
                    var cardString = new StringBuilder(trioValue);
                    cardString.Append("-");
                    cardString.Append(suit);
                    return cardString.ToString();
                }
            );

            foreach (var duoValue in otherValues) {
                IEnumerable<string> duo = getRandomSuits.Invoke(2).Select(
                    suit => {
                        var cardString = new StringBuilder(duoValue);
                        cardString.Append("-");
                        cardString.Append(suit);
                        return cardString.ToString();
                    }
                );

                var fullHouse = new List<string>();
                fullHouse.AddRange(trio);
                fullHouse.AddRange(duo);
                fullHouses.Add(fullHouse.ToArray());
            }
        }

        return fullHouses.ToArray();
    }
}
