<?php

abstract class Card
{
    const JACK = 11;
    const QUEEN = 12;
    const KING = 13;
    const ACE = 14;

    /**
     * @var int
     */
    protected $_faceValue;

    /**
     * @var Suit
     */
    protected $_Suit;

    /**
     * @param int $faceValue
     */
    public function __construct($faceValue = 0)
    {
        $this->_faceValue = $faceValue;
    }

    /**
     * @static
     * @param Suit $Suit
     * @return Card
     */
    public static function aceOf(Suit $Suit)
    {
        return $Suit->getCard(self::ACE);
    }

    /**
     * @static
     * @param Suit $Suit
     * @return Card
     */
    public static function twoOf(Suit $Suit)
    {
        return $Suit->getCard(2);
    }

    /**
     * @param Suit $Suit
     * @return Card
     */
    public static function threeOf(Suit $Suit)
    {
        return $Suit->getCard(3);
    }

    /**
     * @param Suit $Suit
     * @return Card
     */
    public static function fourOf(Suit $Suit)
    {
        return $Suit->getCard(4);
    }

    /**
     * @param Suit $Suit
     * @return Card
     */
    public static function fiveOf(Suit $Suit)
    {
        return $Suit->getCard(5);
    }

    /**
     * @param Suit $Suit
     * @return Card
     */
    public static function sixOf(Suit $Suit)
    {
        return $Suit->getCard(6);
    }

    /**
     * @param Suit $Suit
     * @return Card
     */
    public static function sevenOf(Suit $Suit)
    {
        return $Suit->getCard(7);
    }

    /**
     * @param Suit $Suit
     * @return Card
     */
    public static function eightOf(Suit $Suit)
    {
        return $Suit->getCard(8);
    }

    /**
     * @param Suit $Suit
     * @return Card
     */
    public static function nineOf(Suit $Suit)
    {
        return $Suit->getCard(9);
    }

    /**
     * @param Suit $Suit
     * @return Card
     */
    public static function tenOf(Suit $Suit)
    {
        return $Suit->getCard(10);
    }

    /**
     * @param Suit $Suit
     * @return Card
     */
    public static function jackOf(Suit $Suit)
    {
        return $Suit->getCard(self::JACK);
    }

    /**
     * @param Suit $Suit
     * @return Card
     */
    public static function queenOf(Suit $Suit)
    {
        return $Suit->getCard(self::QUEEN);
    }

    /**
     * @param Suit $Suit
     * @return Card
     */
    public static function kingOf(Suit $Suit)
    {
        return $Suit->getCard(self::KING);
    }

    /**
     * @return int
     */
    public function getFaceValue()
    {
        return $this->_faceValue;
    }

    /**
     * @return string
     */
    public function getSuit()
    {
        return $this->_Suit->getName();
    }

    /**
     * @return int
     */
    public function getSuitValue()
    {
        return $this->_Suit->getValue();
    }

    /**
     * @return string
     */
    public function __toString()
    {
        switch ($this->getFaceValue()) {
            case self::ACE:
                $faceValue = 'A';
                break;
            case self::KING:
                $faceValue = 'K';
                break;
            case self::QUEEN:
                $faceValue = 'Q';
                break;
            case self::JACK:
                $faceValue = 'J';
                break;
            default:
                $faceValue = $this->getFaceValue();
                break;
        }
        return $faceValue . '-' . substr($this->getSuit(), 0, 1);
    }

    /**
     * @param Card $OtherCard
     * @return int
     */
    public function compareTo(Card $OtherCard)
    {
        if ($this->getFaceValue() == $OtherCard->getFaceValue()) {
            $comparison = $OtherCard->getSuitValue() - $this->getSuitValue();
        } else {
            $comparison = $OtherCard->getFaceValue() - $this->getFaceValue();
        }

        return $comparison;
    }
}