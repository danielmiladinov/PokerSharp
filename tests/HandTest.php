<?php

class HandTest extends PokerTestCase
{
    /**
     * @test
     * @param string $card1
     * @param string $card2
     * @param string $card3
     * @param string $card4
     * @param string $card5
     * @param string $expectedHighCard
     * @dataProvider getSomeCardsAndTheirExpectedHighCards
     */
    public function willReturnTheCorrectHighFaceValueCard($card1, $card2, $card3, $card4, $card5, $expectedHighCard)
    {
        $Hand = $this->_theFiveCardsAre($card1, $card2, $card3, $card4, $card5);
        $this->assertEquals($this->_makeCardFromString($expectedHighCard), $Hand->getHighCard());
    }

    /**
     * @return array
     */
    public function getSomeCardsAndTheirExpectedHighCards()
    {
        return array(
            array('K-C', '7-S', '3-D', 'A-H', '10-C', 'A-H',),
            array('2-S', '3-S', '4-S', '6-S', '2-H', '6-S',),
            array('4-D', '7-C', '6-S', '5-C', '3-H', '7-C',),
            array('J-H', '3-C', 'Q-D', 'K-D', '7-S', 'K-D',),
        );
    }
}
