<?php

abstract class HandSpecification {

    /**
     * @abstract
     * @param Hand $Hand
     * @return boolean
     */
    public abstract function isSatisfiedBy(Hand $Hand);

    /**
     * @abstract
     * @param Hand $Hand
     * @return Hand
     */
    public abstract function newHand(Hand $Hand);
}