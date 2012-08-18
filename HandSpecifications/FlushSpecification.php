<?php

class FlushSpecification extends HandSpecification {

    /**
     * @param Hand $Hand
     * @return boolean
     */
    public function isSatisfiedBy(Hand $Hand) {
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
                    if (count($SpadesCards) == 5) {
                        return new Flush($SpadesCards);
                    }
                    break;

                case Suit::HEARTS:
                    $HeartsCards[] = $Card;
                    if (count($HeartsCards) == 5) {
                        return new Flush($HeartsCards);
                    }
                    break;

                case Suit::CLUBS:
                    $ClubsCards[] = $Card;
                    if (count($ClubsCards) == 5) {
                        return new Flush($ClubsCards);
                    }
                    break;

                case Suit::DIAMONDS:
                    $DiamondsCards[] = $Card;
                    if (count($DiamondsCards) == 5) {
                        return new Flush($DiamondsCards);
                    }
                    break;
            }
        }

        return null;
    }
}
