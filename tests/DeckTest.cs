using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;
using PokerSharp;
using PokerSharp.Cards;

[TestFixture]
class DeckTest {

    private Deck deck;

    [SetUp]
    protected void setUp() {
        deck = new Deck();
    }

    [Test]
    public void anEmptyDeckShouldHaveASizeOfZero() {
        Assert.AreEqual(0, deck.size());
    }

    [Test]
    public void addingACardShouldIncreaseTheSizeByOne() {
        deck.add(CardMaker.aceOf(Suit.Spades()));
        Assert.AreEqual(1, deck.size());
    }

    [Test]
    [ExpectedException(typeof(DeckIntegrityException))]
    public void addingACardTwiceShouldCauseADeckExceptionToBeThrown() {
        deck.add(CardMaker.twoOf(Suit.Hearts()));
        deck.add(CardMaker.twoOf(Suit.Hearts()));
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

        deck.populate();

        Assert.AreEqual(ExpectedCards, deck.getCards());
    }
}