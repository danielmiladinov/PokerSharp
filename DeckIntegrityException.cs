using System;

namespace PokerSharp {
    class DeckIntegrityException : Exception {
        public DeckIntegrityException(string message) : base(message) {
        }
    }
}