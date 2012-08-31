namespace PokerSharp.Cards {
    class Hearts : Card {

        public Hearts (int faceValue) : base(faceValue) {
            Suit = Suit.Hearts();
        }
    }
}