using System;

namespace Delegates.Events
{
    public class KillEnemiesWinCondition : IWinCondition
    {
        public event Action WinAchieved;

        private int _enemiesToKill;
        private int _enemiesKilled = 0;

        public KillEnemiesWinCondition(int enemiesToKill)
        {
            _enemiesToKill = enemiesToKill;
        }

        public void CheckWinCondition()
        {
            if(_enemiesKilled >= _enemiesToKill)
                WinAchieved?.Invoke();
        }

        public void EnemyKilled()
        {
            _enemiesKilled++;
        }
    }
}
