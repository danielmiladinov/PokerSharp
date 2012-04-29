<?php

class WheelSpecification extends HandSpecification {

    /**
     * @param Hand $Hand
     * @return boolean
     */
    public function isSatisfiedBy(Hand $Hand) {
        return $Hand->isWheel();
    }
}
