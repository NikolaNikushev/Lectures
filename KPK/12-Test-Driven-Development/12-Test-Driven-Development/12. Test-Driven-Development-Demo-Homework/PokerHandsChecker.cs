using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public void CheckHand(IHand hand)
        {
            if (IsValidHand(hand))
            {
                hand.Sort();
                bool foundPower = false;
                if (!foundPower)
                {
                    foundPower = IsRoyalFlush(hand);
                }
                if (!foundPower)
                {
                    foundPower = IsStraightFlush(hand);
                }
                if (!foundPower)
                {
                    foundPower = IsFourOfAKind(hand);
                }
                if (!foundPower)
                {
                    foundPower = IsFullHouse(hand);
                }
                if (!foundPower)
                {
                    foundPower = IsStraight(hand);
                }
                if (!foundPower)
                {
                    foundPower = IsFlush(hand);
                }
                if (!foundPower)
                {
                    foundPower = IsThreeOfAKind(hand);
                }
                if (!foundPower)
                {
                    foundPower = IsTwoPair(hand);
                }
                if (!foundPower)
                {
                    foundPower = IsOnePair(hand);
                }
                if (!foundPower)
                {
                    foundPower = IsHighCard(hand);
                }
            }
        }

        public bool IsValidHand(IHand hand)
        {
            if(hand.Cards.Count != 5)
            {
                return false;
            }
            for (int i = 0; i < hand.Cards.Count; i++)
            {
                for (int j = i + 1; j < hand.Cards.Count; j++)
                {
                    if(hand.Cards[i].Face == hand.Cards[j].Face)
                    {
                        if (hand.Cards[i].Suit == hand.Cards[j].Suit)
                        {
                            return false;
                        }
                    }
                }
                int cardCounter = 0;
                for (int j = i + 1; j < hand.Cards.Count; j++)
                {
                    if(hand.Cards[i].Face == hand.Cards[j].Face)
                    {
                        cardCounter++;
                        if(cardCounter > 4)
                        {
                            return false;
                        }
                    }
                }
            }
            hand.SetValid();
            return true;
        }

        public bool IsRoyalFlush(IHand hand)
        {
            int currentPower = Convert.ToInt32(hand.Power);
            if (currentPower <= 10)
            {
                if (hand.CardsAreOfSameSuit())
                {
                    if (hand.CardsAreFollowing(true))
                    {
                        hand.SetPower(HandStrength.RoyalFlush);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool IsStraightFlush(IHand hand)
        {
            int currentPower = Convert.ToInt32(hand.Power);
            if (currentPower <= 9)
            {
                if (hand.CardsAreOfSameSuit())
                {
                    if (hand.CardsAreFollowing(false))
                    {
                        hand.SetPower(HandStrength.StraightFlush);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            int currentPower = Convert.ToInt32(hand.Power);
            if (currentPower <= 8)
            {
                if(hand.Cards[0].Face == hand.Cards[1].Face &&
                    hand.Cards[0].Face == hand.Cards[2].Face &&
                     hand.Cards[0].Face == hand.Cards[3].Face)
                {
                    hand.SetPower(HandStrength.FourOfAKind);
                    return true;
                }
                else if (hand.Cards[1].Face == hand.Cards[2].Face &&
                    hand.Cards[1].Face == hand.Cards[3].Face &&
                     hand.Cards[1].Face == hand.Cards[4].Face)
                {
                    hand.SetPower(HandStrength.FourOfAKind);
                    return true;
                }
            }
            return false;
        }

        public bool IsFullHouse(IHand hand)
        {
            int currentPower = Convert.ToInt32(hand.Power);
            if (currentPower <= 7)
            {
                if (hand.Cards[0].Face == hand.Cards[1].Face && hand.Cards[0].Face == hand.Cards[2].Face)
                {
                    if (hand.Cards[3].Face == hand.Cards[4].Face)
                    {
                        hand.SetPower(HandStrength.FullHouse);
                        return true;
                    }
                }
                else if(hand.Cards[0].Face == hand.Cards[1].Face)
                {
                    if (hand.Cards[2].Face == hand.Cards[3].Face && hand.Cards[2].Face == hand.Cards[4].Face)
                    {
                        hand.SetPower(HandStrength.FullHouse);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool IsStraight(IHand hand)
        {
            int currentPower = Convert.ToInt32(hand.Power);
            if (currentPower <= 6)
            {
                if (hand.CardsAreFollowing(false))
                {
                    hand.SetPower(HandStrength.Straight);
                    return true;
                }
            }
            return false;
        }

        public bool IsFlush(IHand hand)
        {
            int currentPower = Convert.ToInt32(hand.Power);
            if (currentPower <= 5)
            {
                if (hand.CardsAreOfSameSuit())
                {
                    if (!hand.CardsAreFollowing(false))
                    {
                        hand.SetPower(HandStrength.Flush);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            int currentPower = Convert.ToInt32(hand.Power);
            if (currentPower <= 4)
            {
                for (int i = 0; i < hand.Cards.Count - 2; i++)
                {
                    bool isThreeOfAKind = false;
                    int cardCounter = 0;
                    for (int j = i + 1; j < hand.Cards.Count; j++)
                    {
                        if (hand.Cards[i].Face == hand.Cards[j].Face)
                        {
                            cardCounter++;
                            if (cardCounter == 2)
                            {
                                isThreeOfAKind = true;
                            }
                        }
                    }
                    if (isThreeOfAKind)
                    {
                        hand.SetPower(HandStrength.ThreeOfAKind);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool IsTwoPair(IHand hand)
        {
            int currentPower = Convert.ToInt32(hand.Power);
            if (currentPower <= 3)
            {
                int cardCounter = 0;
                for (int i = 0; i < hand.Cards.Count - 1; i++)
                {
                    if (hand.Cards[i].Face == hand.Cards[i + 1].Face)
                    {
                        cardCounter++;
                        i++;
                        if(cardCounter == 2)
                        {
                            hand.SetPower(HandStrength.TwoPair);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool IsOnePair(IHand hand)
        {
            int currentPower = Convert.ToInt32(hand.Power);
            if (currentPower <= 2)
            {
                for (int i = 0; i < hand.Cards.Count; i++)
                {
                    bool isOnePair = false;
                    for (int j = i + 1; j < hand.Cards.Count; j++)
                    {
                        if (hand.Cards[i].Face == hand.Cards[j].Face)
                        {
                            isOnePair = true;
                        }
                    }
                    if (isOnePair)
                    {
                        hand.SetPower(HandStrength.OnePair);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool IsHighCard(IHand hand)
        {
            int currentPower = Convert.ToInt32(hand.Power);
            if (currentPower <= 1)
            {
                hand.SetPower(HandStrength.HighCard);
                return true;
            }
            return false;
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            int firstPower = Convert.ToInt32(firstHand.Power);
            int secondPower = Convert.ToInt32(secondHand.Power);
            if(firstPower > secondPower)
            {
                return 1;
            }
            else if(firstPower == secondPower)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
}
