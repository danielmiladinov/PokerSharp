<?php

class FlushSpecification {

    /**
     * @param Hand $Hand
     * @return boolean
     */
    public function isSatisfiedBy(Hand $Hand) {
        $Suits = array();
        foreach ($Hand->getCards() as $Card) {
            $Suits[$Card->getSuit()] = $Card->getSuit();
        }
        return (count($Suits) == 1);
    }
}
