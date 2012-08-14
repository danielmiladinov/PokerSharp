<?php
class BestHandIdentifierTest extends PokerTestCase {
    /** @var BestHandIdentifier */
    private $_HandIdentifier;

    /** @var Hand */
    private $_DealtHand;

    /** @var Hand */
    private $_IdentifiedHand;

    public function setUp() {
        parent::setUp();
        $this->_HandIdentifier = new BestHandIdentifier();
    }

    protected function assertPostConditions() {
        if ($this->_IdentifiedHand instanceof Hand) {
            $CardsInHand = $this->_IdentifiedHand->getCards();
            $this->assertEquals(5, count($CardsInHand), get_class($this->_IdentifiedHand) . " ({$this->_printCards($CardsInHand)}) did not have 5 cards");
        }
    }

    public function testWillGetJustAHighCard() {
        $this->_DealtHand = $this->_theFiveCardsAre('A-S', 'J-C', '7-C', '5-D', '4-S');
        $this->_IdentifiedHand = $this->_HandIdentifier->identify($this->_DealtHand);
        $this->assertInstanceOf('HighCard', $this->_IdentifiedHand);
    }

    public function testWillGetTwoOfAKind() {
        $this->_DealtHand = $this->_theFiveCardsAre('A-S', 'A-H', 'J-C', '7-C', '5-D');
        $this->_IdentifiedHand = $this->_HandIdentifier->identify($this->_DealtHand);
        $this->assertInstanceOf('TwoOfAKind', $this->_IdentifiedHand);
    }

    public function testWillGetTwoOfAKindWithADifferentPair() {
        $this->_DealtHand = $this->_theFiveCardsAre('A-S', '7-H', 'J-C', '7-C', '5-D');
        $this->_IdentifiedHand = $this->_HandIdentifier->identify($this->_DealtHand);
        $this->assertInstanceOf('TwoOfAKind', $this->_IdentifiedHand);
    }

    /**
     * @test
     * @param string $card1
     * @param string $card2
     * @param string $card3
     * @param string $card4
     * @param string $card5
     * @return void
     * @dataProvider getSomeCandidatesForATwoPair
     */
    public function willGetTwoPair($card1, $card2, $card3, $card4, $card5) {
        $this->_DealtHand = $this->_theFiveCardsAre($card1, $card2, $card3, $card4, $card5);
        $this->_IdentifiedHand = $this->_HandIdentifier->identify($this->_DealtHand);
        $this->assertInstanceOf('TwoPair', $this->_IdentifiedHand);
    }

    /**
     * @return array
     */
    public function getSomeCandidatesForATwoPair() {
        return array(
            array('A-H', 'A-C', '7-C', '3-D', '7-S'),
            array('K-D', 'J-S', 'K-H', 'A-S', 'J-C'),
            array('2-C', '5-D', '6-H', '2-D', '5-H'),
            array('10-C', '10-S', '9-D', '8-H', '9-S'),
        );
    }

    public function testWillGetThreeOfAKind() {
        $this->_DealtHand = $this->_theFiveCardsAre('7-S', '7-H', '7-C', 'J-C', '5-D');
        $this->_IdentifiedHand = $this->_HandIdentifier->identify($this->_DealtHand);
        $this->assertInstanceOf('ThreeOfAKind', $this->_IdentifiedHand);
    }

    /**
     * @test
     * @param string $card1
     * @param string $card2
     * @param string $card3
     * @param string $card4
     * @param string $card5
     * @return void
     * @dataProvider getSomeCandidatesForAStraight
     */
    public function willGetAStraight($card1, $card2, $card3, $card4, $card5) {
        $this->_DealtHand = $this->_theFiveCardsAre($card1, $card2, $card3, $card4, $card5);
        $this->_IdentifiedHand = $this->_HandIdentifier->identify($this->_DealtHand);
        $this->assertInstanceOf('Straight', $this->_IdentifiedHand);
    }

    /**
     * @return array
     */
    public function getSomeCandidatesForAStraight() {
        return array(
            array('A-D', '2-S', '3-H', '4-C', '5-D',),
            array('2-S', '3-H', '4-C', '5-D', '6-S',),
            array('3-H', '4-C', '5-D', '6-S', '7-H',),
            array('4-C', '5-D', '6-S', '7-H', '8-C',),
            array('5-D', '6-S', '7-H', '8-C', '9-D',),
            array('6-S', '7-H', '8-C', '9-D', '10-S',),
            array('7-H', '8-C', '9-D', '10-S', 'J-H',),
            array('8-C', '9-D', '10-S', 'J-H', 'Q-C',),
            array('9-D', '10-S', 'J-H', 'Q-C', 'K-D',),
            array('10-S', 'J-H', 'Q-C', 'K-D', 'A-S',),
        );
    }

    /**
     * @test
     * @param string $card1
     * @param string $card2
     * @param string $card3
     * @param string $card4
     * @param string $card5
     * @return void
     * @dataProvider getSomeCandidatesForAFlush
     */
    public function willGetAFlush($card1, $card2, $card3, $card4, $card5) {
        $this->_DealtHand = $this->_theFiveCardsAre($card1, $card2, $card3, $card4, $card5);
        $this->_IdentifiedHand = $this->_HandIdentifier->identify($this->_DealtHand);
        $this->assertInstanceOf('Flush', $this->_IdentifiedHand);
    }

    /**
     * @return array
     */
    public function getSomeCandidatesForAFlush() {
        return array(
            array('2-D', '4-D', '6-D', '9-D', '10-D',),
            array('A-C', '3-C', '5-C', 'J-C', 'Q-C',),
            array('3-H', '5-H', '7-H', '8-H', '9-H',),
            array('4-S', '6-S', '8-S', '10-S', 'J-S',),
        );
    }

    public function testWillGetFullHouse() {
        $this->_DealtHand = $this->_theFiveCardsAre('10-H', '10-C', '10-D', '7-C', '7-D');
        $this->_IdentifiedHand = $this->_HandIdentifier->identify($this->_DealtHand);
        $this->assertInstanceOf('FullHouse', $this->_IdentifiedHand);
    }

    public function testWillGetFourOfAKind() {
        $this->_DealtHand = $this->_theFiveCardsAre('7-D', '7-S', '7-C', '7-H', 'J-C');
        $this->_IdentifiedHand = $this->_HandIdentifier->identify($this->_DealtHand);
        $this->assertInstanceOf('FourOfAKind', $this->_IdentifiedHand);
    }

    /**
     * @test
     * @param string $card1
     * @param string $card2
     * @param string $card3
     * @param string $card4
     * @param string $card5
     * @return void
     * @dataProvider getSomeCandidatesForAStraightFlush
     */
    public function willGetAStraightFlush($card1, $card2, $card3, $card4, $card5) {
        $this->_DealtHand = $this->_theFiveCardsAre($card1, $card2, $card3, $card4, $card5);
        $this->_IdentifiedHand = $this->_HandIdentifier->identify($this->_DealtHand);
        $this->assertInstanceOf('StraightFlush', $this->_IdentifiedHand);
    }

    /**
     * @return array
     */
    public function getSomeCandidatesForAStraightFlush() {
        return array(
            array('7-H', '6-H', '5-H', '4-H', '3-H',),
            array('5-S', '4-S', '3-S', '2-S', 'A-S',),
            array('J-C', '10-C', '9-C', '8-C', '7-C',),
            array('K-D', 'Q-D', 'J-D', '10-D', '9-D',),
        );
    }

    /**
     * @test
     * @param string $card1
     * @param string $card2
     * @param string $card3
     * @param string $card4
     * @param string $card5
     * @return void
     * @dataProvider getSomeCandidatesForASteelWheel
     */
    public function willGetASteelWheel($card1, $card2, $card3, $card4, $card5) {
        $this->_DealtHand = $this->_theFiveCardsAre($card1, $card2, $card3, $card4, $card5);
        $this->_IdentifiedHand = $this->_HandIdentifier->identify($this->_DealtHand);
        $this->assertInstanceOf('SteelWheel', $this->_IdentifiedHand);
    }

    /**
     * @return array
     */
    public function getSomeCandidatesForASteelWheel() {
        return array(
            array('5-S', '4-S', '3-S', '2-S', 'A-S',),
            array('5-H', '4-H', '3-H', '2-H', 'A-H',),
            array('5-C', '4-C', '3-C', '2-C', 'A-C',),
            array('5-D', '4-D', '3-D', '2-D', 'A-D',),
        );
    }

    /**
     * @test
     * @param string $card1
     * @param string $card2
     * @param string $card3
     * @param string $card4
     * @param string $card5
     * @return void
     * @dataProvider getSomeCandidatesForAWheel
     */
    public function willGetARegularWheel($card1, $card2, $card3, $card4, $card5) {
        $this->_DealtHand = $this->_theFiveCardsAre($card1, $card2, $card3, $card4, $card5);
        $this->_IdentifiedHand = $this->_HandIdentifier->identify($this->_DealtHand);
        $this->assertInstanceOf('Wheel', $this->_IdentifiedHand);
    }

    /**
     * @return array
     */
    public function getSomeCandidatesForAWheel() {
        return array(
            array('5-S', '4-H', '3-C', '2-D', 'A-S',),
            array('5-H', '4-C', '3-D', '2-S', 'A-H',),
            array('5-C', '4-D', '3-S', '2-H', 'A-C',),
            array('5-D', '4-S', '3-H', '2-C', 'A-D',),
        );
    }

    /**
     * @test
     * @param string $card1
     * @param string $card2
     * @param string $card3
     * @param string $card4
     * @param string $card5
     * @return void
     * @dataProvider getSomeCandidatesForARoyalFlush
     */
    public function willGetARoyalFlush($card1, $card2, $card3, $card4, $card5) {
        $this->_DealtHand = $this->_theFiveCardsAre($card1, $card2, $card3, $card4, $card5);
        $this->_IdentifiedHand = $this->_HandIdentifier->identify($this->_DealtHand);
        $this->assertInstanceOf('RoyalFlush', $this->_IdentifiedHand);
    }

    /**
     * @return array
     */
    public function getSomeCandidatesForARoyalFlush() {
        return array(
            array('10-D', 'J-D', 'Q-D', 'K-D', 'A-D',),
            array('10-S', 'J-S', 'Q-S', 'K-S', 'A-S',),
            array('10-H', 'J-H', 'Q-H', 'K-H', 'A-H',),
            array('10-C', 'J-C', 'Q-C', 'K-C', 'A-C',),
        );
    }

    /**
     * @test
     * @param \Card[] $Cards
     * @param \Hand $ExpectedBestHand
     * @return void
     * @dataProvider getSomeCardsAndTheExpectedBestHandFromThem
     */
    public function shouldBeAbleToIdentifyTheBestPossibleHandOutOfSeveralPossible(array $Cards, Hand $ExpectedBestHand) {
        $this->_IdentifiedHand = $this->_HandIdentifier->identify($Cards);
        $this->assertEquals("{$ExpectedBestHand}", "{$this->_IdentifiedHand}");
    }

    /**
     * @return array
     */
    public function getSomeCardsAndTheExpectedBestHandFromThem() {
        $data = array(
            array(array('A-S', 'K-D', 'K-S', 'K-H', 'K-D', 'Q-S', 'J-S', 'J-H', 'J-C', '10-S'), 'RoyalFlush', array('A-S', 'K-S', 'Q-S', 'J-S', '10-S')),
            array(array('10-S', '9-D', '6-S', '6-H', '6-D', '4-D', '3-S', '3-H', '3-C', '3-D'), 'FourOfAKind', array('10-S', '3-S', '3-H', '3-C', '3-D')),
            array(array('A-C', 'K-S', 'K-H', 'J-D', '6-D', '5-S', '3-S', '3-H', '3-C', '3-D'), 'FourOfAKind', array('A-C', '3-S', '3-H', '3-C', '3-D')),
            array(array('A-C', 'A-S', 'K-H', 'J-D', '6-D', '5-S', '2-S', '2-H', '2-C', '2-D'), 'FourOfAKind', array('A-S', '2-S', '2-H', '2-C', '2-D')),
            array(array('K-D', '9-H', '6-S', '6-H', '6-C', '6-D', '4-D', '3-C', '2-S', '2-H'), 'FourOfAKind', array('K-D', '6-S', '6-H', '6-C', '6-D')),
            array(array('K-S', 'K-H', 'K-C', 'K-D', 'Q-S', 'Q-C', '7-S', '5-D', '3-S', '2-S'), 'FourOfAKind', array('K-S', 'K-H', 'K-C', 'K-D', 'Q-S')),
            array(array('10-D', '8-C', '7-S', '7-H', '7-D', '6-S', '6-C', '6-D', '5-H', '3-C',), 'FullHouse', array('7-S', '7-H', '7-D', '6-S', '6-C',),),
            array(array('8-H', '7-C', '6-S', '4-H', '4-C', '4-D', '3-S', '2-S', '2-C', '2-D',), 'FullHouse', array('4-H', '4-C', '4-D', '2-S', '2-C',),),
            array(array('A-D', '10-S', '9-S', '9-H', '9-D', '8-H', '8-C', '8-D', '7-D', '6-D',), 'FullHouse', array('9-S', '9-H', '9-D', '8-H', '8-C',),),
            array(array('A-D', 'Q-D', '8-S', '8-H', '8-C', '7-S', '7-H', '7-C', '3-H', '3-C',), 'FullHouse', array('8-S', '8-H', '8-C', '7-S', '7-H',),),
            array(array('A-S', '10-S', '10-H', '10-C', '8-S', '8-C', '7-H', '7-C', '7-D', '2-C',), 'FullHouse', array('10-S', '10-H', '10-C', '8-S', '8-C',),),
            array(array('A-S', 'A-C', 'A-D', 'Q-H', '10-S', '10-C', '10-D', '5-S', '4-H', '2-S',), 'FullHouse', array('A-S', 'A-C', 'A-D', '10-S', '10-C',),),
            array(array('A-S', 'A-H', 'A-D', 'K-D', '9-D', '8-S', '4-S', '4-C', '4-D', '3-S',), 'FullHouse', array('A-S', 'A-H', 'A-D', '4-S', '4-C',),),
            array(array('K-D', 'Q-S', 'Q-H', 'Q-D', 'J-H', '8-D', '3-S', '3-H', '3-D', '2-D',), 'FullHouse', array('Q-S', 'Q-H', 'Q-D', '3-S', '3-H',),),
            array(array('K-S', 'K-C', 'K-D', 'Q-S', 'J-H', '8-S', '7-S', '7-H', '7-D', '2-C',), 'FullHouse', array('K-S', 'K-C', 'K-D', '7-S', '7-H',),),
            array(array('Q-H', 'J-S', '9-D', '8-S', '8-H', '8-C', '4-S', '4-H', '4-D', '2-C',), 'FullHouse', array('8-S', '8-H', '8-C', '4-S', '4-H',),),
            array(array('K-S', 'K-C', 'K-D', 'Q-S', 'J-H', '8-S', '7-S', '7-H', '7-D', '2-C',), 'FullHouse', array('K-S', 'K-C', 'K-D', '7-S', '7-H',),),
            array(array('K-D', 'Q-S', 'Q-H', 'Q-D', 'J-H', '8-D', '3-S', '3-H', '3-D', '2-D'), 'FullHouse', array('Q-S', 'Q-H', 'Q-D','3-S', '3-H',)),
            array(array('A-H', 'K-D', 'Q-S', 'Q-C', 'Q-D', '10-S', '10-C', '10-D', '9-S', '9-D',), 'FullHouse', array('Q-S', 'Q-C', 'Q-D', '10-S', '10-C',),),
            array(array('A-H', 'K-S', 'J-S', 'J-H', 'J-C', '10-S', '10-H', '10-D', '7-C', '4-S',), 'FullHouse', array('J-S', 'J-H', 'J-C', '10-S', '10-H',),),
            array(array('10-D', '8-C', '7-S', '7-H', '7-D', '6-S', '6-C', '6-D', '5-H', '3-C'), 'FullHouse', array('7-S', '7-H', '7-D','6-S', '6-C',)),
            array(array('8-H', '7-C', '6-S', '4-H', '4-C', '4-D', '3-S', '2-S', '2-C', '2-D'), 'FullHouse', array('4-H', '4-C', '4-D','2-S', '2-C',)),
            array(array('A-D', 'Q-D', '8-S', '8-H', '8-C', '7-S', '7-H', '7-C', '3-H', '3-C'), 'FullHouse', array('8-S', '8-H', '8-C','7-S', '7-H',)),
            array(array('A-D', '10-S', '9-S', '9-H', '9-D', '8-H', '8-C', '8-D', '7-D', '6-D'), 'FullHouse', array('9-S', '9-H', '9-D','8-H', '8-C',)),
            array(array('Q-H', 'J-S', '9-D', '8-S', '8-H', '8-C', '4-S', '4-H', '4-D', '2-C'), 'FullHouse', array('8-S', '8-H', '8-C','4-S', '4-H',)),
            array(array('A-S', '10-S', '10-H', '10-C', '8-S', '8-C', '7-H', '7-C', '7-D', '2-C'), 'FullHouse', array('10-S', '10-H', '10-C','8-S', '8-C',)),
            array(array('A-S', 'A-C', 'A-D', 'Q-H', '10-S', '10-C', '10-D', '5-S', '4-H', '2-S'), 'FullHouse', array('A-S', 'A-C', 'A-D','10-S', '10-C',)),
            array(array('A-S', 'A-H', 'A-D', 'K-D', '9-D', '8-S', '4-S', '4-C', '4-D', '3-S'), 'FullHouse', array('A-S', 'A-H', 'A-D','4-S', '4-C',)),
            array(array('K-S', 'K-C', 'K-D', 'Q-S', 'J-H', '8-S', '7-S', '7-H', '7-D', '2-C'), 'FullHouse', array('K-S', 'K-C', 'K-D','7-S', '7-H',)),
            array(array('A-D', 'Q-H', 'J-H', '10-D', '9-C', '8-S', '7-C', '6-C', '5-C', '4-C',), 'Flush', array('9-C', '7-C', '6-C', '5-C', '4-C',),),
            array(array('A-H', 'Q-D', 'J-S', '9-S', '8-D', '6-D', '5-D', '4-C', '3-C', '2-D',), 'Flush', array('Q-D', '8-D', '6-D', '5-D', '2-D',),),
            array(array('A-S', 'Q-S', 'J-S', '10-C', '9-S', '8-H', '7-D', '4-H', '3-H', '2-S',), 'Flush', array('A-S', 'Q-S', 'J-S', '9-S', '2-S',),),
            array(array('A-H', 'K-S', 'Q-S', 'J-S', '7-S', '7-C', '7-D', '5-S', '4-S', '3-S',), 'Flush', array('K-S', 'Q-S', 'J-S', '7-S', '5-S',),),
            array(array('A-S', 'A-H', 'A-D', 'K-H', 'Q-H', '9-D', '8-H', '6-H', '5-S', '4-C',), 'Flush', array('A-H','K-H', 'Q-H', '8-H', '6-H',),),
            array(array('K-D', 'Q-D', 'J-S', '9-D', '8-H', '7-D', '6-D', '5-C', '4-S', '2-C',), 'Flush', array('K-D', 'Q-D', '9-D', '7-D', '6-D',),),
            array(array('K-D', 'Q-S', 'J-S', '10-S', '9-S', '7-S', '6-D', '5-S', '3-S', '2-C',), 'Flush', array('Q-S', 'J-S', '10-S', '9-S', '7-S',),),
            array(array('K-S', 'Q-S', 'J-D', '10-S', '9-D', '8-H', '7-S', '6-S', '5-H', '4-S',), 'Flush', array('K-S', 'Q-S', '10-S', '7-S', '6-S',),),
            array(array('A-H', 'K-H', 'Q-H', 'J-S', '10-H', '9-S', '8-S', '7-H', '6-S', '2-H',), 'Flush', array('A-H', 'K-H', 'Q-H', '10-H', '7-H'),),
            array(array('A-C', 'K-C', 'J-S', 'J-H', 'J-C', '10-S', '9-H', '8-C', '7-C', '6-D',), 'Flush', array('A-C', 'K-C', 'J-C', '8-C', '7-C'),),
            array(array('A-S', 'K-D', 'Q-S', 'J-D', '10-S', '7-H', '5-S', '5-C', '5-D', '4-S',), 'Flush', array('A-S', 'Q-S', '10-S', '5-S', '4-S'),),
            array(array('A-D', 'K-C', 'Q-C', 'J-D', '10-C', '7-H', '7-C', '7-D', '6-D', '2-D',), 'Flush', array('A-D', 'J-D', '7-D', '6-D', '2-D'),),
            array(array('Q-S', 'Q-H', 'Q-C', 'J-H', '10-C', '9-C', '8-C', '5-C', '3-C', '2-C',), 'Flush', array('Q-C', '10-C', '9-C', '8-C', '5-C'),),
            array(array('A-C', '10-H', '9-S', '8-C', '7-S', '6-S', '5-D', '4-D', '3-D', '2-C',), 'Straight', array('10-H', '9-S', '8-C', '7-S', '6-S',),),
            array(array('A-C', 'K-S', 'Q-H', 'J-D', '10-H', '9-H', '8-C', '6-C', '4-H', '2-S',), 'Straight', array('A-C', 'K-S', 'Q-H', 'J-D', '10-H',),),
            array(array('K-C', 'J-H', '10-S', '9-C', '8-H', '7-S', '6-H', '5-D', '3-S', '2-C',), 'Straight', array('J-H', '10-S', '9-C', '8-H', '7-S',),),
            array(array('A-D', 'K-D', 'Q-S', 'J-H', '10-H', '6-S', '5-S', '4-D', '3-H', '2-H',), 'Straight', array('A-D', 'K-D', 'Q-S', 'J-H', '10-H',),),
            array(array('J-C', '10-S', '7-D', '6-S', '5-H', '4-S', '4-H', '4-D', '3-C', '2-H',), 'Straight', array('7-D', '6-S', '5-H', '4-S', '3-C',),),
            array(array('K-H', '10-H', '9-C', '8-S', '8-C', '8-D', '7-S', '6-S', '5-H', '4-D',), 'Straight', array('10-H', '9-C', '8-S', '7-S', '6-S',),),
            array(array('K-S', 'K-C', 'K-D', 'Q-S', '9-H', '6-H', '5-D', '4-C', '3-S', '2-D',), 'Straight', array('6-H', '5-D', '4-C', '3-S', '2-D',),),
            array(array('Q-S', 'J-S', 'J-C', 'J-D', '10-H', '6-S', '5-H', '4-C', '3-H', '2-C',), 'Straight', array('6-S', '5-H', '4-C', '3-H', '2-C',),),
            array(array('Q-S', 'J-S', 'J-H', 'J-D', '8-C', '7-S', '6-H', '5-C', '4-D', '3-S',), 'Straight', array('8-C', '7-S', '6-H', '5-C', '4-D',),),
            array(array('A-C', '10-H', '9-S', '8-C', '7-S', '6-S', '5-D', '4-D', '3-D', '2-C'), 'Straight', array('10-H', '9-S', '8-C', '7-S', '6-S'),),
            array(array('A-C', 'K-C', '4-S', '5-H', 'J-C', '10-S', '9-H', '8-D', '7-C', '6-D'), 'Straight', array('J-C', '10-S', '9-H', '8-D', '7-C',)),
            array(array('A-C', 'K-S', 'Q-H', 'J-D', '10-H', '9-H', '8-C', '6-C', '4-H', '2-S'), 'Straight', array('A-C', 'K-S', 'Q-H', 'J-D', '10-H',),),
            array(array('A-H', 'K-C', 'Q-C', 'J-D', '10-C', '7-H', '7-C', '7-D', '6-D', '2-D'), 'Straight', array('A-H', 'K-C', 'Q-C', 'J-D', '10-C',)),
            array(array('A-D', 'K-D', 'Q-S', 'J-H', '10-H', '6-S', '5-S', '4-D', '3-H', '2-H'), 'Straight', array('A-D', 'K-D', 'Q-S', 'J-H', '10-H',),),
            array(array('A-C', 'K-D', 'Q-S', 'J-D', '10-S', '7-H', '5-S', '5-C', '5-D', '4-S'), 'Straight', array('A-C', 'K-D', 'Q-S', 'J-D', '10-S',)),
            array(array('J-C', '10-S', '7-D', '6-S', '5-H', '4-S', '4-H', '4-D', '3-C', '2-H'), 'Straight', array('7-D', '6-S', '5-H', '4-S', '3-C',)),
            array(array('K-C', 'J-H', '10-S', '9-C', '8-H', '7-S', '6-H', '5-D', '3-S', '2-C'), 'Straight', array('J-H', '10-S', '9-C', '8-H', '7-S',)),
            array(array('K-H', '10-H', '9-C', '8-S', '8-C', '8-D', '7-S', '6-S', '5-H', '4-D'), 'Straight', array('10-H', '9-C', '8-S', '7-S', '6-S',)),
            array(array('K-S', 'K-C', 'K-D', 'Q-S', '9-H', '6-H', '5-D', '4-C', '3-S', '2-D'), 'Straight', array('6-H', '5-D', '4-C', '3-S', '2-D',)),
            array(array('K-D', 'Q-D', 'J-S', '9-D', '8-H', '7-D', '6-D', '5-C', '4-S', '2-C'), 'Flush', array('K-D', 'Q-D', '9-D', '7-D', '6-D',)),
            array(array('K-D', 'Q-S', 'J-S', '10-S', '9-S', '7-S', '6-D', '5-S', '3-S', '2-C'), 'Flush', array('Q-S', 'J-S', '10-S', '9-S', '7-S',)),
            array(array('K-S', 'Q-S', 'J-D', '10-S', '9-D', '8-H', '7-S', '6-S', '5-H', '4-S'), 'Flush', array('K-S', 'Q-S', '10-S', '7-S', '6-S',)),
            array(array('A-D', 'Q-H', 'J-H', '10-D', '9-C', '8-S', '7-C', '6-C', '5-C', '4-C'), 'Flush', array('9-C','7-C', '6-C', '5-C', '4-C',)),
            array(array('A-H', 'K-H', 'Q-H', 'J-S', '10-H', '9-S', '8-S', '7-H', '6-S', '2-H'), 'Flush', array('A-H', 'K-H', 'Q-H', '10-H', '7-H',),),
            array(array('A-H', 'K-S', 'Q-S', 'J-S', '7-S', '7-C', '7-D', '5-S', '4-S', '3-S'), 'Flush', array('K-S', 'Q-S', 'J-S', '7-S', '5-S',)),
            array(array('A-H', 'Q-D', 'J-S', '9-S', '8-D', '6-D', '5-D', '4-C', '3-C', '2-D'), 'Flush', array('Q-D','8-D', '6-D', '5-D', '2-D',)),
            array(array('A-S', 'A-H', 'A-D', 'K-H', 'Q-H', '9-D', '8-H', '6-H', '5-S', '4-C'), 'Flush', array('A-H', 'K-H', 'Q-H', '8-H', '6-H',)),
            array(array('A-S', 'Q-S', 'J-S', '10-C', '9-S', '8-H', '7-D', '4-H', '3-H', '2-S'), 'Flush', array('A-S', 'Q-S', 'J-S','9-S', '2-S',)),
        );

        array_walk(
            $data,
            function (&$datum) {
                list ($cardsCardStrings, $handClassName, $handCardStrings) = $datum;

                $hydrateCard = function ($cardString) {
                    $CardBuilder = new CardBuilder();
                    return $CardBuilder->fromString($cardString);
                };

                $HandClass = new ReflectionClass($handClassName);

                $datum = array(
                    array_map($hydrateCard, $cardsCardStrings),
                    $HandClass->newInstance(array_map($hydrateCard, $handCardStrings))
                );
            }
        );

        return $data;
    }


    /**
     * @test
     * @param \Card[] $Cards
     * @return void
     * @dataProvider getBunchesOfCardsAndWhatTheirBestHandShouldBe
     */
//    public function canIdentifyTheBestHandOutOfSeveralPossibilities($Cards) {
//        $this->_IdentifiedHand = $this->_HandIdentifier->identify($Cards);
//        echo "\n" . get_class($this->_IdentifiedHand) . ' (' . $this->_printCards($this->_IdentifiedHand->getCards()) . ')' . " was the best hand out of cards: " . $this->_printCards($Cards);
//    }

    /**
     * @return array
     */
    public function getBunchesOfCardsAndWhatTheirBestHandShouldBe() {
        $Bunches = array_map(
            function () {
                $Deck = new Deck();
                $Deck->populate();
                $Cards = $Deck->getCards();

                $BunchOfCards = array_map(
                    function ($cardKey) use ($Cards) {
                        return $Cards[$cardKey];
                    },
                    array_rand($Cards, 10)
                );

                usort(
                    $BunchOfCards,
                    function (Card $Card1, Card $Card2) {
                        return $Card1->compareTo($Card2);
                    }
                );

                return array($BunchOfCards);
            },
            range(1, 1000)
        );

        return $Bunches;
    }

    /**
     * @param \Card[] $Cards
     * @return string
     */
    private function _printCards(array $Cards) {
        usort(
            $Cards,
            function (Card $Card1, Card $Card2) {
                return $Card1->compareTo($Card2);
            }
        );

        return implode(
            ', ',
            array_map(
                function (Card $Card) {
                    return "{$Card}";
                },
                $Cards
            )
        );
    }
}
