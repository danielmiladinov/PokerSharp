<?php

class CardBuilderTest extends PHPUnit_Framework_TestCase {
    /**
     * @var CardBuilder
     */
    private $_CardBuilder;

    public function setUp() {
        $this->_CardBuilder = new CardBuilder();
    }

    /**
     * @test
     * @return void
     */
    public function willThrowAnExceptionFromInvalidString() {
        $invalidString = 'aa';

        $this->setExpectedException('CardBuilderException', 'Invalid card string');

        $this->_CardBuilder->fromString($invalidString);
    }

    /**
     * @test
     * @return void
     */
    public function willThrowAnExceptionFromInvalidNumberTooHigh() {
        $invalidString = '15-C';

        $this->setExpectedException('CardBuilderException', 'Invalid face value');

        $this->_CardBuilder->fromString($invalidString);
    }

    /**
     * @test
     * @return void
     */
    public function willThrowAnExceptionFromInvalidNumberTooLow() {
        $invalidString = '1-C';

        $this->setExpectedException('CardBuilderException', 'Invalid face value');

        $this->_CardBuilder->fromString($invalidString);
    }

    /**
     * @test
     * @return void
     */
    public function willThrowAnExceptionFromInvalidSuit() {
        $invalidString = '2-Z';

        $this->setExpectedException('CardBuilderException', 'Invalid suit');

        $this->_CardBuilder->fromString($invalidString);
    }

    /**
     * @test
     * @return void
     */
    public function willGetACardWithValidParameters() {
        $invalidString = '2-C';
        $ExpectedCard = new Clubs(2);

        $ActualCard = $this->_CardBuilder->fromString($invalidString);

        $this->assertEquals($ExpectedCard, $ActualCard);
    }

    /**
     * @test
     * @return void
     */
    public function willGetACardWithFaceCard() {
        $invalidString = 'Q-S';
        $ExpectedCard = new Spades(Card::QUEEN);

        $ActualCard = $this->_CardBuilder->fromString($invalidString);

        $this->assertEquals($ExpectedCard, $ActualCard);
    }

    /**
     * @test
     * @return void
     */
    public function willGetACardWithJacks() {
        $invalidString = 'J-H';
        $ExpectedCard = new Hearts(Card::JACK);

        $ActualCard = $this->_CardBuilder->fromString($invalidString);

        $this->assertEquals($ExpectedCard, $ActualCard);
    }

    /**
     * @test
     * @return void
     */
    public function willGetACardWithKings() {
        $invalidString = 'K-D';
        $ExpectedCard = new Diamonds(Card::KING);

        $ActualCard = $this->_CardBuilder->fromString($invalidString);

        $this->assertEquals($ExpectedCard, $ActualCard);
    }

    /**
     * @test
     * @return void
     */
    public function willGetACardWithAce() {
        $invalidString = 'A-C';
        $ExpectedCard = new Clubs(Card::ACE);

        $ActualCard = $this->_CardBuilder->fromString($invalidString);

        $this->assertEquals($ExpectedCard, $ActualCard);
    }
}