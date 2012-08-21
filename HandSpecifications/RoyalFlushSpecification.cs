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

    /**
     * @param Hand $Hand
     * @return RoyalFlush
     */
    public function newHand(Hand $Hand) {
        $StraightFlush = parent::newHand($Hand);

        if ($StraightFlush instanceof StraightFlush && $StraightFlush->getHighCard()->getFaceValue() == Card::ACE) {
            return new RoyalFlush($StraightFlush->getCards());
        }

        return null;
    }
}
