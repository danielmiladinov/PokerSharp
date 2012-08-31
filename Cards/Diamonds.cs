namespace PokerSharp.Cards {
    class Diamonds : Card {

        public Diamonds (int faceValue) : base(faceValue) {
            Suit = Suit.Diamonds();
        }
    }
}