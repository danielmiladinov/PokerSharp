<?php

class StraightSpecification extends HandSpecification {

    /**
     * @param Hand $Hand
     * @return boolean
     */
    public function isSatisfiedBy(Hand $Hand) {
        return $this->_canBeAStraight($Hand) && !$this->_canBeAFlush($Hand);
    }
}
