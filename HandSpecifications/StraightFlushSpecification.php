<?php

class StraightFlushSpecification {

    /**
     * @param Hand $Hand
     * @return boolean
     */
    public function isSatisfiedBy(Hand $Hand) {
        return $this->_canBeAFlush($Hand) && $this->_canBeAStraight($Hand);
    }

    /**
     * @param Hand $Hand
     * @return boolean
     */
    private function _canBeAFlush(Hand $Hand) {
        $Suits = array();
        foreach ($Hand->getCards() as $Card) {
            $suit = $Card->getSuit();
            $Suits[$suit] = $suit;
        }
        $cardsAreAllOneSuit = (count($Suits) == 1);
        return $cardsAreAllOneSuit;
    }

    /**
     * @param Hand $Hand
     * @return boolean
     */
    private function _canBeAStraight(Hand $Hand) {
        $GroupedByValue = $Hand->getCardsGroupedByValues();
        ksort($GroupedByValue);

        list($lowestFaceValue) = each($GroupedByValue);
        list($nextHighestFaceValue) = each($GroupedByValue);

        $highestFaceValue = $nextHighestFaceValue;

        while (list($theNextFaceValue) = each($GroupedByValue)) {
            $nextHighestFaceValue = $highestFaceValue;
            $highestFaceValue = $theNextFaceValue;
        }

        return (
            // The high and low value are either 4 values apart, or
            ($highestFaceValue - $lowestFaceValue == 4)
            // Treat the ace as the low value, the next highest and next lowest should be 3 apart
            || (($highestFaceValue == Card::ACE) && ($nextHighestFaceValue - $lowestFaceValue == 3))
        );
    }
}
