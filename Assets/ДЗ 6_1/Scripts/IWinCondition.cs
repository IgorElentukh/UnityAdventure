using System;

namespace Delegates.Events
{
    public interface IWinCondition
    {
        event Action WinAchieved;
        void CheckWinCondition();
    }
}
