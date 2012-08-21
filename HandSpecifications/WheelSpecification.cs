<?php

class WheelSpecification extends StraightSpecification {

    /**
     * @param Hand $Hand
     * @return boolean
     */
    public function isSatisfiedBy(Hand $Hand) {
        return $Hand->isWheel();
    }

    /**
     * @param Hand $Hand
     * @return Wheel
     */
    public function newHand(Hand $Hand) {
        $Straight = parent::newHand($Hand);

        if ($Straight instanceof Hand && $Straight->isWheel()) {
            return new Wheel($Straight->getCards());
        } else {
            return null;
        }
    }
}