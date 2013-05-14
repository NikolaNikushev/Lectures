using System;
using System.Collections.Generic;

namespace Poker
{
    public interface IHand
    {
        HandStrength Power { get; }
        bool IsValid { get; }
        IList<ICard> Cards { get; }
        string ToString();
        void SetPower(HandStrength power);
        void SetValid();
        bool CardsAreOfSameSuit();
        bool CardsAreFollowing(bool checkForRoyal);
        void Sort();
    }
}
