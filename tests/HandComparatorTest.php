<?php

class HandComparatorTest extends PHPUnit_Framework_TestCase {

    /**
     * @var HandComparator
     */
    protected $_HandComparator;

    protected function setUp() {
        $this->_HandComparator = new HandComparator();
    }

    /**
     * @test
     */
    public function twoHighCardsShouldCompareAsEqual() {
        $FirstHand = new HighCard($this->_getFiveRandomCards());
        $SecondHand = new HighCard($this->_getFiveRandomCards());

        $this->assertEquals(0, $this->_HandComparator->compare($FirstHand, $SecondHand));
    }

    /**
     * @test
     */
    public function aTwoOfAKindShouldCompareGreaterThanAHighCard() {
        $FirstHand = new TwoOfAKind($this->_getFiveRandomCards());
        $SecondHand = new HighCard($this->_getFiveRandomCards());

        $this->assertEquals(1, $this->_HandComparator->compare($FirstHand, $SecondHand), $this->_makeSentenceFromCamelCase(__FUNCTION__));
    }

    /**
     * @test
     */
    public function aTwoPairShouldCompareGreaterThanAHighCard() {
        $FirstHand = new TwoPair($this->_getFiveRandomCards());
        $SecondHand = new HighCard($this->_getFiveRandomCards());

        $this->assertEquals(1, $this->_HandComparator->compare($FirstHand, $SecondHand), $this->_makeSentenceFromCamelCase(__FUNCTION__));
    }

    /**
     * @test
     */
    public function aThreeOfAKindShouldCompareGreaterThanAHighCard() {
        $FirstHand = new ThreeOfAKind($this->_getFiveRandomCards());
        $SecondHand = new HighCard($this->_getFiveRandomCards());

        $this->assertEquals(1, $this->_HandComparator->compare($FirstHand, $SecondHand), $this->_makeSentenceFromCamelCase(__FUNCTION__));
    }

    /**
     * @test
     */
    public function aWheelShouldCompareGreaterThanAHighCard() {
        $FirstHand = new Wheel($this->_getFiveRandomCards());
        $SecondHand = new HighCard($this->_getFiveRandomCards());

        $this->assertEquals(1, $this->_HandComparator->compare($FirstHand, $SecondHand), $this->_makeSentenceFromCamelCase(__FUNCTION__));
    }

    /**
     * @test
     */
    public function aStraightShouldCompareGreaterThanAHighCard() {
        $FirstHand = new Straight($this->_getFiveRandomCards());
        $SecondHand = new HighCard($this->_getFiveRandomCards());

        $this->assertEquals(1, $this->_HandComparator->compare($FirstHand, $SecondHand), $this->_makeSentenceFromCamelCase(__FUNCTION__));
    }

    /**
     * @test
     */
    public function aFlushShouldCompareGreaterThanAHighCard() {
        $FirstHand = new Flush($this->_getFiveRandomCards());
        $SecondHand = new HighCard($this->_getFiveRandomCards());

        $this->assertEquals(1, $this->_HandComparator->compare($FirstHand, $SecondHand), $this->_makeSentenceFromCamelCase(__FUNCTION__));
    }

    /**
     * @test
     */
    public function aFullHouseShouldCompareGreaterThanAHighCard() {
        $FirstHand = new FullHouse($this->_getFiveRandomCards());
        $SecondHand = new HighCard($this->_getFiveRandomCards());

        $this->assertEquals(1, $this->_HandComparator->compare($FirstHand, $SecondHand), $this->_makeSentenceFromCamelCase(__FUNCTION__));
    }

    /**
     * @test
     */
    public function aFourOfAKindShouldCompareGreaterThanAHighCard() {
        $FirstHand = new FourOfAKind($this->_getFiveRandomCards());
        $SecondHand = new HighCard($this->_getFiveRandomCards());

        $this->assertEquals(1, $this->_HandComparator->compare($FirstHand, $SecondHand), $this->_makeSentenceFromCamelCase(__FUNCTION__));
    }

    /**
     * @test
     */
    public function aSteelWheelShouldCompareGreaterThanAHighCard() {
        $FirstHand = new SteelWheel($this->_getFiveRandomCards());
        $SecondHand = new HighCard($this->_getFiveRandomCards());

        $this->assertEquals(1, $this->_HandComparator->compare($FirstHand, $SecondHand), $this->_makeSentenceFromCamelCase(__FUNCTION__));
    }

    /**
     * @test
     */
    public function aStraightFlushShouldCompareGreaterThanAHighCard() {
        $FirstHand = new StraightFlush($this->_getFiveRandomCards());
        $SecondHand = new HighCard($this->_getFiveRandomCards());

        $this->assertEquals(1, $this->_HandComparator->compare($FirstHand, $SecondHand), $this->_makeSentenceFromCamelCase(__FUNCTION__));
    }

    /**
     * @test
     */
    public function aRoyalFlushShouldCompareGreaterThanAHighCard() {
        $FirstHand = new RoyalFlush($this->_getFiveRandomCards());
        $SecondHand = new HighCard($this->_getFiveRandomCards());

        $this->assertEquals(1, $this->_HandComparator->compare($FirstHand, $SecondHand), $this->_makeSentenceFromCamelCase(__FUNCTION__));
    }

    /**
     * @test
     */
    public function aHighCardShouldCompareLessThanATwoOfAKind() {
        $FirstHand = new HighCard($this->_getFiveRandomCards());
        $SecondHand = new TwoOfAKind($this->_getFiveRandomCards());

        $this->assertEquals(-1, $this->_HandComparator->compare($FirstHand, $SecondHand), $this->_makeSentenceFromCamelCase(__FUNCTION__));
    }

    /**
     * @test
     */
    public function twoTwosOfAKindShouldCompareAsEqual() {
        $FirstHand = new TwoOfAKind($this->_getFiveRandomCards());
        $SecondHand = new TwoOfAKind($this->_getFiveRandomCards());

        $this->assertEquals(0, $this->_HandComparator->compare($FirstHand, $SecondHand));
    }

    /**
     * @test
     */
    public function aTwoPairShouldCompareGreaterThanATwoOfAKind() {
        $FirstHand = new TwoPair($this->_getFiveRandomCards());
        $SecondHand = new TwoOfAKind($this->_getFiveRandomCards());

        $this->assertEquals(1, $this->_HandComparator->compare($FirstHand, $SecondHand), $this->_makeSentenceFromCamelCase(__FUNCTION__));
    }

    /**
     * @test
     */
    public function aThreeOfAKindShouldCompareGreaterThanATwoOfAKind() {
        $FirstHand = new ThreeOfAKind($this->_getFiveRandomCards());
        $SecondHand = new TwoOfAKind($this->_getFiveRandomCards());

        $this->assertEquals(1, $this->_HandComparator->compare($FirstHand, $SecondHand), $this->_makeSentenceFromCamelCase(__FUNCTION__));
    }

    /**
     * @test
     */
    public function aWheelShouldCompareGreaterThanATwoOfAKind() {
        $FirstHand = new Wheel($this->_getFiveRandomCards());
        $SecondHand = new TwoOfAKind($this->_getFiveRandomCards());

        $this->assertEquals(1, $this->_HandComparator->compare($FirstHand, $SecondHand), $this->_makeSentenceFromCamelCase(__FUNCTION__));
    }

    /**
     * @test
     */
    public function aStraightShouldCompareGreaterThanATwoOfAKind() {
        $FirstHand = new Straight($this->_getFiveRandomCards());
        $SecondHand = new TwoOfAKind($this->_getFiveRandomCards());

        $this->assertEquals(1, $this->_HandComparator->compare($FirstHand, $SecondHand), $this->_makeSentenceFromCamelCase(__FUNCTION__));
    }

    /**
     * @test
     */
    public function aFlushShouldCompareGreaterThanATwoOfAKind() {
        $FirstHand = new Flush($this->_getFiveRandomCards());
        $SecondHand = new TwoOfAKind($this->_getFiveRandomCards());

        $this->assertEquals(1, $this->_HandComparator->compare($FirstHand, $SecondHand), $this->_makeSentenceFromCamelCase(__FUNCTION__));
    }

    /**
     * @test
     */
    public function aFullHouseShouldCompareGreaterThanATwoOfAKind() {
        $FirstHand = new FullHouse($this->_getFiveRandomCards());
        $SecondHand = new TwoOfAKind($this->_getFiveRandomCards());

        $this->assertEquals(1, $this->_HandComparator->compare($FirstHand, $SecondHand), $this->_makeSentenceFromCamelCase(__FUNCTION__));
    }

    /**
     * @test
     */
    public function aFourOfAKindShouldCompareGreaterThanATwoOfAKind() {
        $FirstHand = new FourOfAKind($this->_getFiveRandomCards());
        $SecondHand = new TwoOfAKind($this->_getFiveRandomCards());

        $this->assertEquals(1, $this->_HandComparator->compare($FirstHand, $SecondHand), $this->_makeSentenceFromCamelCase(__FUNCTION__));
    }

    /**
     * @test
     */
    public function aSteelWheelShouldCompareGreaterThanATwoOfAKind() {
        $FirstHand = new SteelWheel($this->_getFiveRandomCards());
        $SecondHand = new TwoOfAKind($this->_getFiveRandomCards());

        $this->assertEquals(1, $this->_HandComparator->compare($FirstHand, $SecondHand), $this->_makeSentenceFromCamelCase(__FUNCTION__));
    }

    /**
     * @test
     */
    public function aStraightFlushShouldCompareGreaterThanATwoOfAKind() {
        $FirstHand = new StraightFlush($this->_getFiveRandomCards());
        $SecondHand = new TwoOfAKind($this->_getFiveRandomCards());

        $this->assertEquals(1, $this->_HandComparator->compare($FirstHand, $SecondHand), $this->_makeSentenceFromCamelCase(__FUNCTION__));
    }

    /**
     * @test
     */
    public function aRoyalFlushShouldCompareGreaterThanATwoOfAKind() {
        $FirstHand = new RoyalFlush($this->_getFiveRandomCards());
        $SecondHand = new TwoOfAKind($this->_getFiveRandomCards());

        $this->assertEquals(1, $this->_HandComparator->compare($FirstHand, $SecondHand), $this->_makeSentenceFromCamelCase(__FUNCTION__));
    }

    /**
     * @test
     */
    public function aHighCardShouldCompareLessThanATwoPair() {
        $FirstHand = new HighCard($this->_getFiveRandomCards());
        $SecondHand = new TwoPair($this->_getFiveRandomCards());

        $this->assertEquals(-1, $this->_HandComparator->compare($FirstHand, $SecondHand), $this->_makeSentenceFromCamelCase(__FUNCTION__));
    }

    /**
     * @test
     */
    public function aTwoOfAKindShouldCompareLessThanATwoPair() {
        $FirstHand = new TwoOfAKind($this->_getFiveRandomCards());
        $SecondHand = new TwoPair($this->_getFiveRandomCards());

        $this->assertEquals(-1, $this->_HandComparator->compare($FirstHand, $SecondHand));
    }

    /**
     * @test
     */
    public function twoTwoPairsShouldCompareAsEqual() {
        $FirstHand = new TwoPair($this->_getFiveRandomCards());
        $SecondHand = new TwoPair($this->_getFiveRandomCards());

        $this->assertEquals(0, $this->_HandComparator->compare($FirstHand, $SecondHand));
    }

    /**
     * @test
     */
    public function aThreeOfAKindShouldCompareGreaterThanATwoPair() {
        $FirstHand = new ThreeOfAKind($this->_getFiveRandomCards());
        $SecondHand = new TwoPair($this->_getFiveRandomCards());

        $this->assertEquals(1, $this->_HandComparator->compare($FirstHand, $SecondHand), $this->_makeSentenceFromCamelCase(__FUNCTION__));
    }

    /**
     * @test
     */
    public function aWheelShouldCompareGreaterThanATwoPair() {
        $FirstHand = new Wheel($this->_getFiveRandomCards());
        $SecondHand = new TwoPair($this->_getFiveRandomCards());

        $this->assertEquals(1, $this->_HandComparator->compare($FirstHand, $SecondHand), $this->_makeSentenceFromCamelCase(__FUNCTION__));
    }

    /**
     * @test
     */
    public function aStraightShouldCompareGreaterThanATwoPair() {
        $FirstHand = new Straight($this->_getFiveRandomCards());
        $SecondHand = new TwoPair($this->_getFiveRandomCards());

        $this->assertEquals(1, $this->_HandComparator->compare($FirstHand, $SecondHand), $this->_makeSentenceFromCamelCase(__FUNCTION__));
    }

    /**
     * @test
     */
    public function aFlushShouldCompareGreaterThanATwoPair() {
        $FirstHand = new Flush($this->_getFiveRandomCards());
        $SecondHand = new TwoPair($this->_getFiveRandomCards());

        $this->assertEquals(1, $this->_HandComparator->compare($FirstHand, $SecondHand), $this->_makeSentenceFromCamelCase(__FUNCTION__));
    }

    /**
     * @test
     */
    public function aFullHouseShouldCompareGreaterThanATwoPair() {
        $FirstHand = new FullHouse($this->_getFiveRandomCards());
        $SecondHand = new TwoPair($this->_getFiveRandomCards());

        $this->assertEquals(1, $this->_HandComparator->compare($FirstHand, $SecondHand), $this->_makeSentenceFromCamelCase(__FUNCTION__));
    }

    /**
     * @test
     */
    public function aFourOfAKindShouldCompareGreaterThanATwoPair() {
        $FirstHand = new FourOfAKind($this->_getFiveRandomCards());
        $SecondHand = new TwoPair($this->_getFiveRandomCards());

        $this->assertEquals(1, $this->_HandComparator->compare($FirstHand, $SecondHand), $this->_makeSentenceFromCamelCase(__FUNCTION__));
    }

    /**
     * @test
     */
    public function aSteelWheelShouldCompareGreaterThanATwoPair() {
        $FirstHand = new SteelWheel($this->_getFiveRandomCards());
        $SecondHand = new TwoPair($this->_getFiveRandomCards());

        $this->assertEquals(1, $this->_HandComparator->compare($FirstHand, $SecondHand), $this->_makeSentenceFromCamelCase(__FUNCTION__));
    }

    /**
     * @test
     */
    public function aStraightFlushShouldCompareGreaterThanATwoPair() {
        $FirstHand = new StraightFlush($this->_getFiveRandomCards());
        $SecondHand = new TwoPair($this->_getFiveRandomCards());

        $this->assertEquals(1, $this->_HandComparator->compare($FirstHand, $SecondHand), $this->_makeSentenceFromCamelCase(__FUNCTION__));
    }

    /**
     * @test
     */
    public function aRoyalFlushShouldCompareGreaterThanATwoPair() {
        $FirstHand = new RoyalFlush($this->_getFiveRandomCards());
        $SecondHand = new TwoPair($this->_getFiveRandomCards());

        $this->assertEquals(1, $this->_HandComparator->compare($FirstHand, $SecondHand), $this->_makeSentenceFromCamelCase(__FUNCTION__));
    }

    /**
     * @return Card[]
     */
    private function _getFiveRandomCards() {
        $suits = array('S', 'H', 'C', 'D');
        $values = array('2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A');

        $CardBuilder = new CardBuilder();

        $FiveRandomCards = array_map(
            function($cardString) use ($CardBuilder) {
                /** @var $CardBuilder CardBuilder */
                return $CardBuilder->fromString($cardString);
            },
            array_map(
                function() use ($suits, $values) {
                    return "{$values[array_rand($values)]}-{$suits[array_rand($suits)]}";
                },
                range(1, 5)
            )
        );

        return $FiveRandomCards;
    }

    /**
     * Given the string "aCamelHasHumps", the value returned should be
     * "A Camel Has Humps".
     *
     * @static
     * @param string $camelCasedString
     * @return string
     */
    private function _makeSentenceFromCamelCase($camelCasedString)
    {
        $stringLength = strlen($camelCasedString);
        $formattedOutput = '';

        for ($charIndex = 0; $charIndex < $stringLength; $charIndex++) {
            $character = $camelCasedString{$charIndex};

            if (ctype_upper($character)) {
                $formattedOutput .= ' ';
            }

            $formattedOutput .= $character;
        }

        $formattedOutput = ucwords($formattedOutput);
        return $formattedOutput;
    }
}
