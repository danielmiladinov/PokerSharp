<?php

class TwoPairSpecificationTest extends PokerTestCase {

    /**
     * @var TwoPairSpecification
     */
    private $_Specification;

    protected function setUp() {
        $this->_Specification = new TwoPairSpecification();
    }

    /**
     * @test
     * @return void
     */
    public function shouldBeSatisfiedByATwoPair() {
        $Hand = new Hand($this->_theFiveCardsAre('A-S', '9-C', '9-D', '3-C', '3-H'));
        $this->assertTrue($this->_Specification->isSatisfiedBy($Hand), 'This is a valid TwoPair, why did it not satisfy the specification?');
    }

    /**
     * @test
     * @return void
     */
    public function shouldNotBeSatisfiedByAFullHouse() {
        $Hand = new Hand($this->_theFiveCardsAre('3-H', '3-D', '3-S', 'K-C', 'K-D'));
        $this->assertFalse($this->_Specification->isSatisfiedBy($Hand), 'This is not a valid TwoPair!');
    }
}