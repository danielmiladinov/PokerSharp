<?php

class Hearts extends Card
{
    /**
     * @param int $faceValue
     */
    public function __construct($faceValue = 0)
    {
        parent::__construct($faceValue);
        $this->_suit = Card::HEARTS;
    }
}