using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using PokerSharp;
using PokerSharp.Cards;
using PokerSharp.Hands;

[TestFixture]
class BestHandIdentifierTest : PokerTestCase {
    private BestHandIdentifier HandIdentifier;
    private List<Card> DealtCards;
    private Hand IdentifiedHand;

    [SetUp]
    public void setUp() {
        HandIdentifier = new BestHandIdentifier();
    }

    [TearDown]
    protected void assertPostConditions() {
        if (IdentifiedHand is Hand) {
            List<Card> CardsInHand = IdentifiedHand.getCards();
            Assert.AreEqual(5, CardsInHand.Count, "{0} {1} did not have 5 cards", IdentifiedHand.GetType(), printCards(CardsInHand));
        }
    }

    [Test]
    public void willGetJustAHighCard() {
        DealtCards = theFiveCardsAre("A-S", "J-C", "7-C", "5-D", "4-S");
        IdentifiedHand = HandIdentifier.identify(DealtCards);
        Assert.IsInstanceOf<HighCard>(IdentifiedHand);
    }

    [Test]
    public void willGetTwoOfAKind() {
        DealtCards = theFiveCardsAre("A-S", "A-H", "J-C", "7-C", "5-D");
        IdentifiedHand = HandIdentifier.identify(DealtCards);
        Assert.IsInstanceOf<TwoOfAKind>(IdentifiedHand);
    }

    [Test]
    public void willGetTwoOfAKindWithADifferentPair() {
        DealtCards = theFiveCardsAre("A-S", "7-H", "J-C", "7-C", "5-D");
        IdentifiedHand = HandIdentifier.identify(DealtCards);
        Assert.IsInstanceOf<TwoOfAKind>(IdentifiedHand);
    }

    [TestCaseSource("getSomeCandidatesForATwoPair")]
    public void willGetTwoPair(string card1, string card2, string card3, string card4, string card5) {
        DealtCards = theFiveCardsAre(card1, card2, card3, card4, card5);
        IdentifiedHand = HandIdentifier.identify(DealtCards);
        Assert.IsInstanceOf<TwoPair>(IdentifiedHand);
    }

    public object[] getSomeCandidatesForATwoPair() {
        return new object[] {
            new string[] {"A-H", "A-C", "7-C", "3-D", "7-S"},
            new string[] {"K-D", "J-S", "K-H", "A-S", "J-C"},
            new string[] {"2-C", "5-D", "6-H", "2-D", "5-H"},
            new string[] {"10-C", "10-S", "9-D", "8-H", "9-S"},
        };
    }

    [Test]
    public void willGetThreeOfAKind() {
        DealtCards = theFiveCardsAre("7-S", "7-H", "7-C", "J-C", "5-D");
        IdentifiedHand = HandIdentifier.identify(DealtCards);
        Assert.IsInstanceOf<ThreeOfAKind>(IdentifiedHand);
    }

    [TestCaseSource("getSomeCandidatesForAStraight")]
    public void willGetAStraight(string card1, string card2, string card3, string card4, string card5) {
        DealtCards = theFiveCardsAre(card1, card2, card3, card4, card5);
        IdentifiedHand = HandIdentifier.identify(DealtCards);
        Assert.IsInstanceOf<Straight>(IdentifiedHand);
    }

    public object[] getSomeCandidatesForAStraight() {
        return new object[] {
            new string[] {"A-D", "2-S", "3-H", "4-C", "5-D",},
            new string[] {"2-S", "3-H", "4-C", "5-D", "6-S",},
            new string[] {"3-H", "4-C", "5-D", "6-S", "7-H",},
            new string[] {"4-C", "5-D", "6-S", "7-H", "8-C",},
            new string[] {"5-D", "6-S", "7-H", "8-C", "9-D",},
            new string[] {"6-S", "7-H", "8-C", "9-D", "10-S",},
            new string[] {"7-H", "8-C", "9-D", "10-S", "J-H",},
            new string[] {"8-C", "9-D", "10-S", "J-H", "Q-C",},
            new string[] {"9-D", "10-S", "J-H", "Q-C", "K-D",},
            new string[] {"10-S", "J-H", "Q-C", "K-D", "A-S",},
        };
    }

    [TestCaseSource("getSomeCandidatesForAFlush")]
    public void willGetAFlush(string card1, string card2, string card3, string card4, string card5) {
        DealtCards = theFiveCardsAre(card1, card2, card3, card4, card5);
        IdentifiedHand = HandIdentifier.identify(DealtCards);
        Assert.IsInstanceOf<Flush>(IdentifiedHand);
    }

    public object[] getSomeCandidatesForAFlush() {
        return new object[] {
            new string[] {"2-D", "4-D", "6-D", "9-D", "10-D",},
            new string[] {"A-C", "3-C", "5-C", "J-C", "Q-C",},
            new string[] {"3-H", "5-H", "7-H", "8-H", "9-H",},
            new string[] {"4-S", "6-S", "8-S", "10-S", "J-S",},
        };
    }

    [Test]
    public void testWillGetFullHouse() {
        DealtCards = theFiveCardsAre("10-H", "10-C", "10-D", "7-C", "7-D");
        IdentifiedHand = HandIdentifier.identify(DealtCards);
        Assert.IsInstanceOf<FullHouse>(IdentifiedHand);
    }

    [Test]
    public void testWillGetFourOfAKind() {
        DealtCards = theFiveCardsAre("7-D", "7-S", "7-C", "7-H", "J-C");
        IdentifiedHand = HandIdentifier.identify(DealtCards);
        Assert.IsInstanceOf<FourOfAKind>(IdentifiedHand);
    }

    [TestCaseSource("getSomeCandidatesForAStraightFlush")]
    public void willGetAStraightFlush(string card1, string card2, string card3, string card4, string card5) {
        DealtCards = theFiveCardsAre(card1, card2, card3, card4, card5);
        IdentifiedHand = HandIdentifier.identify(DealtCards);
        Assert.IsInstanceOf<StraightFlush>(IdentifiedHand);
    }

    public object[] getSomeCandidatesForAStraightFlush() {
        return new object[] {
            new string[] {"7-H", "6-H", "5-H", "4-H", "3-H",},
            new string[] {"5-S", "4-S", "3-S", "2-S", "A-S",},
            new string[] {"J-C", "10-C", "9-C", "8-C", "7-C",},
            new string[] {"K-D", "Q-D", "J-D", "10-D", "9-D",},
        };
    }

    [TestCaseSource("getSomeCandidatesForASteelWheel")]
    public void willGetASteelWheel(string card1, string card2, string card3, string card4, string card5) {
        DealtCards = theFiveCardsAre(card1, card2, card3, card4, card5);
        IdentifiedHand = HandIdentifier.identify(DealtCards);
        Assert.IsInstanceOf<SteelWheel>(IdentifiedHand);
    }

    public object[] getSomeCandidatesForASteelWheel() {
        return new object[] {
            new string[] {"5-S", "4-S", "3-S", "2-S", "A-S",},
            new string[] {"5-H", "4-H", "3-H", "2-H", "A-H",},
            new string[] {"5-C", "4-C", "3-C", "2-C", "A-C",},
            new string[] {"5-D", "4-D", "3-D", "2-D", "A-D",},
        };
    }

    [TestCaseSource("getSomeCandidatesForAWheel")]
    public void willGetARegularWheel(string card1, string card2, string card3, string card4, string card5) {
        DealtCards = theFiveCardsAre(card1, card2, card3, card4, card5);
        IdentifiedHand = HandIdentifier.identify(DealtCards);
        Assert.IsInstanceOf<Wheel>(IdentifiedHand);
    }

    public object[] getSomeCandidatesForAWheel() {
        return new object[] {
            new string[] {"5-S", "4-H", "3-C", "2-D", "A-S",},
            new string[] {"5-H", "4-C", "3-D", "2-S", "A-H",},
            new string[] {"5-C", "4-D", "3-S", "2-H", "A-C",},
            new string[] {"5-D", "4-S", "3-H", "2-C", "A-D",},
        };
    }

    [TestCaseSource("getSomeCandidatesForARoyalFlush")]
    public void willGetARoyalFlush(string card1, string card2, string card3, string card4, string card5) {
        DealtCards = theFiveCardsAre(card1, card2, card3, card4, card5);
        IdentifiedHand = HandIdentifier.identify(DealtCards);
        Assert.IsInstanceOf<RoyalFlush>(IdentifiedHand);
    }

    public object[] getSomeCandidatesForARoyalFlush() {
        return new object[] {
            new string[] {"10-D", "J-D", "Q-D", "K-D", "A-D",},
            new string[] {"10-S", "J-S", "Q-S", "K-S", "A-S",},
            new string[] {"10-H", "J-H", "Q-H", "K-H", "A-H",},
            new string[] {"10-C", "J-C", "Q-C", "K-C", "A-C",},
        };
    }

    [Test]
    public void shouldBeAbleToIdentifyFourOfAKindWhereHighCardIsNotOneOfTheFourOfAKind() {
        var ProvidedCards = new string[] {"K-C", "Q-S", "J-H", "9-D", "6-D", "5-S", "3-S", "3-H", "3-C", "3-D"}.Select(
            cardString => {
                var cb = new CardBuilder(); return cb.fromString(cardString);
            }
        ).ToList();

        var ExpectedBestHand = new FourOfAKind(
            new string[] {"K-C", "3-S", "3-H", "3-C", "3-D"}.Select(
                cardString => {
                    var cb = new CardBuilder(); return cb.fromString(cardString);
                }
            ).ToList()
        );

        IdentifiedHand = HandIdentifier.identify(ProvidedCards);
        Assert.AreEqual(ExpectedBestHand, IdentifiedHand, "{0} was expected but {1} was identified", ExpectedBestHand, IdentifiedHand);
    }

    [TestCaseSource("getSomeCardsAndTheExpectedBestHandFromThem")]
    public void shouldBeAbleToIdentifyTheBestPossibleHandOutOfSeveralPossible(List<Card> Cards, Hand ExpectedBestHand) {
        IdentifiedHand = HandIdentifier.identify(Cards);
        Assert.AreEqual(ExpectedBestHand, IdentifiedHand, "{0} was expected but {1} was identified", ExpectedBestHand, IdentifiedHand);
    }

    public object[] getSomeCardsAndTheExpectedBestHandFromThem() {
        object[][] data = {
            new object[] { new string[] {"A-S", "K-D", "K-S", "K-H", "K-D", "Q-S", "J-S", "J-H", "J-C", "10-S"}, "RoyalFlush", new string[] {"A-S", "K-S", "Q-S", "J-S", "10-S"}},
            new object[] { new string[] {"10-S", "9-D", "6-S", "6-H", "6-D", "4-D", "3-S", "3-H", "3-C", "3-D"}, "FourOfAKind", new string[] {"10-S", "3-S", "3-H", "3-C", "3-D"}},
            new object[] { new string[] {"A-C", "K-S", "K-H", "J-D", "6-D", "5-S", "3-S", "3-H", "3-C", "3-D"}, "FourOfAKind", new string[] {"A-C", "3-S", "3-H", "3-C", "3-D"}},
            new object[] { new string[] {"A-C", "A-S", "K-H", "J-D", "6-D", "5-S", "2-S", "2-H", "2-C", "2-D"}, "FourOfAKind", new string[] {"A-S", "2-S", "2-H", "2-C", "2-D"}},
            new object[] { new string[] {"K-D", "9-H", "6-S", "6-H", "6-C", "6-D", "4-D", "3-C", "2-S", "2-H"}, "FourOfAKind", new string[] {"K-D", "6-S", "6-H", "6-C", "6-D"}},
            new object[] { new string[] {"K-S", "K-H", "K-C", "K-D", "Q-S", "Q-C", "7-S", "5-D", "3-S", "2-S"}, "FourOfAKind", new string[] {"K-S", "K-H", "K-C", "K-D", "Q-S"}},
            new object[] { new string[] {"10-D", "8-C", "7-S", "7-H", "7-D", "6-S", "6-C", "6-D", "5-H", "3-C",}, "FullHouse", new string[] {"7-S", "7-H", "7-D", "6-S", "6-C",},},
            new object[] { new string[] {"8-H", "7-C", "6-S", "4-H", "4-C", "4-D", "3-S", "2-S", "2-C", "2-D",}, "FullHouse", new string[] {"4-H", "4-C", "4-D", "2-S", "2-C",},},
            new object[] { new string[] {"A-D", "10-S", "9-S", "9-H", "9-D", "8-H", "8-C", "8-D", "7-D", "6-D",}, "FullHouse", new string[] {"9-S", "9-H", "9-D", "8-H", "8-C",},},
            new object[] { new string[] {"A-D", "Q-D", "8-S", "8-H", "8-C", "7-S", "7-H", "7-C", "3-H", "3-C",}, "FullHouse", new string[] {"8-S", "8-H", "8-C", "7-S", "7-H",},},
            new object[] { new string[] {"A-S", "10-S", "10-H", "10-C", "8-S", "8-C", "7-H", "7-C", "7-D", "2-C",}, "FullHouse", new string[] {"10-S", "10-H", "10-C", "8-S", "8-C",},},
            new object[] { new string[] {"A-S", "A-C", "A-D", "Q-H", "10-S", "10-C", "10-D", "5-S", "4-H", "2-S",}, "FullHouse", new string[] {"A-S", "A-C", "A-D", "10-S", "10-C",},},
            new object[] { new string[] {"A-S", "A-H", "A-D", "K-D", "9-D", "8-S", "4-S", "4-C", "4-D", "3-S",}, "FullHouse", new string[] {"A-S", "A-H", "A-D", "4-S", "4-C",},},
            new object[] { new string[] {"K-D", "Q-S", "Q-H", "Q-D", "J-H", "8-D", "3-S", "3-H", "3-D", "2-D",}, "FullHouse", new string[] {"Q-S", "Q-H", "Q-D", "3-S", "3-H",},},
            new object[] { new string[] {"K-S", "K-C", "K-D", "Q-S", "J-H", "8-S", "7-S", "7-H", "7-D", "2-C",}, "FullHouse", new string[] {"K-S", "K-C", "K-D", "7-S", "7-H",},},
            new object[] { new string[] {"Q-H", "J-S", "9-D", "8-S", "8-H", "8-C", "4-S", "4-H", "4-D", "2-C",}, "FullHouse", new string[] {"8-S", "8-H", "8-C", "4-S", "4-H",},},
            new object[] { new string[] {"K-S", "K-C", "K-D", "Q-S", "J-H", "8-S", "7-S", "7-H", "7-D", "2-C",}, "FullHouse", new string[] {"K-S", "K-C", "K-D", "7-S", "7-H",},},
            new object[] { new string[] {"A-H", "K-D", "Q-S", "Q-C", "Q-D", "10-S", "10-C", "10-D", "9-S", "9-D",}, "FullHouse", new string[] {"Q-S", "Q-C", "Q-D", "10-S", "10-C",},},
            new object[] { new string[] {"A-H", "K-S", "J-S", "J-H", "J-C", "10-S", "10-H", "10-D", "7-C", "4-S",}, "FullHouse", new string[] {"J-S", "J-H", "J-C", "10-S", "10-H",},},
            new object[] { new string[] {"10-D", "8-C", "7-S", "7-H", "7-D", "6-S", "6-C", "6-D", "5-H", "3-C"}, "FullHouse", new string[] {"7-S", "7-H", "7-D","6-S", "6-C",}},
            new object[] { new string[] {"8-H", "7-C", "6-S", "4-H", "4-C", "4-D", "3-S", "2-S", "2-C", "2-D"}, "FullHouse", new string[] {"4-H", "4-C", "4-D","2-S", "2-C",}},
            new object[] { new string[] {"A-D", "Q-D", "8-S", "8-H", "8-C", "7-S", "7-H", "7-C", "3-H", "3-C"}, "FullHouse", new string[] {"8-S", "8-H", "8-C","7-S", "7-H",}},
            new object[] { new string[] {"A-D", "10-S", "9-S", "9-H", "9-D", "8-H", "8-C", "8-D", "7-D", "6-D"}, "FullHouse", new string[] {"9-S", "9-H", "9-D","8-H", "8-C",}},
            new object[] { new string[] {"Q-H", "J-S", "9-D", "8-S", "8-H", "8-C", "4-S", "4-H", "4-D", "2-C"}, "FullHouse", new string[] {"8-S", "8-H", "8-C","4-S", "4-H",}},
            new object[] { new string[] {"A-S", "10-S", "10-H", "10-C", "8-S", "8-C", "7-H", "7-C", "7-D", "2-C"}, "FullHouse", new string[] {"10-S", "10-H", "10-C","8-S", "8-C",}},
            new object[] { new string[] {"A-S", "A-C", "A-D", "Q-H", "10-S", "10-C", "10-D", "5-S", "4-H", "2-S"}, "FullHouse", new string[] {"A-S", "A-C", "A-D","10-S", "10-C",}},
            new object[] { new string[] {"A-S", "A-H", "A-D", "K-D", "9-D", "8-S", "4-S", "4-C", "4-D", "3-S"}, "FullHouse", new string[] {"A-S", "A-H", "A-D","4-S", "4-C",}},
            new object[] { new string[] {"K-S", "K-C", "K-D", "Q-S", "J-H", "8-S", "7-S", "7-H", "7-D", "2-C"}, "FullHouse", new string[] {"K-S", "K-C", "K-D","7-S", "7-H",}},
            new object[] { new string[] {"A-D", "Q-H", "J-H", "10-D", "9-C", "8-S", "7-C", "6-C", "5-C", "4-C",}, "Flush", new string[] {"9-C", "7-C", "6-C", "5-C", "4-C",},},
            new object[] { new string[] {"A-H", "Q-D", "J-S", "9-S", "8-D", "6-D", "5-D", "4-C", "3-C", "2-D",}, "Flush", new string[] {"Q-D", "8-D", "6-D", "5-D", "2-D",},},
            new object[] { new string[] {"A-S", "Q-S", "J-S", "10-C", "9-S", "8-H", "7-D", "4-H", "3-H", "2-S",}, "Flush", new string[] {"A-S", "Q-S", "J-S", "9-S", "2-S",},},
            new object[] { new string[] {"A-H", "K-S", "Q-S", "J-S", "7-S", "7-C", "7-D", "5-S", "4-S", "3-S",}, "Flush", new string[] {"K-S", "Q-S", "J-S", "7-S", "5-S",},},
            new object[] { new string[] {"A-S", "A-H", "A-D", "K-H", "Q-H", "9-D", "8-H", "6-H", "5-S", "4-C",}, "Flush", new string[] {"A-H","K-H", "Q-H", "8-H", "6-H",},},
            new object[] { new string[] {"K-D", "Q-D", "J-S", "9-D", "8-H", "7-D", "6-D", "5-C", "4-S", "2-C",}, "Flush", new string[] {"K-D", "Q-D", "9-D", "7-D", "6-D",},},
            new object[] { new string[] {"K-D", "Q-S", "J-S", "10-S", "9-S", "7-S", "6-D", "5-S", "3-S", "2-C",}, "Flush", new string[] {"Q-S", "J-S", "10-S", "9-S", "7-S",},},
            new object[] { new string[] {"K-S", "Q-S", "J-D", "10-S", "9-D", "8-H", "7-S", "6-S", "5-H", "4-S",}, "Flush", new string[] {"K-S", "Q-S", "10-S", "7-S", "6-S",},},
            new object[] { new string[] {"A-H", "K-H", "Q-H", "J-S", "10-H", "9-S", "8-S", "7-H", "6-S", "2-H",}, "Flush", new string[] {"A-H", "K-H", "Q-H", "10-H", "7-H"},},
            new object[] { new string[] {"A-C", "K-C", "J-S", "J-H", "J-C", "10-S", "9-H", "8-C", "7-C", "6-D",}, "Flush", new string[] {"A-C", "K-C", "J-C", "8-C", "7-C"},},
            new object[] { new string[] {"A-S", "K-D", "Q-S", "J-D", "10-S", "7-H", "5-S", "5-C", "5-D", "4-S",}, "Flush", new string[] {"A-S", "Q-S", "10-S", "5-S", "4-S"},},
            new object[] { new string[] {"A-D", "K-C", "Q-C", "J-D", "10-C", "7-H", "7-C", "7-D", "6-D", "2-D",}, "Flush", new string[] {"A-D", "J-D", "7-D", "6-D", "2-D"},},
            new object[] { new string[] {"Q-S", "Q-H", "Q-C", "J-H", "10-C", "9-C", "8-C", "5-C", "3-C", "2-C",}, "Flush", new string[] {"Q-C", "10-C", "9-C", "8-C", "5-C"},},
            new object[] { new string[] {"A-C", "10-H", "9-S", "8-C", "7-S", "6-S", "5-D", "4-D", "3-D", "2-C",}, "Straight", new string[] {"10-H", "9-S", "8-C", "7-S", "6-S",},},
            new object[] { new string[] {"A-C", "K-S", "Q-H", "J-D", "10-H", "9-H", "8-C", "6-C", "4-H", "2-S",}, "Straight", new string[] {"A-C", "K-S", "Q-H", "J-D", "10-H",},},
            new object[] { new string[] {"K-C", "J-H", "10-S", "9-C", "8-H", "7-S", "6-H", "5-D", "3-S", "2-C",}, "Straight", new string[] {"J-H", "10-S", "9-C", "8-H", "7-S",},},
            new object[] { new string[] {"A-D", "K-D", "Q-S", "J-H", "10-H", "6-S", "5-S", "4-D", "3-H", "2-H",}, "Straight", new string[] {"A-D", "K-D", "Q-S", "J-H", "10-H",},},
            new object[] { new string[] {"J-C", "10-S", "7-D", "6-S", "5-H", "4-S", "4-H", "4-D", "3-C", "2-H",}, "Straight", new string[] {"7-D", "6-S", "5-H", "4-S", "3-C",},},
            new object[] { new string[] {"K-H", "10-H", "9-C", "8-S", "8-C", "8-D", "7-S", "6-S", "5-H", "4-D",}, "Straight", new string[] {"10-H", "9-C", "8-S", "7-S", "6-S",},},
            new object[] { new string[] {"K-S", "K-C", "K-D", "Q-S", "9-H", "6-H", "5-D", "4-C", "3-S", "2-D",}, "Straight", new string[] {"6-H", "5-D", "4-C", "3-S", "2-D",},},
            new object[] { new string[] {"Q-S", "J-S", "J-C", "J-D", "10-H", "6-S", "5-H", "4-C", "3-H", "2-C",}, "Straight", new string[] {"6-S", "5-H", "4-C", "3-H", "2-C",},},
            new object[] { new string[] {"Q-S", "J-S", "J-H", "J-D", "8-C", "7-S", "6-H", "5-C", "4-D", "3-S",}, "Straight", new string[] {"8-C", "7-S", "6-H", "5-C", "4-D",},},
            new object[] { new string[] {"A-C", "10-H", "9-S", "8-C", "7-S", "6-S", "5-D", "4-D", "3-D", "2-C"}, "Straight", new string[] {"10-H", "9-S", "8-C", "7-S", "6-S"},},
            new object[] { new string[] {"A-C", "K-C", "4-S", "5-H", "J-C", "10-S", "9-H", "8-D", "7-C", "6-D"}, "Straight", new string[] {"J-C", "10-S", "9-H", "8-D", "7-C",}},
            new object[] { new string[] {"A-C", "K-S", "Q-H", "J-D", "10-H", "9-H", "8-C", "6-C", "4-H", "2-S"}, "Straight", new string[] {"A-C", "K-S", "Q-H", "J-D", "10-H",},},
            new object[] { new string[] {"A-H", "K-C", "Q-C", "J-D", "10-C", "7-H", "7-C", "7-D", "6-D", "2-D"}, "Straight", new string[] {"A-H", "K-C", "Q-C", "J-D", "10-C",}},
            new object[] { new string[] {"A-D", "K-D", "Q-S", "J-H", "10-H", "6-S", "5-S", "4-D", "3-H", "2-H"}, "Straight", new string[] {"A-D", "K-D", "Q-S", "J-H", "10-H",},},
            new object[] { new string[] {"A-C", "K-D", "Q-S", "J-D", "10-S", "7-H", "5-S", "5-C", "5-D", "4-S"}, "Straight", new string[] {"A-C", "K-D", "Q-S", "J-D", "10-S",}},
            new object[] { new string[] {"J-C", "10-S", "7-D", "6-S", "5-H", "4-S", "4-H", "4-D", "3-C", "2-H"}, "Straight", new string[] {"7-D", "6-S", "5-H", "4-S", "3-C",}},
            new object[] { new string[] {"K-C", "J-H", "10-S", "9-C", "8-H", "7-S", "6-H", "5-D", "3-S", "2-C"}, "Straight", new string[] {"J-H", "10-S", "9-C", "8-H", "7-S",}},
            new object[] { new string[] {"K-H", "10-H", "9-C", "8-S", "8-C", "8-D", "7-S", "6-S", "5-H", "4-D"}, "Straight", new string[] {"10-H", "9-C", "8-S", "7-S", "6-S",}},
            new object[] { new string[] {"K-S", "K-C", "K-D", "Q-S", "9-H", "6-H", "5-D", "4-C", "3-S", "2-D"}, "Straight", new string[] {"6-H", "5-D", "4-C", "3-S", "2-D",}},
            new object[] { new string[] {"K-D", "Q-D", "J-S", "9-D", "8-H", "7-D", "6-D", "5-C", "4-S", "2-C"}, "Flush", new string[] {"K-D", "Q-D", "9-D", "7-D", "6-D",}},
            new object[] { new string[] {"K-D", "Q-S", "J-S", "10-S", "9-S", "7-S", "6-D", "5-S", "3-S", "2-C"}, "Flush", new string[] {"Q-S", "J-S", "10-S", "9-S", "7-S",}},
            new object[] { new string[] {"K-S", "Q-S", "J-D", "10-S", "9-D", "8-H", "7-S", "6-S", "5-H", "4-S"}, "Flush", new string[] {"K-S", "Q-S", "10-S", "7-S", "6-S",}},
            new object[] { new string[] {"A-D", "Q-H", "J-H", "10-D", "9-C", "8-S", "7-C", "6-C", "5-C", "4-C"}, "Flush", new string[] {"9-C","7-C", "6-C", "5-C", "4-C",}},
            new object[] { new string[] {"A-H", "K-H", "Q-H", "J-S", "10-H", "9-S", "8-S", "7-H", "6-S", "2-H"}, "Flush", new string[] {"A-H", "K-H", "Q-H", "10-H", "7-H",},},
            new object[] { new string[] {"A-H", "K-S", "Q-S", "J-S", "7-S", "7-C", "7-D", "5-S", "4-S", "3-S"}, "Flush", new string[] {"K-S", "Q-S", "J-S", "7-S", "5-S",}},
            new object[] { new string[] {"A-H", "Q-D", "J-S", "9-S", "8-D", "6-D", "5-D", "4-C", "3-C", "2-D"}, "Flush", new string[] {"Q-D","8-D", "6-D", "5-D", "2-D",}},
            new object[] { new string[] {"A-S", "A-H", "A-D", "K-H", "Q-H", "9-D", "8-H", "6-H", "5-S", "4-C"}, "Flush", new string[] {"A-H", "K-H", "Q-H", "8-H", "6-H",}},
            new object[] { new string[] {"A-S", "Q-S", "J-S", "10-C", "9-S", "8-H", "7-D", "4-H", "3-H", "2-S"}, "Flush", new string[] {"A-S", "Q-S", "J-S","9-S", "2-S",}},
        };

        return (object[]) data.Select(
            datum => {
                string[] cardStrings = (string[]) datum[0];
                string[] expectedCardStrings = (string[]) datum[2];

                List<Card> ProvidedCards = cardStrings.Select(
                    cardString => {
                        var cb = new CardBuilder(); return cb.fromString(cardString);
                    }
                ).ToList();

                List<Card> ExpectedCards = expectedCardStrings.Select(
                    cardString => {
                        var cb = new CardBuilder(); return cb.fromString(cardString);
                    }
                ).ToList();

                string cardClass = (string) datum[1];
                var Instantiator = new Dictionary<string, Func<List<Card>, Hand>> {
                    {"Flush", cards => { return new Flush(cards); } },
                    {"FourOfAKind", cards => { return new FourOfAKind(cards); } },
                    {"FullHouse", cards => { return new FullHouse(cards); } },
                    {"HighCard", cards => { return new HighCard(cards); } },
                    {"RoyalFlush", cards => { return new RoyalFlush(cards); } },
                    {"SteelWheel", cards => { return new SteelWheel(cards); } },
                    {"Straight", cards => { return new Straight(cards); } },
                    {"StraightFlush", cards => { return new StraightFlush(cards); } },
                    {"ThreeOfAKind", cards => { return new ThreeOfAKind(cards); } },
                    {"TwoOfAKind", cards => { return new TwoOfAKind(cards); } },
                    {"TwoPair", cards => { return new TwoPair(cards); } },
                    {"Wheel", cards => { return new Wheel(cards); } },
                };

                return new object[] { ProvidedCards, Instantiator[cardClass].Invoke(ExpectedCards) };
            }
        ).ToArray();
    }

    private string printCards(List<Card> Cards) {
        Cards.Sort((Card1, Card2) => Card1.compareTo(Card2));
        return String.Join(
            " ",
            Cards.AsEnumerable<Card>().Select(card => card.ToString())
        );
    }
}
