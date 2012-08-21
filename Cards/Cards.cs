<?php

/**
 * A handy container for getting a particular face value of a given suit.
 */
class Cards {
    /**
     * @static
     * @param Suit $Suit
     * @return Card
     */
    public static function aceOf(Suit $Suit) {
        return $Suit->getCard(Card::ACE);
    }

    /**
     * @static
     * @param Suit $Suit
     * @return Card
     */
    public static function twoOf(Suit $Suit) {
        return $Suit->getCard(2);
    }

    /**
     * @param Suit $Suit
     * @return Card
     */
    public static function threeOf(Suit $Suit) {
        return $Suit->getCard(3);
    }

    /**
     * @param Suit $Suit
     * @return Card
     */
    public static function fourOf(Suit $Suit) {
        return $Suit->getCard(4);
    }

    /**
     * @param Suit $Suit
     * @return Card
     */
    public static function fiveOf(Suit $Suit) {
        return $Suit->getCard(5);
    }

    /**
     * @param Suit $Suit
     * @return Card
     */
    public static function sixOf(Suit $Suit) {
        return $Suit->getCard(6);
    }

    /**
     * @param Suit $Suit
     * @return Card
     */
    public static function sevenOf(Suit $Suit) {
        return $Suit->getCard(7);
    }

    /**
     * @param Suit $Suit
     * @return Card
     */
    public static function eightOf(Suit $Suit) {
        return $Suit->getCard(8);
    }

    /**
     * @param Suit $Suit
     * @return Card
     */
    public static function nineOf(Suit $Suit) {
        return $Suit->getCard(9);
    }

    /**
     * @param Suit $Suit
     * @return Card
     */
    public static function tenOf(Suit $Suit) {
        return $Suit->getCard(10);
    }

    /**
     * @param Suit $Suit
     * @return Card
     */
    public static function jackOf(Suit $Suit) {
        return $Suit->getCard(Card::JACK);
    }

    /**
     * @param Suit $Suit
     * @return Card
     */
    public static function queenOf(Suit $Suit) {
        return $Suit->getCard(Card::QUEEN);
    }

    /**
     * @param Suit $Suit
     * @return Card
     */
    public static function kingOf(Suit $Suit) {
        return $Suit->getCard(Card::KING);
    }

    /**
     * @static
     * @param \Card[] $Cards
     * @return \Card[]
     */
    public static function getCardsGroupedByValue(array $Cards) {
        $CardsGroupedByValues = array();

        foreach ($Cards as $Card) {
            $CardsGroupedByValues[$Card->getFaceValue()][] = $Card;
        }

        return $CardsGroupedByValues;
    }
}