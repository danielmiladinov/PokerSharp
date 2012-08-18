<?php

abstract class CardsOfAKindSpecification extends HandSpecification {

    /**
     * @var int
     */
    protected $_numberOfCards;

    /**
     * @var string
     */
    protected $_handClassName;

    protected function __construct($numberOfCards, $handClassName) {
        $this->_numberOfCards = $numberOfCards;
        $this->_handClassName = $handClassName;
    }

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

        return $highestCount == $this->_numberOfCards;
    }

       /**
     * @param Hand $Hand
     * @return FourOfAKind
     */
    public function newHand(Hand $Hand) {
        $GroupedByValue = $Hand->getCardsGroupedByValues();
        $CardsOfHighValue = array_shift($GroupedByValue);

        if (count($CardsOfHighValue) == $this->_numberOfCards) {
            $CardsOfAKind = array_merge(
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

            $CardsOfAKind = array_merge(
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

        if (count($CardsOfAKind) == 5) {
            $HandReflector = new ReflectionClass($this->_handClassName);
            $HandOfCardsOfAKind = $HandReflector->newInstance($CardsOfAKind);
            return $HandOfCardsOfAKind;
        }

        return null;
    }
}
