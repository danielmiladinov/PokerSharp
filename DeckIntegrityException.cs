using System;

class DeckIntegrityException : Exception {
    public DeckIntegrityException(string message) : base(message) {
    }
}