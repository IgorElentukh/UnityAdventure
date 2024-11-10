using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Delegates.Events
{
    public class TooManyEnemiesLooseCondition : ILostCondition
    {
        public event Action LoseAchieved;

        private int _maxEnemies;
        private int _spawnedEnemies = 0;

        public TooManyEnemiesLooseCondition(int maxEnemies)
        {
            _maxEnemies = maxEnemies;
        }

        public void CheckLoseCondition()
        {
            if(_spawnedEnemies >= _maxEnemies)
                LoseAchieved?.Invoke();
        }

        public void EnemySpawned()
        {
            _spawnedEnemies++;
        }
    }
}
