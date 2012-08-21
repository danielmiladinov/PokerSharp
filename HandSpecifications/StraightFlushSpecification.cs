<?php

class StraightFlushSpecification extends HandSpecification {

    /**
     * @param Hand $Hand
     * @return boolean
     */
    public function isSatisfiedBy(Hand $Hand) {
        return $this->newHand($Hand) instanceof StraightFlush;
    }

    /**
     * @param Hand $Hand
     * @return StraightFlush
     */
    public function newHand(Hand $Hand) {
        $SpadesCards = array();
        $HeartsCards = array();
        $ClubsCards = array();
        $DiamondsCards = array();

        $Cards = $Hand->getCards();

        usort(
            $Cards,
            function (Card $Card1, Card $Card2) {
                return $Card1->compareTo($Card2);
            }
        );

        foreach ($Cards as $Card) {
            switch ($Card->getSuit()) {
                case Suit::SPADES:
                    if ($this->_canAddCardTo($SpadesCards, $Card)) {
                        $SpadesCards[] = $Card;
                        if (count($SpadesCards) == 5) {
                            return new StraightFlush($SpadesCards);
                        }
                    }
                    break;

                case Suit::HEARTS:
                    if ($this->_canAddCardTo($HeartsCards, $Card)) {
                        $HeartsCards[] = $Card;
                        if (count($HeartsCards) == 5) {
                            return new StraightFlush($HeartsCards);
                        }
                    }
                    break;

                case Suit::CLUBS:
                    if ($this->_canAddCardTo($ClubsCards, $Card)) {
                        $ClubsCards[] = $Card;
                        if (count($ClubsCards) == 5) {
                            return new StraightFlush($ClubsCards);
                        }
                    }
                    break;

                case Suit::DIAMONDS:
                    if ($this->_canAddCardTo($DiamondsCards, $Card)) {
                        $DiamondsCards[] = $Card;
                        if (count($DiamondsCards) == 5) {
                            return new StraightFlush($DiamondsCards);
                        }
                    }
                    break;
            }
        }

        return null;
    }

    /**
     * @param Card[] $Cards
     * @param Card $Card
     * @return boolean
     */
    private function _canAddCardTo($Cards, Card $Card) {
        $numCards = count($Cards);

        if ($numCards > 0) {
            $PreviousCard = $Cards[$numCards - 1];

            if ($PreviousCard->isAce() && $Card->getFaceValue() == 5) {
                return true;
            } else if ($PreviousCard->getFaceValue() - 1 == $Card->getFaceValue()) {
                return true;
            }  else {
                return false;
            }
        } else {
            return true;
        }
    }
}