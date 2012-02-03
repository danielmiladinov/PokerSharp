<?php
class CardTest extends PHPUnit_Framework_TestCase
{
    /**
     * @var Card
     */
    private $_CurrentCard;

    /**
     * @var Card
     */
    private $_OtherCard;

    /**
     * @return void
     */
    protected function setUp()
    {
        parent::setUp();
    }

    /**
     * @return void
     */
    protected function tearDown()
    {
        unset($this->_CurrentCard);
        unset($this->_OtherCard);
        parent::tearDown();
    }


    /**
     * @test
     */
    public function compareToShouldReturnZeroWhenTheOtherCardIsOfTheSameValueAndSuit()
    {
        $this->_theCurrentCardIs('A-S')
            ->_andTheOtherCardIs('A-S');

        $this->_theCardsShouldBeEqual();
    }

    /**
     * @test
     */
    public function compareToShouldReturnLessThanZeroWhenTheOtherCardIsOfALesserFaceValueAndADifferentSuit()
    {
        $this->_theCurrentCardIs('7-D')
            ->_andTheOtherCardIs('6-H');

        $this->_theCurrentCardShouldBeGreater();
    }

    /**
     * @test
     */
    public function compareToShouldReturnLessThanZeroWhenTheOtherCardIsOfALesserFaceValueAndTheSameSuit()
    {
        $this->_theCurrentCardIs('7-C')
            ->_andTheOtherCardIs('6-C');

        $this->_theCurrentCardShouldBeGreater();
    }

    /**
     * @test
     */
    public function compareToShouldReturnGreaterThanZeroWhenTheOtherCardIsOfTheSameFaceValueButAGreaterSuit()
    {
        $this->_theCurrentCardIs('J-D')
            ->_andTheOtherCardIs('J-C');

        $this->_theOtherCardShouldBeGreater();
    }

    /**
     * @param string $cardString
     * @return Card
     */
    private function _makeCardFromString($cardString)
    {
        $CardBuilder = new CardBuilder();
        return $CardBuilder->fromString($cardString);
    }

    /**
     * @param string $cardString
     * @return CardTest
     */
    private function _theCurrentCardIs($cardString)
    {
        $this->_CurrentCard = $this->_makeCardFromString($cardString);
        return $this;
    }

    /**
     * @param string $string1
     * @return void
     */
    private function _andTheOtherCardIs($string1)
    {
        $this->_OtherCard = $this->_makeCardFromString($string1);

    }

    /**
     * @return void
     */
    private function _theCardsShouldBeEqual()
    {
        $this->assertEquals(0, $this->_CurrentCard->compareTo($this->_OtherCard));
    }

    /**
     * @return void
     */
    private function _theCurrentCardShouldBeGreater()
    {
        $this->assertLessThan(0, $this->_CurrentCard->compareTo($this->_OtherCard));
    }

    /**
     * @return void
     */
    private function _theOtherCardShouldBeGreater()
    {
        $this->assertGreaterThan(0, $this->_CurrentCard->compareTo($this->_OtherCard));
    }
}


