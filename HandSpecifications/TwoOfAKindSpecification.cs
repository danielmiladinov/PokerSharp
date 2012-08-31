using PokerSharp.Hands;

namespace PokerSharp.HandBuilders {
    class TwoOfAKindSpecification : CardsOfAKindSpecification {

        public TwoOfAKindSpecification () : base(2, typeof(TwoOfAKind)) {
        }
    }
}