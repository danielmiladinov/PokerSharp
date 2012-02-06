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