<?php
class BestHandIdentifierTest extends PHPUnit_Framework_TestCase
{
    /** @var BestHandIdentifier */
    private $_HandIdentifier;

    /** @var Hand */
    private $_DealtHand;

    /** @var Hand */
    private $_IdentifiedHand;

    public function setUp()
    {
        parent::setUp();
        $this->_HandIdentifier = new BestHandIdentifier();
    }

    public function testWillGetTwoOfAKind()
    {
        $this->_theFiveCardsAre('A-S', 'A-H', 'J-C', '7-C', '5-D');
        $this->_IdentifiedHand = $this->_HandIdentifier->identify($this->_DealtHand);
        $this->assertInstanceOf('TwoOfAKind', $this->_IdentifiedHand);
    }

    public function testWillGetTwoOfAKindWithADifferentPair()
    {
        $this->_theFiveCardsAre('A-S', '7-H', 'J-C', '7-C', '5-D');
        $this->_IdentifiedHand = $this->_HandIdentifier->identify($this->_DealtHand);
        $this->assertInstanceOf('TwoOfAKind', $this->_IdentifiedHand);
    }

    public function testWillGetThreeOfAKind()
    {
        $this->_theFiveCardsAre('7-S', '7-H', '7-C', 'J-C', '5-D');
        $this->_IdentifiedHand = $this->_HandIdentifier->identify($this->_DealtHand);
        $this->assertInstanceOf('ThreeOfAKind', $this->_IdentifiedHand);
    }

    public function testWillGetFourOfAKind()
    {
        $this->_theFiveCardsAre('7-D', '7-S', '7-C', '7-H', 'J-C');
        $this->_IdentifiedHand = $this->_HandIdentifier->identify($this->_DealtHand);
        $this->assertInstanceOf('FourOfAKind', $this->_IdentifiedHand);
    }

    public function testWillGetFullHouse()
    {
        $this->_theFiveCardsAre('10-H', '10-C', '10-D', '7-C', '7-D');
        $this->_IdentifiedHand = $this->_HandIdentifier->identify($this->_DealtHand);
        $this->assertInstanceOf('FullHouse', $this->_IdentifiedHand);
    }

    public function testWillGetJustAHighCard()
    {
        $this->_theFiveCardsAre('A-S', 'J-C', '7-C', '5-D', '4-S');
        $this->_IdentifiedHand = $this->_HandIdentifier->identify($this->_DealtHand);
        $this->assertInstanceOf('HighCard', $this->_IdentifiedHand);
    }

    private function _theFiveCardsAre()
    {
        $cards = func_get_args();
        if (count($cards) != 5) {
            $this->fail('lrn2count');
        }

        $this->_DealtHand = new Hand($this->_buildCardStringIntoACardArray($cards));
    }

    private function _buildCardStringIntoACardArray(array $cards)
    {
        $Cards = array();

        foreach ($cards as $cardString) {
            $Cards[] = $this->_makeCardFromString($cardString);
        }

        return $Cards;
    }

    /**
     * @param string $cardString
     * @return Card
     */
    private function _makeCardFromString($cardString)
    {
        $CardBuilder = new CardBuilder();
        return $CardBuilder->fromString($cardString);
    }
}