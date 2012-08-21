<?php

class SteelWheelSpecificationTest extends PokerTestCase {

    /**
     * @var SteelWheelSpecification
     */
    private $_Specification;

    protected function setUp() {
        $this->_Specification = new SteelWheelSpecification();
    }

    /**
     * @test
     * @return void
     */
    public function shouldBeAbleToIdentifyAClubsSteelWheel() {
        $Hand = new Hand($this->_theFiveCardsAre('5-C', '4-C', '3-C', '2-C', 'A-C'));
        $this->assertTrue($this->_Specification->isSatisfiedBy($Hand), 'This is a valid SteelWheel, why did it not satisfy the specification?');
    }

    /**
     * @test
     * @return void
     */
    public function shouldNotBeSatisfiedByJustAFlush() {
        $Hand = new Hand($this->_theFiveCardsAre('Q-C', '6-C', '10-C', '9-C', '8-C'));
        $this->assertFalse($this->_Specification->isSatisfiedBy($Hand), 'Not just any Flush can be a SteelWheel!');
    }

    /**
     * @test
     * @return void
     */
    public function shouldNotBeSatisfiedByJustAStraight() {
        $Hand = new Hand($this->_theFiveCardsAre('5-C', '4-C', '3-C', '2-C', 'A-D'));
        $this->assertFalse($this->_Specification->isSatisfiedBy($Hand), 'Not just any Straight can be a SteelWheel!');
    }

    /**
     * @test
     * @return void
     */
    public function shouldNotBeSatisfiedByJustAStraightFlush() {
        $Hand = new Hand($this->_theFiveCardsAre('J-C', '10-C', '9-C', '8-C', '7-C'));
        $this->assertFalse($this->_Specification->isSatisfiedBy($Hand), 'Not just any StraightFlush can be a SteelWheel!');
    }
}