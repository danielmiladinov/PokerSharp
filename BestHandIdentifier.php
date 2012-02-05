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
        $CardsGroupedByValues = array();

        foreach ($AllCards as $Card) {
            $CardsGroupedByValues[$Card->getFaceValue()][] = $Card;
        }

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
            return $this->_makeTwoOfAKind($CardsGroupedByValues, $highestFaceValue);
        } else {
            return new HighCard(array_slice($this->_sortCards($AllCards), 0, 5));
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
     * @param Card[] $CardsNotOfValue
     * @return array
     */
    private function _sortCards(array $CardsNotOfValue)
    {
        usort(
            $CardsNotOfValue,
            function (Card $Card1, Card $Card2) {
                return $Card1->compareTo($Card2);
            }
        );
        return $CardsNotOfValue;
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
     * @param  $CardsGroupedByValues
     * @param  $faceValueOfKind
     * @return ThreeOfAKind
     */
    private function _makeThreeOfAKind($CardsGroupedByValues, $faceValueOfKind)
    {
        $SortedCards = $this->_sortCards($CardsGroupedByValues[$faceValueOfKind]);
        $CardsNotOfValue = $this->_getCardsNotOfFaceValue($faceValueOfKind, $CardsGroupedByValues);
        list($Kicker1, $Kicker2) = $this->_sortCards($CardsNotOfValue);
        return new ThreeOfAKind(array_merge($SortedCards, array($Kicker1, $Kicker2)));
    }

    private function _makeTwoOfAKind($CardsGroupedByValues, $faceValueOfKind)
    {
        $SortedCards = $this->_sortCards($CardsGroupedByValues[$faceValueOfKind]);
        $CardsNotOfValue = $this->_getCardsNotOfFaceValue($faceValueOfKind, $CardsGroupedByValues);
        list($Kicker1, $Kicker2, $Kicker3) = $this->_sortCards($CardsNotOfValue);
        return new TwoOfAKind(array_merge($SortedCards, array($Kicker1, $Kicker2, $Kicker3)));
    }
}
