<?php

abstract class PokerTestCase extends PHPUnit_Framework_TestCase
{
    /**
     * @return Hand
     */
    protected function _theFiveCardsAre()
    {
        $cards = func_get_args();
        if (count($cards) != 5) {
            $this->fail('lrn2count');
        }

        return new Hand($this->_buildCardStringIntoACardArray($cards));
    }

    /**
     * @param array $cards
     * @return Card[]
     */
    protected function _buildCardStringIntoACardArray(array $cards)
    {
        $Cards = array();

        foreach ($cards as $cardString) {
            $Cards[] = $this->_makeCardFromString($cardString);
        }

        return $Cards;
    }

    /**
     * @param string $cardString
     * @return Card
     */
    protected function _makeCardFromString($cardString)
    {
        $CardBuilder = new CardBuilder();
        return $CardBuilder->fromString($cardString);
    }

}
