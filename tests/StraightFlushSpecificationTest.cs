<?php

class StraightFlushSpecificationTest extends PokerTestCase {

    /**
     * @var StraightFlushSpecification
     */
    private $_Specification;

    protected function setUp() {
        $this->_Specification = new StraightFlushSpecification();
    }

    /**
     * @test
     * @return void
     */
    public function shouldBeSatisfiedByAHeartsStraightFlush() {
        $Hand = new Hand($this->_theFiveCardsAre('Q-H', 'J-H', '10-H', '9-H', '8-H'));
        $this->assertTrue($this->_Specification->isSatisfiedBy($Hand), 'This is a valid StraightFlush, why did it not satisfy the specification?');
    }

    /**
     * @test
     * @return void
     */
    public function shouldNotBeSatisfiedByJustAFlush() {
        $Hand = new Hand($this->_theFiveCardsAre('Q-C', '6-C', '10-C', '9-C', '8-C'));
        $this->assertFalse($this->_Specification->isSatisfiedBy($Hand), 'Not just any Flush can be a StraightFlush!');
    }

    /**
     * @test
     * @return void
     */
    public function shouldNotBeSatisfiedByJustAStraight() {
        $Hand = new Hand($this->_theFiveCardsAre('Q-H', 'J-C', '10-D', '9-S', '8-H'));
        $this->assertFalse($this->_Specification->isSatisfiedBy($Hand), 'Not just any Straight can be a StraightFlush!');
    }
}