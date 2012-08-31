using NUnit.Framework;
using System.Collections.Generic;
using PokerSharp;
using PokerSharp.Cards;

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

    protected Card makeCardFromString(string cardString) {
        var CardBuilder = new CardBuilder();
        return CardBuilder.fromString(cardString);
    }
}