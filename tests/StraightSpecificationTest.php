<?php

class StraightSpecificationTest extends PokerTestCase {

    /**
     * @var StraightSpecification
     */
    private $_Specification;

    protected function setUp() {
        $this->_Specification = new StraightSpecification();
    }

    /**
     * @test
     * @return void
     */
    public function shouldBeSatisfiedByAStraight() {
        $Hand = new Hand($this->_theFiveCardsAre('2-H', '3-C', '4-D', '5-H', '6-S'));
        $this->assertTrue($this->_Specification->isSatisfiedBy($Hand), 'This is a valid Straight, why did it not satisfy the specification?');
    }

    /**
     * @test
     * @param string $card1
     * @param string $card2
     * @param string $card3
     * @param string $card4
     * @param string $card5
     * @return void
     * @dataProvider getSomeHandsThatAreNotStraights
     */
    public function shouldNotBeSatisfiedByHandsThatAreNotStraights($card1, $card2, $card3, $card4, $card5) {
        $Hand = new Hand($this->_theFiveCardsAre($card1, $card2, $card3, $card4, $card5));
        $this->assertFalse($this->_Specification->isSatisfiedBy($Hand, "That is not a Straight! ({$card1}, {$card2}, {$card3}, {$card4}, {$card5})"));
    }

    /**
     * @return array
     */
    public function getSomeHandsThatAreNotStraights() {

        $nonStraights = array_map(
            function () {
                $incompleteValues = array('2', '3', '4', '5', '7', '8', '9', '10', 'Q', 'K',);
                $getRandomSuits = function ($numSuits) {
                    $suits = array('S', 'H', 'C', 'D');

                    return array_map(
                        function ($suitIndex) use ($suits) {
                            return $suits[$suitIndex];
                        },
                        array_rand($suits, $numSuits)
                    );
                };

                return array_map(
                    function ($value, $suit) {
                        return "{$value}-{$suit}";
                    },
                    array_map(
                        function ($valueIndex) use ($incompleteValues) {
                            return $incompleteValues[$valueIndex];
                        },
                        array_rand($incompleteValues, 5)
                    ),
                    array_merge($getRandomSuits(3), $getRandomSuits(2))
                );
            },
            range(1, 100)
        );

        return $nonStraights;
    }

    /**
     * @test
     * @return void
     */
    public function shouldNotBeSatisfiedByAStraightFlush() {
        $Hand = new Hand($this->_theFiveCardsAre('3-H', '4-H', '5-H', '6-H', '7-H'));
        $this->assertFalse($this->_Specification->isSatisfiedBy($Hand), 'That is not just a Straight! It is also a StraightFlush!');
    }

    /**
     * @test
     * @return void
     */
    public function shouldNotBeSatisfiedByARoyalFlush() {
        $Hand = new Hand($this->_theFiveCardsAre('10-D', 'J-D', 'Q-D', 'K-D', 'A-D'));
        $this->assertFalse($this->_Specification->isSatisfiedBy($Hand), 'That is not just a Straight! It is also a RoyalFlush!');
    }
}
