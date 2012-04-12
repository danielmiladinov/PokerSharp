<?php

class SteelWheelSpecification extends StraightFlushSpecification {

    /**
     * @param Hand $Hand
     * @return boolean
     */
    public function isSatisfiedBy(Hand $Hand) {
        return parent::isSatisfiedBy($Hand) && $Hand->isWheel();
    }
}
