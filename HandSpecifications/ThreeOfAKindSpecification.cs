using PokerSharp.Hands;

namespace PokerSharp.HandBuilders {
    class ThreeOfAKindSpecification : CardsOfAKindSpecification {

        public ThreeOfAKindSpecification () : base(3, typeof(ThreeOfAKind)) {
        }
    }
}