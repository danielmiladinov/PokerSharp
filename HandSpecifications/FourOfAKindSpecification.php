<?php

class FourOfAKindSpecification extends CardsOfAKindSpecification {

    public function __construct() {
        parent::__construct(4);
    }

    /**
     * @param Hand $Hand
     * @return FourOfAKind
     */
    public function newHand(Hand $Hand) {
        $GroupedByValue = $Hand->getCardsGroupedByValues();
        $CardsOfHighValue = array_shift($GroupedByValue);

        if (count($CardsOfHighValue) == $this->_numberOfCards) {
            $FourOfAKindCards = array_merge(
                $CardsOfHighValue,
                array(
                    array_shift(
                        array_shift(
                            $GroupedByValue
                        )
                    )
                )
            );
        } else {
            $numberOfCards = $this->_numberOfCards;

            $FourOfAKindCards = array_merge(
                array(
                    array_shift(
                        $CardsOfHighValue
                    )
                ),
                array_shift(
                    array_filter(
                        $GroupedByValue,
                        function (array $CardsArray) use ($numberOfCards) {
                            return count($CardsArray) == $numberOfCards;
                        }
                    )
                )
            );
        }

        if (count($FourOfAKindCards) == 5) {
            return new FourOfAKind($FourOfAKindCards);
        }

        return null;
    }
}
