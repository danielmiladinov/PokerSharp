using NUnit.Framework;

[TextFixture]
class DeckTest {

    private Deck Deck;

    [Setup]
    protected override void setUp() {
        Deck = new Deck();
    }

    [Test]
    public void anEmptyDeckShouldHaveASizeOfZero() {
        Assert.AreEqual(0, Deck.size());
    }

    [Test]
    public void addingACardShouldIncreaseTheSizeByOne() {
        Deck.add(aceOf(Spades()));
        Assert.AreEqual(1, Deck.size());
    }

    [Test]
    [ExpectedException(typeof(DeckIntegrityException))]
    public void addingACardTwiceShouldCauseADeckExceptionToBeThrown() {
        Deck.add(twoOf(Hearts()));
        Deck.add(twoOf(Hearts()));
    }

    [Test]
    public void populateShouldFillTheDeckWithAll52Cards() {
        var ExpectedCards = new List<Card>();

        var Suits = {
            Spades(),
            Hearts(),
            Clubs(),
            Diamonds(),
        };

        foreach (var Suit in Suits) {
            ExpectedCards.Add(aceOf(Suit));
            ExpectedCards.Add(twoOf(Suit));
            ExpectedCards.Add(threeOf(Suit));
            ExpectedCards.Add(fourOf(Suit));
            ExpectedCards.Add(fiveOf(Suit));
            ExpectedCards.Add(sixOf(Suit));
            ExpectedCards.Add(sevenOf(Suit));
            ExpectedCards.Add(eightOf(Suit));
            ExpectedCards.Add(nineOf(Suit));
            ExpectedCards.Add(tenOf(Suit));
            ExpectedCards.Add(jackOf(Suit));
            ExpectedCards.Add(queenOf(Suit));
            ExpectedCards.Add(kingOf(Suit));
        }

        Deck.populate();

        Assert.AreEqual(ExpectedCards, Deck.getCards());
    }
}
