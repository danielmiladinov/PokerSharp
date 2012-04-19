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
     * @return void
     */
    public function shouldBeAbleToIdentifyAFullHouse() {
        $Hand = new Hand($this->_theFiveCardsAre('K-H', 'K-C', 'K-S', 'J-H', 'J-S'));
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
}
