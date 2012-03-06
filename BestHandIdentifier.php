<?php
class BestHandIdentifier
{
    /**
     * @param Hand $Hand
     * @return Hand
     */
    public function identify(Hand $Hand)
    {
        $AllCards = $Hand->getCards();
        $CardsGroupedByValues = $Hand->getCardsGroupedByValues();

        $faceValueCounts = array();

        foreach ($CardsGroupedByValues as $faceValue => $CardsWithSameValue) {
            $faceValueCounts[$faceValue] = count($CardsWithSameValue);
        }

        arsort($faceValueCounts);
        list ($highestFaceValue, $highestCount) = each($faceValueCounts);

        if ($highestCount == 4) {
            return $this->_makeFourOfAKind($CardsGroupedByValues, $highestFaceValue);
        } else if ($highestCount == 3) {
            list ($nextHighestCountFaceValue, $nextHighestCount) = each($faceValueCounts);

            if ($nextHighestCount == 2) {
                return $this->_makeFullHouse($CardsGroupedByValues, $highestFaceValue, $nextHighestCountFaceValue);
            } else {
                return $this->_makeThreeOfAKind($CardsGroupedByValues, $highestFaceValue);
            }

        } else if ($highestCount == 2) {
            if ($this->_canMakeTwoPair($CardsGroupedByValues)) {
                return $this->_makeTowPair($AllCards);
            } else {
                return $this->_makeTwoOfAKind($CardsGroupedByValues, $highestFaceValue);
            }
        } else {
            $canMakeAStraight = $this->_canMakeAStraight($CardsGroupedByValues);
            $canMakeAFlush = $this->_canMakeAFlush($AllCards);

            $SortedCards = $this->_sortCards($AllCards);
            $TestHand = new Hand($SortedCards);

            if ($canMakeAStraight && $canMakeAFlush) {
                if ($TestHand->getHighCard()->getFaceValue() == Card::ACE) {
                    return new RoyalFlush($SortedCards);
                } else if ($TestHand->isWheel()) {
                    return new SteelWheel($SortedCards);
                } else {
                    return new StraightFlush($SortedCards);
                }
            } else if ($canMakeAStraight) {
                if ($TestHand->isWheel()) {
                    return new Wheel($SortedCards);
                } else {
                    return new Straight($SortedCards);
                }
            } else if ($canMakeAFlush) {
                return new Flush($SortedCards);
            }

            return new HighCard(array_slice($SortedCards, 0, 5));
        }
    }

    /**
     * @param int $faceValue
     * @param Card[] $CardsGroupedByValues
     * @return Card[]
     */
    private function _getCardsNotOfFaceValue($faceValue, $CardsGroupedByValues)
    {
        $NotOfValue = array();
        unset($CardsGroupedByValues[$faceValue]);

        foreach ($CardsGroupedByValues as $Cards) {
            foreach ($Cards as $Card) {
                $NotOfValue[] = $Card;
            }
        }

        return $NotOfValue;
    }

    /**
     * @param Card[] $Cards
     * @return Card[]
     */
    private function _sortCards(array $Cards)
    {
        usort(
            $Cards,
            function (Card $Card1, Card $Card2) {
                return $Card1->compareTo($Card2);
            }
        );
        return $Cards;
    }

    /**
     * @param Card[][] $CardsGroupedByValues
     * @param int $faceValueOfKind
     * @return FourOfAKind
     */
    private function _makeFourOfAKind($CardsGroupedByValues, $faceValueOfKind)
    {
        $SortedCards = $this->_sortCards($CardsGroupedByValues[$faceValueOfKind]);
        $CardsNotOfValue = $this->_getCardsNotOfFaceValue($faceValueOfKind, $CardsGroupedByValues);
        list($Kicker1) = $this->_sortCards($CardsNotOfValue);
        return new FourOfAKind(array_merge($SortedCards, array($Kicker1)));
    }

    /**
     * @param Card[][] $CardsGroupedByValues
     * @param int $faceValueOfThreeOfAKind
     * @param int $faceValueOfTwoOfAKind
     * @return FullHouse
     */
    private function _makeFullHouse(
        $CardsGroupedByValues,
        $faceValueOfThreeOfAKind,
        $faceValueOfTwoOfAKind
    ) {
        $SortedThree = $this->_sortCards($CardsGroupedByValues[$faceValueOfThreeOfAKind]);
        $SortedTwo = $this->_sortCards($CardsGroupedByValues[$faceValueOfTwoOfAKind]);
        return new FullHouse(array_merge($SortedThree, $SortedTwo));
    }

    /**
     * @param Card[][] $CardsGroupedByValues
     * @param int $faceValueOfKind
     * @return ThreeOfAKind
     */
    private function _makeThreeOfAKind($CardsGroupedByValues, $faceValueOfKind)
    {
        $SortedCards = $this->_sortCards($CardsGroupedByValues[$faceValueOfKind]);
        $CardsNotOfValue = $this->_getCardsNotOfFaceValue($faceValueOfKind, $CardsGroupedByValues);
        list($Kicker1, $Kicker2) = $this->_sortCards($CardsNotOfValue);
        return new ThreeOfAKind(array_merge($SortedCards, array($Kicker1, $Kicker2)));
    }

    /**
     * @param Card[][] $CardsGroupedByValues
     * @param int $faceValueOfKind
     * @return TwoOfAKind
     */
    private function _makeTwoOfAKind($CardsGroupedByValues, $faceValueOfKind)
    {
        $SortedCards = $this->_sortCards($CardsGroupedByValues[$faceValueOfKind]);
        $CardsNotOfValue = $this->_getCardsNotOfFaceValue($faceValueOfKind, $CardsGroupedByValues);
        list($Kicker1, $Kicker2, $Kicker3) = $this->_sortCards($CardsNotOfValue);
        return new TwoOfAKind(array_merge($SortedCards, array($Kicker1, $Kicker2, $Kicker3)));
    }

    /**
     * @param Card[] $CardsGroupedByValue
     * @return boolean
     */
    private function _canMakeAStraight($CardsGroupedByValue)
    {
        ksort($CardsGroupedByValue);

        list($lowestFaceValue) = each($CardsGroupedByValue);
        list($nextHighestFaceValue) = each($CardsGroupedByValue);

        $highestFaceValue = $nextHighestFaceValue;

        while (list($theNextFaceValue) = each($CardsGroupedByValue)) {
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

    /**
     * @param Card[] $AllCards
     * @return boolean
     */
    private function _canMakeAFlush($AllCards)
    {
        $Suits = array();
        foreach ($AllCards as $Card) {
            $suit = $Card->getSuit();
            $Suits[$suit] = $suit;
        }
        $cardsAreAllOneSuit = (count($Suits) == 1);
        return $cardsAreAllOneSuit;
    }

    /**
     * @param Card[][] $CardsGroupedByValues
     * @return boolean
     */
    private function _canMakeTwoPair($CardsGroupedByValues)
    {
        $numPairsSeen = 0;
        foreach ($CardsGroupedByValues as $value => $Cards) {
            if (count($Cards) == 2) {
                $numPairsSeen++;
            }
        }

        $canMakeTwoPair = (2 == $numPairsSeen);
        return $canMakeTwoPair;
    }

    /**
     * @param $AllCards
     * @return TwoPair
     */
    private function _makeTowPair($AllCards)
    {
        return new TwoPair($AllCards);
    }
}
