<?php

class RoyalFlushSpecificationTest extends PokerTestCase {
    /**
     * @var RoyalFlushSpecification
     */
    private $_Specification;


    protected function setUp() {
        $this->_Specification = new RoyalFlushSpecification();
    }

    /**
     * @test
     * @return void
     */
    public function shouldBeSatisfiedByASpadesRoyalFlush() {
        $Hand = new Hand($this->_theFiveCardsAre('A-S', 'K-S', 'Q-S', 'J-S', '10-S'));
        $this->assertTrue($this->_Specification->isSatisfiedBy($Hand), 'This is a valid RoyalFlush, why did it not satisfy the specification?');
    }

    /**
     * @test
     * @return void
     */
    public function shouldNotBeSatisfiedByAStraightFlush() {
        $Hand = new Hand($this->_theFiveCardsAre('K-S', 'Q-S', 'J-S', '10-S', '9-S'));
        $this->assertFalse($this->_Specification->isSatisfiedBy($Hand), 'Not just any StraightFlush can be a RoyalFlush!');
    }

    /**
     * @test
     * @return void
     */
    public function shouldNotBeSatisfiedByAnAceHighCard() {
        $Hand = new Hand($this->_theFiveCardsAre('A-H', '2-S', '3-C', 'J-D', '7-D'));
        $this->assertFalse($this->_Specification->isSatisfiedBy($Hand), 'Not just any Ace HighCard can be a RoyalFlush!');
    }

    /**
     * @test
     * @return void
     */
    public function shouldNotBeSatisfiedByAnAceHighNonFlushStraight() {
        $Hand = new Hand($this->_theFiveCardsAre('A-H', 'K-H', 'Q-C', 'J-H', '10-H'));
        $this->assertFalse($this->_Specification->isSatisfiedBy($Hand), 'Not just any Ace high Straight can be a RoyalFlush!');
    }
}