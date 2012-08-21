<?php

class FlushSpecificationTest extends PokerTestCase {

    /**
     * @var FlushSpecification
     */
    private $_Specification;

    protected function setUp() {
        $this->_Specification = new FlushSpecification();
    }

    /**
     * @test
     * @param string $card1
     * @param string $card2
     * @param string $card3
     * @param string $card4
     * @param string $card5
     * @return void
     * @dataProvider getSomePossibleFlushes
     */
    public function shouldBeAbleToIdentifyAFlush($card1, $card2, $card3, $card4, $card5) {
        $Hand = new Hand($this->_theFiveCardsAre($card1, $card2, $card3, $card4, $card5));
        $this->assertTrue($this->_Specification->isSatisfiedBy($Hand), 'This is a valid Flush, why did it not satisfy the specification?');
    }

    /**
     * @test
     * @return void
     */
    public function shouldNotBeSatisfiedByAHandWithCardsFromMoreThanOneSuit() {
        $Hand = new Hand($this->_theFiveCardsAre('A-C', '2-C', '3-H', '4-C', '5-C'));
        $this->assertFalse($this->_Specification->isSatisfiedBy($Hand), 'That is not a Flush!');
    }

    /**
     * @return array
     */
    public function getSomePossibleFlushes() {
        $values = array('2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A');
        $suits = array('S', 'H', 'C', 'D');

        $flushes = array_map(
            function () use ($values, $suits) {
                return array_map(
                    function ($valueIndex, $suit) use ($values) {
                        $value = $values[$valueIndex];
                        return "{$value}-{$suit}";
                    },
                    array_rand($values, 5),
                    array_fill(0, 5, $suits[array_rand($suits)])

                );
            },
            range(1, 100)
        );

        return $flushes;
    }
}