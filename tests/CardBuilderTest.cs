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
        $validString = '2-C';
        $ExpectedCard = new Clubs(2);

        $ActualCard = $this->_CardBuilder->fromString($validString);

        $this->assertEquals($ExpectedCard, $ActualCard);
    }

    /**
     * @test
     * @return void
     */
    public function willGetACardWithFaceCard() {
        $validString = 'Q-S';
        $ExpectedCard = new Spades(Card::QUEEN);

        $ActualCard = $this->_CardBuilder->fromString($validString);

        $this->assertEquals($ExpectedCard, $ActualCard);
    }

    /**
     * @test
     * @return void
     */
    public function willGetACardWithJacks() {
        $validString = 'J-H';
        $ExpectedCard = new Hearts(Card::JACK);

        $ActualCard = $this->_CardBuilder->fromString($validString);

        $this->assertEquals($ExpectedCard, $ActualCard);
    }

    /**
     * @test
     * @return void
     */
    public function willGetACardWithKings() {
        $validString = 'K-D';
        $ExpectedCard = new Diamonds(Card::KING);

        $ActualCard = $this->_CardBuilder->fromString($validString);

        $this->assertEquals($ExpectedCard, $ActualCard);
    }

    /**
     * @test
     * @return void
     */
    public function willGetACardWithAce() {
        $validString = 'A-C';
        $ExpectedCard = new Clubs(Card::ACE);

        $ActualCard = $this->_CardBuilder->fromString($validString);

        $this->assertEquals($ExpectedCard, $ActualCard);
    }
}