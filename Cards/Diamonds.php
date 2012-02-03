<?php

class Diamonds extends Card
{
    /**
     * @param int $faceValue
     */
    public function __construct($faceValue = 0)
    {
        parent::__construct($faceValue);
        $this->_suit = self::DIAMONDS;
    }
}