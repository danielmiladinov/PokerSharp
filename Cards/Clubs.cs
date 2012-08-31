namespace PokerSharp.Cards {
    class Clubs : Card {

        public Clubs (int faceValue) : base(faceValue) {
            Suit = Suit.Clubs();
        }
    }
}