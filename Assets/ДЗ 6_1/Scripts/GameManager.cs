using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Delegates.Events
{
    public class GameManager : MonoBehaviour
    {
        private IWinCondition _winCondition;
        private ILostCondition _lostCondition;
        
        private IntervalSpawner<Enemy> _spawner;

        private List<Enemy> _entities = new List<Enemy>();

        public void Initialize(IntervalSpawner<Enemy> spawner, IWinCondition winCondition, ILostCondition lostCondition)
        {
            _spawner = spawner;
            _spawner.EntitySpawned += OnEntitySpawned;

            _winCondition = winCondition;
            _winCondition.WinAchieved += OnWinCondition;

            _lostCondition = lostCondition;
            _lostCondition.LoseAchieved += OnLostCondition;
        }

        private void Update()
        {
            _winCondition.CheckWinCondition();
            _lostCondition.CheckLoseCondition();
        }

        private void OnWinCondition()
        {
            Debug.Log("Победа!");
            Time.timeScale = 0;
        }

        private void OnLostCondition()
        {
            Debug.Log("Поражение :(");
            Time.timeScale = 0;
        }

        private void OnEntitySpawned(Enemy enemy)
        {
            _entities.Add(enemy);
            enemy.EnemyDied += OnEnemyDied;

            if (_lostCondition is TooManyEnemiesLooseCondition tooManyEnemies)
                tooManyEnemies.EnemySpawned();
        }

        private void OnEnemyDied(Enemy enemy)
        {
            enemy.EnemyDied -= OnEnemyDied;
            _entities.Remove(enemy);

            if (_winCondition is KillEnemiesWinCondition killEnemies)
                killEnemies.EnemyKilled();
        }

        private void OnDestroy()
        {
            _spawner.EntitySpawned -= OnEntitySpawned;
            _winCondition.WinAchieved -= OnWinCondition;
            _lostCondition.LoseAchieved -= OnLostCondition;
        }
    }
}
