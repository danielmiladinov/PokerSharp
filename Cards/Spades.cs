namespace PokerSharp.Cards {
    class Spades : Card {

        public Spades (int faceValue) : base(faceValue) {
            Suit = Suit.Spades();
        }
    }
}