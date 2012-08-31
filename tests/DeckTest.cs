using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;
using PokerSharp;

[TestFixture]
class DeckTest {

    private Deck Deck;

    [SetUp]
    protected void setUp() {
        Deck = new Deck();
    }

    [Test]
    public void anEmptyDeckShouldHaveASizeOfZero() {
        Assert.AreEqual(0, Deck.size());
    }

    [Test]
    public void addingACardShouldIncreaseTheSizeByOne() {
        Deck.add(Cards.aceOf(Suit.Spades()));
        Assert.AreEqual(1, Deck.size());
    }

    [Test]
    [ExpectedException(typeof(DeckIntegrityException))]
    public void addingACardTwiceShouldCauseADeckExceptionToBeThrown() {
        Deck.add(Cards.twoOf(Suit.Hearts()));
        Deck.add(Cards.twoOf(Suit.Hearts()));
    }

    [Test]
    public void populateShouldFillTheDeckWithAll52Cards() {
        var ExpectedCards = new List<Card>();

        Suit[] Suits = {
            Suit.Spades(),
            Suit.Hearts(),
            Suit.Clubs(),
            Suit.Diamonds(),
        };

        foreach (var suit in Suits) {
            ExpectedCards.Add(Cards.aceOf(suit));
            ExpectedCards.Add(Cards.twoOf(suit));
            ExpectedCards.Add(Cards.threeOf(suit));
            ExpectedCards.Add(Cards.fourOf(suit));
            ExpectedCards.Add(Cards.fiveOf(suit));
            ExpectedCards.Add(Cards.sixOf(suit));
            ExpectedCards.Add(Cards.sevenOf(suit));
            ExpectedCards.Add(Cards.eightOf(suit));
            ExpectedCards.Add(Cards.nineOf(suit));
            ExpectedCards.Add(Cards.tenOf(suit));
            ExpectedCards.Add(Cards.jackOf(suit));
            ExpectedCards.Add(Cards.queenOf(suit));
            ExpectedCards.Add(Cards.kingOf(suit));
        }

        Deck.populate();

        Assert.AreEqual(ExpectedCards, Deck.getCards());
    }
}