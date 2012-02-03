<?php

abstract class Card
{
    const JACK = 11;
    const QUEEN = 12;
    const KING = 13;
    const ACE = 14;

    const CLUBS = 'Clubs';
    const HEARTS = 'Hearts';
    const SPADES = 'Spades';
    const DIAMONDS = 'Diamonds';

    /**
     * @var int
     */
    protected $_faceValue;

    /**
     * @var string
     */
    protected $_suit;

    /**
     * @param int $faceValue
     */
    public function __construct($faceValue = 0)
    {
        $this->_faceValue = $faceValue;
    }

    /**
     * @static
     * @param Card $Card1
     * @param Card $Card2
     * @return int
     */
    public static function compareCards(Card $Card1, Card $Card2)
    {
        return $Card1->compareTo($Card2);
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
        return $this->_suit;
    }

    /**
     * @return int
     */
    public function getSuitValue()
    {
        switch ($this->_suit) {
            case self::SPADES:
                return 4;
            case self::HEARTS:
                return 3;
            case self::CLUBS:
                return 2;
            case self::DIAMONDS:
                return 1;
        }
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