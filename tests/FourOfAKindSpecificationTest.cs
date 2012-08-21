<?php

class FourOfAKindSpecificationTest extends PokerTestCase {

    /**
     * @var FourOfAKindSpecification
     */
    private $_Specification;

    protected function setUp() {
        $this->_Specification = new FourOfAKindSpecification();
    }

    /**
     * @test
     * @param string $card1
     * @param string $card2
     * @param string $card3
     * @param string $card4
     * @param string $card5
     * @return void
     * @dataProvider getAllPossibleFoursOfAKindEachWithARandomKicker
     */
    public function shouldBeAbleToIdentifyAFourOfAKind($card1, $card2, $card3, $card4, $card5) {
        $Hand = new Hand($this->_theFiveCardsAre($card1, $card2, $card3, $card4, $card5));
        $this->assertTrue($this->_Specification->isSatisfiedBy($Hand), 'This is a valid FourOfAKind, why did it not satisfy the specification?');
    }

    /**
     * @test
     * @return void
     */
    public function shouldNotBeSatisfiedByJustAThreeOfAKind() {
        $Hand = new Hand($this->_theFiveCardsAre('A-S', 'A-H', 'A-C', 'J-D', '3-S'));
        $this->assertFalse($this->_Specification->isSatisfiedBy($Hand), 'No ThreeOfAKind can be a FourOfAKind!');
    }

    /**
     * @return array
     */
    public function getAllPossibleFoursOfAKindEachWithARandomKicker() {
        $suits = array('S', 'H', 'C', 'D');
        $values = array('2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A');
        $foursOfAKind = array();

        foreach ($values as $value) {
            $fourOfAKind = array_map(
                function ($suit) use ($value) {
                    return "{$value}-{$suit}";
                },
                $suits
            );

            $otherValues = array_diff($values, array($value));
            $randomValue = $otherValues[array_rand($otherValues)];
            $randomSuit = $suits[array_rand($suits)];
            $kicker = "{$randomValue}-{$randomSuit}";

            $fourOfAKind[] = $kicker;
            $foursOfAKind[] = $fourOfAKind;
        }

        return $foursOfAKind;
    }
}