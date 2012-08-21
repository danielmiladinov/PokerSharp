<?php
class BestHandIdentifier
{
    /**
     * @param \Card[] $Cards
     * @return Hand
     */
    public function identify(array $Cards)
    {
        $SortedCards = $this->_sortCards($Cards);
        $Hand = new Hand($SortedCards);

        $SpecsInValueOrder = array(
            new RoyalFlushSpecification(),
            new SteelWheelSpecification(),
            new StraightFlushSpecification(),
            new FourOfAKindSpecification(),
            new FullHouseSpecification(),
            new FlushSpecification(),
            new WheelSpecification(),
            new StraightSpecification(),
            new ThreeOfAKindSpecification(),
            new TwoPairSpecification(),
            new TwoOfAKindSpecification(),
        );

        foreach ($SpecsInValueOrder as $Specification) {
            /** @var $Specification HandSpecification */
            if ($Specification->isSatisfiedBy($Hand)) {
                return $Specification->newHand($Hand);
            }
        }

        return new HighCard($SortedCards);
    }

    /**
     * @param Card[] $Cards
     * @return Card[]
     */
    private function _sortCards(array $Cards)
    {
        usort(
            $Cards,
            function (Card $Card1, Card $Card2) {
                return $Card1->compareTo($Card2);
            }
        );
        return $Cards;
    }
}
