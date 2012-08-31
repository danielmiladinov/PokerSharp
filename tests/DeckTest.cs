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
        Deck.add(CardMaker.twoOf(Suit.Hearts()));
        Deck.add(CardMaker.twoOf(Suit.Hearts()));
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
            ExpectedCards.Add(CardMaker.aceOf(suit));
            ExpectedCards.Add(CardMaker.twoOf(suit));
            ExpectedCards.Add(CardMaker.threeOf(suit));
            ExpectedCards.Add(CardMaker.fourOf(suit));
            ExpectedCards.Add(CardMaker.fiveOf(suit));
            ExpectedCards.Add(CardMaker.sixOf(suit));
            ExpectedCards.Add(CardMaker.sevenOf(suit));
            ExpectedCards.Add(CardMaker.eightOf(suit));
            ExpectedCards.Add(CardMaker.nineOf(suit));
            ExpectedCards.Add(CardMaker.tenOf(suit));
            ExpectedCards.Add(CardMaker.jackOf(suit));
            ExpectedCards.Add(CardMaker.queenOf(suit));
            ExpectedCards.Add(CardMaker.kingOf(suit));
        }

        Deck.populate();

        Assert.AreEqual(ExpectedCards, Deck.getCards());
    }
}