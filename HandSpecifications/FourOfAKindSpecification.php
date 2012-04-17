<?php

class FourOfAKindSpecification {

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

        return $highestCount == 4;
    }
}
