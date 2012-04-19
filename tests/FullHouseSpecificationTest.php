<?php

class FullHouseSpecificationTest extends PokerTestCase {

    /**
     * @var FullHouseSpecification
     */
    private $_Specification;

    protected function setUp() {
        $this->_Specification = new FullHouseSpecification();
    }

    /**
     * @test
     * @param string $card1
     * @param string $card2
     * @param string $card3
     * @param string $card4
     * @param string $card5
     * @dataProvider getManyPossibleFullHouses
     * @return void
     */
    public function shouldBeAbleToIdentifyAnyFullHouse($card1, $card2, $card3, $card4, $card5) {
        $Hand = new Hand($this->_theFiveCardsAre($card1, $card2, $card3, $card4, $card5));
        $this->assertTrue($this->_Specification->isSatisfiedBy($Hand), 'This is a valid FullHouse, why did not satisfy the specification?');
    }

    /**
     * @test
     * @return void
     */
    public function shouldNotBeSatisfiedByJustAThreeOfAKind() {
        $Hand = new Hand($this->_theFiveCardsAre('A-S', 'A-H', 'A-C', 'J-D', '3-S'));
        $this->assertFalse($this->_Specification->isSatisfiedBy($Hand), 'No ThreeOfAKind can be a FullHouse!');
    }

    /**
     * @return array
     */
    public function getManyPossibleFullHouses() {
        $values = array('2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A');

        $getRandomSuits = function ($numSuits) {
            $suits = array('S', 'H', 'C', 'D');

            return array_map(
                function ($suitIndex) use ($suits) {
                    return $suits[$suitIndex];
                },
                array_rand($suits, $numSuits)
            );
        };

        $fullHouses = array();

        foreach ($values as $trioValue) {
            $otherValues = array_filter(
                $values,
                function ($otherValue) use ($trioValue) {
                    return $otherValue != $trioValue;
                }
            );

            foreach ($otherValues as $duoValue) {
                $trio = array_map(
                    function ($suit) use ($trioValue) {
                        return "{$trioValue}-{$suit}";
                    },
                    $getRandomSuits(3)
                );
                $duo = array_map(
                    function ($suit) use ($duoValue) {
                        return "{$duoValue}-{$suit}";
                    },
                    $getRandomSuits(2)
                );

                $fullHouses[] = array_merge($trio, $duo);
            }
        }

        return $fullHouses;
    }
}
