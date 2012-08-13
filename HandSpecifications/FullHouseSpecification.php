<?php

class FullHouseSpecification extends HandSpecification {

    /**
     * @param Hand $Hand
     * @return boolean
     */
    public function isSatisfiedBy(Hand $Hand) {
        return $this->newHand($Hand) instanceof FullHouse;
    }

    /**
     * @param Hand $Hand
     * @return FullHouse
     */
    public function newHand(Hand $Hand) {
        $HandCards = array();
        $GroupedByValue = $Hand->getCardsGroupedByValues();
        $faceValueCounts = array();

        foreach ($GroupedByValue as $faceValue => $CardsWithSameValue) {
            $faceValueCount = count($CardsWithSameValue);

            if ($faceValueCount >= 2) {
                $faceValueCounts[$faceValue] = $faceValueCount;
            }
        }

        if (count($faceValueCounts) >= 2) {
            krsort($faceValueCounts);

            list($faceValue, $faceValueCount) = each($faceValueCounts);

            if ($faceValueCount == 3) {
                $HandCards = array_merge($HandCards, $GroupedByValue[$faceValue]);

                list($nextFaceValue, $nextFaceValueCount) = each($faceValueCounts);

                if ($nextFaceValueCount >= 2) {
                    $HandCards = array_merge($HandCards, array_slice($GroupedByValue[$nextFaceValue], 0, 2));
                    return new FullHouse($HandCards);
                }
            } else if ($faceValueCount == 2) {
                $HandCards = array_merge($HandCards, $GroupedByValue[$faceValue]);

                list($nextFaceValue, $nextFaceValueCount) = each($faceValueCounts);

                if ($nextFaceValueCount == 3) {
                    $HandCards = array_merge($HandCards, array_slice($GroupedByValue[$nextFaceValue], 0, 3));
                    return new FullHouse($HandCards);
                }
            }
        }

        return null;
    }
}
