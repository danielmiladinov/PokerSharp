<?php

class FourOfAKindSpecification extends CardsOfAKindSpecification {
    /**
     * @var string
     */
    protected $_handClassName;

    public function __construct() {
        parent::__construct(4);
        $this->_handClassName = 'FourOfAKind';
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
