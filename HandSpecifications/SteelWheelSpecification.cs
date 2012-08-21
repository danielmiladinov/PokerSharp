<?php

class SteelWheelSpecification extends StraightFlushSpecification {

    /**
     * @param Hand $Hand
     * @return boolean
     */
    public function isSatisfiedBy(Hand $Hand) {
        return parent::isSatisfiedBy($Hand) && $Hand->isWheel();
    }

    /**
     * @param Hand $Hand
     * @return SteelWheel
     */
    public function newHand(Hand $Hand) {
        $StraightFlush = parent::newHand($Hand);

        if ($StraightFlush instanceof Hand && $StraightFlush->isWheel()) {
            return new SteelWheel($StraightFlush->getCards());
        } else {
            return null;
        }
    }
}
