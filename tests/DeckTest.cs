<?php

class DeckTest extends PHPUnit_Framework_TestCase {
    /**
     * @var Deck
     */
    private $_Deck;

    protected function setUp() {
        $this->_Deck = new Deck();
    }

    /**
     * @test
     * @return void
     */
    public function anEmptyDeckShouldHaveASizeOfZero() {
        $this->assertEquals(0, $this->_Deck->size());
    }

    /**
     * @test
     * @return void
     */
    public function addingACardShouldIncreaseTheSizeByOne() {
        $this->_Deck->add(Cards::aceOf(Suit::Spades()));
        $this->assertEquals(1, $this->_Deck->size());
    }

    /**
     * @test
     * @return void
     */
    public function addingACardTwiceShouldCauseADeckExceptionToBeThrown() {
        $this->_Deck->add(Cards::twoOf(Suit::Hearts()));

        $this->setExpectedException('DeckIntegrityException', 'Cannot contain the same card twice!');
        $this->_Deck->add(Cards::twoOf(Suit::Hearts()));
    }

    /**
     * @test
     * @return void
     */
    public function populateShouldFillTheDeckWithAll52Cards() {
        $ExpectedCards = array();

        $Suits = array(
            Suit::Spades(),
            Suit::Hearts(),
            Suit::Clubs(),
            Suit::Diamonds(),
        );

        foreach ($Suits as $Suit) {
            $ExpectedCards[] = Cards::aceOf($Suit);
            $ExpectedCards[] = Cards::twoOf($Suit);
            $ExpectedCards[] = Cards::threeOf($Suit);
            $ExpectedCards[] = Cards::fourOf($Suit);
            $ExpectedCards[] = Cards::fiveOf($Suit);
            $ExpectedCards[] = Cards::sixOf($Suit);
            $ExpectedCards[] = Cards::sevenOf($Suit);
            $ExpectedCards[] = Cards::eightOf($Suit);
            $ExpectedCards[] = Cards::nineOf($Suit);
            $ExpectedCards[] = Cards::tenOf($Suit);
            $ExpectedCards[] = Cards::jackOf($Suit);
            $ExpectedCards[] = Cards::queenOf($Suit);
            $ExpectedCards[] = Cards::kingOf($Suit);
        }

        $this->_Deck->populate();

        $this->assertEquals($ExpectedCards, $this->_Deck->getCards());
    }
}