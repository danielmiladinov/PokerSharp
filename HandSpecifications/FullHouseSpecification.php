<?php

class FullHouseSpecification {

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

        if ($highestCount == 3) {
            $nextHighestCount = array_pop($faceValueCounts);
            return $nextHighestCount == 2;
        } else {
            return false;
        }
    }
}
