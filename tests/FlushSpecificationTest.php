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
     * @return void
     */
    public function shouldBeAbleToIdentifyAFlush() {
        $Hand = new Hand($this->_theFiveCardsAre('2-H', '5-H', 'J-H', '7-H', 'K-H'));
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
}
