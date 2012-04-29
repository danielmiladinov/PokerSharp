<?php

class ThreeOfAKindSpecificationTest extends PokerTestCase {

    /**
     * @var ThreeOfAKindSpecification
     */
    private $_Specification;

    protected function setUp() {
        $this->_Specification = new ThreeOfAKindSpecification();
    }

    /**
     * @test
     * @return void
     */
    public function shouldBeSatisfiedByAThreeOfAKind() {
        $Hand = new Hand($this->_theFiveCardsAre('J-H', 'J-C', 'J-D', '3-S', 'K-H'));
        $this->assertTrue($this->_Specification->isSatisfiedBy($Hand), 'This is a valid ThreeOfAKind, why did it not satisfy the specification?');
    }

    /**
     * @test
     * @return void
     */
    public function shouldNotBeSatisfiedByATwoOfAKind() {
        $Hand = new Hand($this->_theFiveCardsAre('J-H', 'Q-C', 'J-D', '3-S', 'K-H'));
        $this->assertFalse($this->_Specification->isSatisfiedBy($Hand), 'This is not a ThreeOfAKind!');
    }
}
