using NUnit.Framework;
using System.Collections.Generic;

abstract class PokerTestCase {

    protected List<Card> theFiveCardsAre(params string[] cards) {
        if (cards.Length != 5) {
            Assert.Fail("lrn2count");
        }

        var Cards = new List<Card>();
        var CardBuilder = new CardBuilder();

        foreach (string cardString in cards) {
            Cards.Add(CardBuilder.fromString(cardString));
        }

        return Cards;
    }
}