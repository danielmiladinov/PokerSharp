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
     * @param \Hand  $FirstHand
     * @param \Hand  $SecondHand
     * @param int    $expectedComparison
     * @param string $failureMessage
     * @dataProvider getHandsAndTheirExpectedComparisonAndTheirComparisonFailureMessage
     */
    public function twoHandShouldCompareAsExpected(Hand $FirstHand, Hand $SecondHand, $expectedComparison, $failureMessage) {
        $this->assertEquals($expectedComparison, $this->_HandComparator->compare($FirstHand, $SecondHand), $failureMessage);
    }

    /**
     * @return array
     */
    public function getHandsAndTheirExpectedComparisonAndTheirComparisonFailureMessage() {
        $handClasses = array(
            'HighCard',
            'TwoOfAKind',
            'TwoPair',
            'ThreeOfAKind',
            'Straight',
            'Flush',
            'FullHouse',
            'FourOfAKind',
            'StraightFlush',
            'RoyalFlush',
        );

        $data = array();

        foreach ($handClasses as $firstHandStrength => $firstHandClass) {
            foreach ($handClasses as $secondHandStrength => $secondHandClass) {
                $FirstHandReflector = new ReflectionClass($firstHandClass);
                $SecondHandReflector = new ReflectionClass($secondHandClass);

                $FirstHand = $FirstHandReflector->newInstance($this->_getFiveRandomCards());
                $SecondHand = $SecondHandReflector->newInstance($this->_getFiveRandomCards());

                $handDifference = ($firstHandStrength - $secondHandStrength);

                if ($handDifference == 0) {
                    $expectedComparison = 0;
                    $comparisonMessage = 'compares equal to';
                } else if ($handDifference > 0) {
                    $expectedComparison = 1;
                    $comparisonMessage = 'compares greater than';
                } else {
                    $expectedComparison = -1;
                    $comparisonMessage = 'compares less than';
                }

                $failureMessage = "Failed asserting that a {$firstHandClass} {$comparisonMessage} a {$secondHandClass}.";

                $data[] = array(
                    $FirstHand,
                    $SecondHand,
                    $expectedComparison,
                    $failureMessage
                );
            }
        }

        return $data;
    }

    /**
     * @return Card[]
     */
    private function _getFiveRandomCards() {
        $suits = array('S', 'H', 'C', 'D');
        $values = array('2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A');
        $cardStringDeck = array();

        $CardBuilder = new CardBuilder();

        foreach ($suits as $suit) {
            foreach ($values as $value) {
                $cardStringDeck[] = "{$value}-{$suit}";
            }
        }

        $FiveRandomCards = array_map(
            function ($cardStringDeckKey) use ($CardBuilder, $cardStringDeck) {
                $cardString = $cardStringDeck[$cardStringDeckKey];
                /** @var $CardBuilder CardBuilder */
                return $CardBuilder->fromString($cardString);
            },
            array_rand($cardStringDeck, 5)
        );

        return $FiveRandomCards;
    }
}
