<?php
class BestHandIdentifier
{
    private $_RoyalFlush;
    private $_StraightFlush;
    private $_SteelWheel;
    private $_FourOfAKind;
    private $_FullHouse;
    private $_Flush;
    private $_Straight;
    private $_Wheel;
    private $_ThreeOfAKind;
    private $_TwoPair;
    private $_TwoOfAKind;

    public function __construct()
    {
        $this->_RoyalFlush = new RoyalFlushSpecification();
        $this->_StraightFlush = new StraightFlushSpecification();
        $this->_SteelWheel = new SteelWheelSpecification();
        $this->_FourOfAKind = new FourOfAKindSpecification();
        $this->_FullHouse = new FullHouseSpecification();
        $this->_Flush = new FlushSpecification();
        $this->_Straight = new StraightSpecification();
        $this->_Wheel = new WheelSpecification();
        $this->_ThreeOfAKind = new ThreeOfAKindSpecification();
        $this->_TwoPair = new TwoPairSpecification();
        $this->_TwoOfAKind = new TwoOfAKindSpecification();
    }

    /**
     * @param \Card[] $Cards
     * @return Hand
     */
    public function identify(array $Cards)
    {
        $SortedCards = $this->_sortCards($Cards);
        $Hand = new Hand($SortedCards);

        if ($this->_RoyalFlush->isSatisfiedBy($Hand)) {
            return $this->_RoyalFlush->newHand($Hand);
        } else if ($this->_SteelWheel->isSatisfiedBy($Hand)) {
            return $this->_SteelWheel->newHand($Hand);
        } else if ($this->_StraightFlush->isSatisfiedBy($Hand)) {
            return $this->_StraightFlush->newHand($Hand);
        } else if ($this->_FourOfAKind->isSatisfiedBy($Hand)) {
            return $this->_FourOfAKind->newHand($Hand);
        } else if ($this->_FullHouse->isSatisfiedBy($Hand)) {
            return $this->_FullHouse->newHand($Hand);
        } else if ($this->_Flush->isSatisfiedBy($Hand)) {
            return $this->_Flush->newHand($Hand);
        } else if ($this->_Wheel->isSatisfiedBy($Hand)) {
            return new Wheel($SortedCards);
        } else if ($this->_Straight->isSatisfiedBy($Hand)) {
            return $this->_Straight->newHand($Hand);
        } else if ($this->_ThreeOfAKind->isSatisfiedBy($Hand)) {
            return $this->_ThreeOfAKind->newHand($Hand);
        } else if ($this->_TwoPair->isSatisfiedBy($Hand)) {
            return new TwoPair($SortedCards);
        } else if ($this->_TwoOfAKind->isSatisfiedBy($Hand)) {
            return $this->_TwoOfAKind->newHand($Hand);
        } else {
            return new HighCard($SortedCards);
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
     * @param Card[] $Cards
     * @return boolean
     */
    private function _canMakeAFlush($Cards)
    {
        $Suits = array();
        foreach ($Cards as $Card) {
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
     * @param \Card[] $CardsGroupedByValue
     * @return TwoPair
     */
    private function _makeTwoPair($CardsGroupedByValue)
    {
        // Ensure that the pairs of cards are in the front of the array
        usort(
            $CardsGroupedByValue,
            function (array $Cards1, array $Cards2) {
                return count($Cards2) - count($Cards1);
            }
        );

        // Pop off the pairs
        $CardsForTwoPair = array_merge(
            array_shift($CardsGroupedByValue),
            array_shift($CardsGroupedByValue)
        );

        // Add the next highest card that wasn't part of a pair
        $CardsForTwoPair[] =  array_shift(
            $this->_sortCards(
                array_map(
                    function (array $Cards) {
                        return array_pop($Cards);
                    },
                    $CardsGroupedByValue
                )
            )
        );

        return new TwoPair($CardsForTwoPair);
    }
}
