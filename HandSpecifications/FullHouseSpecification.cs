using System.Collections.Generic;

class FullHouseSpecification : HandSpecification {

    public override function isSatisfiedBy(Hand Hand) {
        return newHand(Hand) is FullHouse;
    }

    public override FullHouse newHand(Hand Hand) {
        return null;
    }
}