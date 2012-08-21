<?php

class WheelSpecificationTest extends PokerTestCase {

    /**
     * @var WheelSpecification
     */
    private $_Specification;

    protected function setUp() {
        $this->_Specification = new WheelSpecification();
    }

    /**
     * @test
     * @return void
     */
    public function shouldBeSatisfiedByAWheel() {
        $Hand = new Hand($this->_theFiveCardsAre('5-H', '4-C', '3-S', '2-D', 'A-H'));
        $this->assertTrue($this->_Specification->isSatisfiedBy($Hand), 'This is a valid Wheel, why did it not satisfy the specification?');
    }

    /**
     * @test
     * @param string $card1
     * @param string $card2
     * @param string $card3
     * @param string $card4
     * @param string $card5
     * @return void
     * @dataProvider getSomeNonWheelHands
     */
    public function shouldNotBeSatisfiedByOtherRandomCards($card1, $card2, $card3, $card4, $card5) {
        $Hand = new Hand($this->_theFiveCardsAre($card1, $card2, $card3, $card4, $card5));
        $this->assertFalse($this->_Specification->isSatisfiedBy($Hand), "That is not a Wheel! ({$card1}, {$card2}, {$card3}, {$card4}, {$card5})");
    }

    /**
     * @return array
     */
    public function getSomeNonWheelHands() {
        return array_map(
            function () {
                $Deck = new Deck();
                $Deck->populate();
                $Cards = array_filter(
                    $Deck->getCards(),
                    function (Card $Card) {
                        return ($Card->getFaceValue() != Card::FIVE);
                    }
                );

                return array_map(
                    function ($cardIndex) use ($Cards) {
                        /** @var $Card Card */
                        $Card = $Cards[$cardIndex];
                        return $Card->__toString();
                    },
                    array_rand($Cards, 5)
                );
            },
            range(1, 100)
        );
    }

    /**
     * @test
     * @return void
     */
    public function shouldNotBeSatisfiedByHandsWithMoreThanFiveCardsButThatHaveAllTheWheelCards() {
        $Hand = new Hand(
            array_map(
                function ($cardString) {
                    $CardBuilder = new CardBuilder();
                    return $CardBuilder->fromString($cardString);
                },
                array('5-H', '4-C', '3-S', '2-D', 'A-H', '3-D')
            )
        );
        $this->assertFalse($this->_Specification->isSatisfiedBy($Hand), 'A Hand with more than 5 cards cannot be a Wheel!');
    }
}