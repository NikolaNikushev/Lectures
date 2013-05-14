using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace PokerTest
{
    [TestClass]
    public class HandsTester
    {
        [TestMethod]
        public void TestForRoyal()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
            });

            IPokerHandsChecker checker = new PokerHandsChecker();
            checker.CheckHand(hand);
            Assert.AreEqual(HandStrength.RoyalFlush, hand.Power);
        }

        [TestMethod]
        public void StraightFlush()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Clubs),
            });

            IPokerHandsChecker checker = new PokerHandsChecker();
            checker.CheckHand(hand);
            Assert.AreEqual(HandStrength.StraightFlush, hand.Power);
        }

        [TestMethod]
        public void TestForFourOfAKind()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Spades),
            });

            IPokerHandsChecker checker = new PokerHandsChecker();
            checker.CheckHand(hand);
            Assert.AreEqual(HandStrength.FourOfAKind, hand.Power);
        }

        [TestMethod]
        public void TestForFullHouse()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Diamonds),
            });

            IPokerHandsChecker checker = new PokerHandsChecker();
            checker.CheckHand(hand);
            Assert.AreEqual(HandStrength.FullHouse, hand.Power);
        }

        [TestMethod]
        public void TestForStraight()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Diamonds),
            });

            IPokerHandsChecker checker = new PokerHandsChecker();
            checker.CheckHand(hand);
            Assert.AreEqual(HandStrength.Straight, hand.Power);
        }

        [TestMethod]
        public void TestForFlush()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
            });

            IPokerHandsChecker checker = new PokerHandsChecker();
            checker.CheckHand(hand);
            Assert.AreEqual(HandStrength.Flush, hand.Power);
        }

        [TestMethod]
        public void TestThreeOfAKind()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
            });

            IPokerHandsChecker checker = new PokerHandsChecker();
            checker.CheckHand(hand);
            Assert.AreEqual(HandStrength.ThreeOfAKind, hand.Power);
        }

        [TestMethod]
        public void TestForTwoPair()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Clubs),
            });

            IPokerHandsChecker checker = new PokerHandsChecker();
            checker.CheckHand(hand);
            Assert.AreEqual(HandStrength.TwoPair, hand.Power);
        }

        [TestMethod]
        public void TestForOnePair()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs),
            });

            IPokerHandsChecker checker = new PokerHandsChecker();
            checker.CheckHand(hand);
            Assert.AreEqual(HandStrength.OnePair, hand.Power);
        }

        [TestMethod]
        public void TestForHighCard()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Diamonds),
            });

            IPokerHandsChecker checker = new PokerHandsChecker();
            checker.CheckHand(hand);
            Assert.AreEqual(HandStrength.HighCard, hand.Power);
        }

        [TestMethod]
        public void TestForTwoSameFaces()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
            });

            IPokerHandsChecker checker = new PokerHandsChecker();
            checker.CheckHand(hand);
            Assert.AreEqual(false, hand.IsValid);
        }

        [TestMethod]
        public void TestForMoreCards()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs)
            });

            IPokerHandsChecker checker = new PokerHandsChecker();
            checker.CheckHand(hand);
            Assert.AreEqual(false, hand.IsValid);
        }

        [TestMethod]
        public void TestForLessCards()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs)
            });

            IPokerHandsChecker checker = new PokerHandsChecker();
            checker.CheckHand(hand);
            Assert.AreEqual(false, hand.IsValid);
        }

        [TestMethod]
        public void TestForCompareGreater()
        {
            IHand highCardHand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Diamonds),
            });

            IHand straightHand = new Hand(new List<ICard>() { 
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Diamonds),
            });

            IPokerHandsChecker checker = new PokerHandsChecker();
            checker.CheckHand(straightHand);
            checker.CheckHand(highCardHand);
            Assert.AreEqual(1, checker.CompareHands(straightHand, highCardHand));
        }

        [TestMethod]
        public void TestForCompareSmaller()
        {
            IHand highCardHand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Diamonds),
            });

            IHand straightHand = new Hand(new List<ICard>() { 
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Diamonds),
            });

            IPokerHandsChecker checker = new PokerHandsChecker();
            checker.CheckHand(straightHand);
            checker.CheckHand(highCardHand);
            Assert.AreEqual(-1, checker.CompareHands(highCardHand, straightHand));
        }

        [TestMethod]
        public void TestForCompareEqual()
        {
            IHand straightHand1 = new Hand(new List<ICard>() { 
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Diamonds),
            });

            IHand straightHand = new Hand(new List<ICard>() { 
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Diamonds),
            });

            IPokerHandsChecker checker = new PokerHandsChecker();
            checker.CheckHand(straightHand);
            checker.CheckHand(straightHand1);
            Assert.AreEqual(0, checker.CompareHands(straightHand, straightHand1));
        }
    }
}
