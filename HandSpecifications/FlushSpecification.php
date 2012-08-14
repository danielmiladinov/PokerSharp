<?php

class FlushSpecification extends HandSpecification {

    /**
     * @param Hand $Hand
     * @return boolean
     */
    public function isSatisfiedBy(Hand $Hand) {
        return $this->_canBeAFlush($Hand);
    }

    /**
     * @param Hand $Hand
     * @return bool
     */
    protected function _canBeAFlush(Hand $Hand) {
        return $this->newHand($Hand) instanceof Flush;
    }


    /**
     * @param Hand $Hand
     * @return Flush
     */
    public function newHand(Hand $Hand) {
        $SpadesCards = array();
        $HeartsCards = array();
        $ClubsCards = array();
        $DiamondsCards = array();

        foreach ($Hand->getCards() as $Card) {
            switch ($Card->getSuit()) {
                case Suit::SPADES:
                    $SpadesCards[] = $Card;
                    break;

                case Suit::HEARTS:
                    $HeartsCards[] = $Card;
                    break;

                case Suit::CLUBS:
                    $ClubsCards[] = $Card;
                    break;

                case Suit::DIAMONDS:
                    $DiamondsCards[] = $Card;
                    break;
            }

            foreach (array($SpadesCards, $HeartsCards, $ClubsCards, $DiamondsCards) as $Cards) {
                if (count($Cards) == 5) {
                    return new Flush($Cards);
                }
            }
        }

        return null;
    }
}
