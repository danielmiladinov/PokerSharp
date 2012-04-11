<?php

class RoyalFlushSpecification extends StraightFlushSpecification {

    /**
     * @param Hand $Hand
     * @return boolean
     */
    public function isSatisfiedBy(Hand $Hand) {
        $handIsARoyalFlush = (
            ($Hand->getHighCard()->getFaceValue() == Card::ACE) &&
            parent::isSatisfiedBy($Hand)
        );
        return $handIsARoyalFlush;
    }
}
