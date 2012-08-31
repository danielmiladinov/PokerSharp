using System.Collections.Generic;
using PokerSharp.Cards;

namespace PokerSharp.Hands {
    class HighCard : Hand {
        public HighCard(List<Card> Cards) : base(Cards) {
        }
    }
}