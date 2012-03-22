<?php

class HandComparator {

    /**
     * @var array
     */
    private static $_handStrengths = array(
        'RoyalFlush'    => 12,
        'StraightFlush' => 11,
        'SteelWheel'    => 10,
        'FourOfAKind'   => 9,
        'FullHouse'     => 8,
        'Flush'         => 7,
        'Straight'      => 6,
        'Wheel'         => 5,
        'ThreeOfAKind'  => 4,
        'TwoPair'       => 3,
        'TwoOfAKind'    => 2,
        'HighCard'      => 1,
        'Hand'          => 0,
    );

    /**
     * Returns greater than zero if the first hand is stronger than the second,
     * and less than zero if the second hand is stronger; zero if both hands are the same strength.
     *
     * @param Hand $FirstHand
     * @param Hand $SecondHand
     * @return int
     */
    public function compare(Hand $FirstHand, Hand $SecondHand) {
        $firstHandStrength = self::$_handStrengths[get_class($FirstHand)];
        $secondHandStrength = self::$_handStrengths[get_class($SecondHand)];

        $comparison = $firstHandStrength - $secondHandStrength;

        if ($comparison == 0) {
            return 0;
        } else if ($comparison > 0) {
            return 1;
        } else {
            return -1;
        }
    }
}
