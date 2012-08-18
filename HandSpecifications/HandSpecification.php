<?php

abstract class HandSpecification {

    /**
     * @abstract
     * @param Hand $Hand
     * @return boolean
     */
    public abstract function isSatisfiedBy(Hand $Hand);
}
