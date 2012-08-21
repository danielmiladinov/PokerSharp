<?php

class TwoPairSpecification extends HandSpecification {

    /**
     * @param Hand $Hand
     * @return boolean
     */
    public function isSatisfiedBy(Hand $Hand) {
        $numPairsSeen = 0;
        $CardsGroupedByValues = $Hand->getCardsGroupedByValues();
        foreach ($CardsGroupedByValues as $Cards) {
            if (count($Cards) == 2) {
                $numPairsSeen++;
            }
        }

        $canMakeTwoPair = (2 == $numPairsSeen);
        return $canMakeTwoPair;
    }

    /**
     * @param $Hand
     * @return TwoPair
     */
    public function newHand(Hand $Hand) {
        return new TwoPair($Hand->getCards());
    }
}
