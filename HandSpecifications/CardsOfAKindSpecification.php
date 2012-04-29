<?php

abstract class CardsOfAKindSpecification extends HandSpecification {

    /**
     * @var int
     */
    protected $_numberOfCards;

    protected function __construct($numberOfCards) {
        $this->_numberOfCards = $numberOfCards;
    }

    /**
     * @param Hand $Hand
     * @return boolean
     */
    public function isSatisfiedBy(Hand $Hand) {
        $GroupedByValue = $Hand->getCardsGroupedByValues();
        $faceValueCounts = array();

        foreach ($GroupedByValue as $faceValue => $CardsWithSameValue) {
            $faceValueCounts[$faceValue] = count($CardsWithSameValue);
        }

        asort($faceValueCounts);
        $highestCount = array_pop($faceValueCounts);

        return $highestCount == $this->_numberOfCards;
    }
}
