<?php

class Deck
{
    /**
     * @var Card[]
     */
    private $_Cards;

    public function __construct()
    {
        $this->_Cards = array();
    }

    /**
     * @param Card $Card
     * @throws DeckIntegrityException
     */
    public function add(Card $Card)
    {
        if (array_key_exists("{$Card}", $this->_Cards)) {
            throw new DeckIntegrityException('Cannot contain the same card twice!');
        } else {
            $this->_Cards["{$Card}"] = $Card;
        }
    }

    /**
     * @return int
     */
    public function size()
    {
        return count($this->_Cards);
    }

    /**
     * @return void
     */
    public function populate()
    {
        $Suits = array(
            Suit::Spades(),
            Suit::Hearts(),
            Suit::Clubs(),
            Suit::Diamonds(),
        );

        foreach ($Suits as $Suit) {
            $this->_Cards[] = Card::aceOf($Suit);
            $this->_Cards[] = Card::twoOf($Suit);
            $this->_Cards[] = Card::threeOf($Suit);
            $this->_Cards[] = Card::fourOf($Suit);
            $this->_Cards[] = Card::fiveOf($Suit);
            $this->_Cards[] = Card::sixOf($Suit);
            $this->_Cards[] = Card::sevenOf($Suit);
            $this->_Cards[] = Card::eightOf($Suit);
            $this->_Cards[] = Card::nineOf($Suit);
            $this->_Cards[] = Card::tenOf($Suit);
            $this->_Cards[] = Card::jackOf($Suit);
            $this->_Cards[] = Card::queenOf($Suit);
            $this->_Cards[] = Card::kingOf($Suit);
        }
    }

    /**
     * @return Card[]
     */
    public function getCards()
    {
        return array_values($this->_Cards);
    }
}
