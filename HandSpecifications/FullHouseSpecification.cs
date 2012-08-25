using System.Collections.Generic;

class FullHouseSpecification : HandSpecification {

    public override bool isSatisfiedBy(Hand Hand) {
        return newHand(Hand) is FullHouse;
    }

    public override Hand newHand(Hand Hand) {
        return null;
    }
}