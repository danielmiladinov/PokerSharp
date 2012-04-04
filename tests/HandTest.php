<?php

class HandTest extends PokerTestCase {
    /**
     * @test
     * @param string $card1
     * @param string $card2
     * @param string $card3
     * @param string $card4
     * @param string $card5
     * @param string $expectedHighCard
     * @return void
     * @dataProvider getSomeCardsAndTheirExpectedHighCards
     */
    public function willReturnTheCorrectHighFaceValueCard($card1, $card2, $card3, $card4, $card5, $expectedHighCard) {
        $Hand = new Hand($this->_asCardArray($card1, $card2, $card3, $card4, $card5));
        $this->assertEquals($this->_makeCardFromString($expectedHighCard), $Hand->getHighCard());
    }

    /**
     * @return array
     */
    public function getSomeCardsAndTheirExpectedHighCards() {
        return array(
            array('K-C', '7-S', '3-D', 'A-H', '10-C', 'A-H',),
            array('2-S', '3-S', '4-S', '6-S', '2-H', '6-S',),
            array('4-D', '7-C', '6-S', '5-C', '3-H', '7-C',),
            array('J-H', '3-C', 'Q-D', 'K-D', '7-S', 'K-D',),
        );
    }

    /**
     * @test
     * @param string $card1
     * @param string $card2
     * @param string $card3
     * @param string $card4
     * @param string $card5
     * @return void
     * @dataProvider getSomeCardsAndTheirExpectedHighCards
     */
    public function isWheelShouldReturnFalseWhenTheHandIsNotAWheel($card1, $card2, $card3, $card4, $card5) {
        $Hand = new Hand($this->_asCardArray($card1, $card2, $card3, $card4, $card5));
        $this->assertFalse($Hand->isWheel());
    }

    /**
     * @test
     * @return void
     */
    public function willReturnTheCorrectHighFaceValueCardWhenTheAceCanBePlayedLow() {
        $Hand = new Hand($this->_asCardArray('5-C', '4-C', '3-C', '2-C', 'A-C'));
        $this->assertEquals(Cards::fiveOf(Suit::Clubs()), $Hand->getHighCard());
    }

    /**
     * @test
     * @return void
     */
    public function twoHandsWithDifferentCardsShouldNotBeEqual() {
        $Hand = new Hand($this->_asCardArray('J-H', 'A-S', '5-C', '7-D', '3-C'));
        $OtherHand = new Hand($this->_asCardArray('A-C', 'K-D', '4-D', '3-S', '6-H'));

        $this->assertFalse($Hand->equals($OtherHand));
    }

    /**
     * @test
     * @return void
     */
    public function twoHandsWithTheSameCardsShouldBeEqual() {
        $Hand = new Hand($this->_asCardArray('A-S', 'K-H', 'Q-D', 'J-C', '10-S'));
        $OtherHand = new Hand($this->_asCardArray('A-S', 'K-H', 'Q-D', 'J-C', '10-S'));

        $this->assertTrue($Hand->equals($OtherHand));
    }

    /**
     * @test
     * @return void
     */
    public function twoHandsWithTheSameCardsInDifferentOrderShouldAlsoBeEqual() {
        $Hand = new Hand($this->_asCardArray('A-S', 'K-H', 'Q-D', 'J-C', '10-S'));
        $OtherHand = new Hand($this->_asCardArray('Q-D', '10-S', 'K-H', 'A-S', 'J-C'));

        $this->assertTrue($Hand->equals($OtherHand));
    }

    /**
     * @return Card[]
     */
    protected function _asCardArray() {
        return array_map(
            function ($cardString) {
                $CardBuilder = new CardBuilder();
                return $CardBuilder->fromString($cardString);
            },
            func_get_args()
        );
    }
}
