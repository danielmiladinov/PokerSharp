<?php

class DeckTest extends PHPUnit_Framework_TestCase
{
    /**
     * @var Deck
     */
    private $_Deck;

    protected function setUp()
    {
        $this->_Deck = new Deck();
    }

    /**
     * @test
     */
    public function anEmpyDeckShouldHaveASizeOfZero()
    {
        $this->assertEquals(0, $this->_Deck->size());
    }

    /**
     * @test
     */
    public function addingACardShouldIncreaseTheSizeByOne()
    {
        $this->_Deck->add(Card::aceOf(Suit::Spades()));
        $this->assertEquals(1, $this->_Deck->size());
    }

    /**
     * @test
     */
    public function addingACardTwiceShouldCauseADeckExceptionToBeThrown()
    {
        $this->_Deck->add(Card::twoOf(Suit::Hearts()));

        $this->setExpectedException('DeckIntegrityException', 'Cannot contain the same card twice!');
        $this->_Deck->add(Card::twoOf(Suit::Hearts()));
    }

    /**
     * @test
     */
    public function populateShouldFillTheDeckWithAll52Cards()
    {
        $ExpectedCards = array();

        $Suits = array(
            Suit::Spades(),
            Suit::Hearts(),
            Suit::Clubs(),
            Suit::Diamonds(),
        );

        foreach ($Suits as $Suit) {
            $ExpectedCards[] = Card::aceOf($Suit);
            $ExpectedCards[] = Card::twoOf($Suit);
            $ExpectedCards[] = Card::threeOf($Suit);
            $ExpectedCards[] = Card::fourOf($Suit);
            $ExpectedCards[] = Card::fiveOf($Suit);
            $ExpectedCards[] = Card::sixOf($Suit);
            $ExpectedCards[] = Card::sevenOf($Suit);
            $ExpectedCards[] = Card::eightOf($Suit);
            $ExpectedCards[] = Card::nineOf($Suit);
            $ExpectedCards[] = Card::tenOf($Suit);
            $ExpectedCards[] = Card::jackOf($Suit);
            $ExpectedCards[] = Card::queenOf($Suit);
            $ExpectedCards[] = Card::kingOf($Suit);
        }

        $this->_Deck->populate();

        $this->assertEquals($ExpectedCards, $this->_Deck->getCards());
    }
}
