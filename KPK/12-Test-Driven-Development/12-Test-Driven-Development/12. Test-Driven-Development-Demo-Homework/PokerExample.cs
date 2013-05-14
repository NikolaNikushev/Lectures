using System;
using System.Collections.Generic;

namespace Poker
{
    class PokerExample
    {
        static void Main()
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
            Console.WriteLine(hand.Power);
        }
    }
}
