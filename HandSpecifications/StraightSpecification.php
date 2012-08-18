<?php

class StraightSpecification extends HandSpecification {

    /**
     * @param Hand $Hand
     * @return boolean
     */
    public function isSatisfiedBy(Hand $Hand) {
        return $this->_canBeAStraight($Hand);
    }

    /**
     * @param Hand $Hand
     * @return boolean
     */
    protected function _canBeAStraight(Hand $Hand) {
        return $this->newHand($Hand) instanceof Straight;
    }

    /**
     * @param Hand $Hand
     * @return Straight
     */
    public function newHand(Hand $Hand) {
        $StraightCards = array();
        $PreviousCard = null;

        $Cards = $Hand->getCards();

        usort(
            $Cards,
            function (Card $Card1, Card $Card2) {
                return $Card1->compareTo($Card2);
            }
        );

        foreach ($Cards as $Card) {
            if ($PreviousCard instanceof Card) {
                if ($Card->compareFaceValue($PreviousCard) == 0) {
                    continue;
                } else if ($PreviousCard->isAce() && $Card->getFaceValue() == 5) { // Wheels are Straights too, you know
                    $StraightCards[] = $Card;
                } else if ($PreviousCard->getFaceValue() - 1 == $Card->getFaceValue()) {
                    $StraightCards[] = $Card;
                } else {
                    $StraightCards = array($Card);
                }
            } else {
                $StraightCards[] = $Card;
            }

            $PreviousCard = $Card;
            if (count($StraightCards) == 5) {
                return new Straight($StraightCards);
            }
        }

        return null;
    }
}
