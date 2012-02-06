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
            $this->_Cards[] = Cards::aceOf($Suit);
            $this->_Cards[] = Cards::twoOf($Suit);
            $this->_Cards[] = Cards::threeOf($Suit);
            $this->_Cards[] = Cards::fourOf($Suit);
            $this->_Cards[] = Cards::fiveOf($Suit);
            $this->_Cards[] = Cards::sixOf($Suit);
            $this->_Cards[] = Cards::sevenOf($Suit);
            $this->_Cards[] = Cards::eightOf($Suit);
            $this->_Cards[] = Cards::nineOf($Suit);
            $this->_Cards[] = Cards::tenOf($Suit);
            $this->_Cards[] = Cards::jackOf($Suit);
            $this->_Cards[] = Cards::queenOf($Suit);
            $this->_Cards[] = Cards::kingOf($Suit);
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
