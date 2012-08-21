<?php

class Suit {
    /** @staticvar string */
    const CLUBS = 'Clubs';

    /** @staticvar string */
    const HEARTS = 'Hearts';

    /** @staticvar string */
    const SPADES = 'Spades';

    /** @staticvar string */
    const DIAMONDS = 'Diamonds';

    /**
     * @var string
     */
    private $_suitName;

    /**
     * @var int
     */
    private $_suitValue;

    /**
     * @param string $suitName
     * @param int $suitValue
     */
    private function __construct($suitName, $suitValue) {
        $this->_suitName = $suitName;
        $this->_suitValue = $suitValue;
    }

    /**
     * @return Suit
     */
    public static function Spades() {
        return new Suit(self::SPADES, 4);
    }

    /**
     * @return Suit
     */
    public static function Hearts() {
        return new Suit(self::HEARTS, 3);
    }

    /**
     * @return Suit
     */
    public static function Clubs() {
        return new Suit(self::CLUBS, 2);
    }

    /**
     * @return Suit
     */
    public static function Diamonds() {
        return new Suit(self::DIAMONDS, 1);
    }

    /**
     * @return string
     */
    public function getName() {
        return $this->_suitName;
    }

    /**
     * @return int
     */
    public function getValue() {
        return $this->_suitValue;
    }

    /**
     * @param $cardValue
     * @return Card
     */
    public function getCard($cardValue) {
        $CardOfSuit = new ReflectionClass($this->_suitName);
        return $CardOfSuit->newInstance($cardValue);
    }
}