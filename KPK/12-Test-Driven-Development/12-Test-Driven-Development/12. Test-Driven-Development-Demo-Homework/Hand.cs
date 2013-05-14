using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Poker
{
    public class Hand : IHand
    {
        public HandStrength Power { get; private set; }
        public bool IsValid { get; private set; }
        public IList<ICard> Cards { get; private set; }

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (ICard card in Cards)
            {
                result.Append(card.ToString());
            }
            return result.ToString();
        }

        public void SetPower(HandStrength power)
        {
            this.Power = power;
        }

        public void SetValid()
        {
            this.IsValid = true;
        }

        public bool CardsAreOfSameSuit()
        {
            int counter = 0;
            foreach (ICard card in Cards)
            {
                if (card.Suit == Cards[0].Suit)
                {
                    counter++;
                }
            }
            if (counter == Cards.Count)
            {
                return true;
            }
            return false;
        }

        public bool CardsAreFollowing(bool checkIfRoyal)
        {
            //Get
            for (int i = 0; i < this.Cards.Count - 1; i++)
            {
                if (checkIfRoyal)
                {
                    if (this.Cards[4].Face == CardFace.Ace)
                    {
                        if (((int)this.Cards[i].Face) + 1 != (int)this.Cards[i + 1].Face)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (((int)this.Cards[i].Face) + 1 != (int)this.Cards[i + 1].Face)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void Sort() // Ascending
        {
            ICard[] sortedCards = this.Cards.ToArray();
            for (int i = 1; i <= sortedCards.Length; i++)
            {
                for (int j = 0; j < sortedCards.Length - i; j++)
                {
                    if ((int)sortedCards[j + 1].Face < (int)sortedCards[j].Face)
                    {
                        ICard swapCard = sortedCards[j];
                        sortedCards[j] = sortedCards[j + 1];
                        sortedCards[j + 1] = swapCard;
                    }
                }
            }
            this.Cards.Clear();
            foreach (ICard card in sortedCards)
            {
                this.Cards.Add(card);
            }
        }
    }
}
