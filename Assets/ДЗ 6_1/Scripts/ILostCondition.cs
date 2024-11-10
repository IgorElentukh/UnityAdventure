using System;

namespace Delegates.Events
{
    public interface ILostCondition
    {
        event Action LoseAchieved;
        void CheckLoseCondition();
    }
}
