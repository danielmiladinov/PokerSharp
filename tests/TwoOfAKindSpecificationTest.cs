<?php

class TwoOfAKindSpecificationTest extends PokerTestCase {

    /**
     * @var TwoOfAKindSpecification
     */
    private $_Specification;

    protected function setUp() {
        $this->_Specification = new TwoOfAKindSpecification();
    }

    /**
     * @test
     * @return void
     */
    public function shouldBeSatisfiedByATwoOfAKind() {
        $Hand = new Hand($this->_theFiveCardsAre('2-C', '3-C', '4-C', '5-C', '4-H'));
        $this->assertTrue($this->_Specification->isSatisfiedBy($Hand), 'This is a valid TwoOfAKind, why did it not satisfy the specification?');
    }

    /**
     * @test
     * @return void
     */
    public function shouldNotBeSatisfiedByRandomJunkCards() {
        $Hand = new Hand($this->_theFiveCardsAre('K-H', '10-S', '3-C', '5-D', '7-S'));
        $this->assertFalse($this->_Specification->isSatisfiedBy($Hand), 'This is not a valid TwoOfAKind!');
    }

    /**
     * @test
     * @return void
     */
    public function shouldNotBeSatisfiedByAThreeOfAKind() {
        $Hand = new Hand($this->_theFiveCardsAre('K-H', 'K-S', 'K-C', '5-D', '7-S'));
        $this->assertFalse($this->_Specification->isSatisfiedBy($Hand), 'This is not a valid TwoOfAKind!');
    }

    /**
     * @test
     * @return void
     */
    public function shouldNotBeSatisfiedByAFourOfAKind() {
        $Hand = new Hand($this->_theFiveCardsAre('K-H', 'K-S', 'K-C', 'K-D', '7-S'));
        $this->assertFalse($this->_Specification->isSatisfiedBy($Hand), 'This is not a valid TwoOfAKind!');
    }
}