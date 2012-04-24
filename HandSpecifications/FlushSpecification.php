<?php

class FlushSpecification extends HandSpecification {

    /**
     * @param Hand $Hand
     * @return boolean
     */
    public function isSatisfiedBy(Hand $Hand) {
        return $this->_canBeAFlush($Hand);
    }
}
