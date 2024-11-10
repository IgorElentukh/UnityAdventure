using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Delegates.Events
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Player _player;

        [SerializeField] private Enemy _enemy;
        [SerializeField] private List<Transform> _spawnPoints;
        [SerializeField] private Collider _movementArea;
        [SerializeField] private float _spawnCooldown;

        [SerializeField] private GameManager _gameManager;
        [SerializeField] private WinCondition _winCondition;
        [SerializeField] private LostCondition _lostCondition;
        [SerializeField] private float _timeToWin;
        [SerializeField] private int _enemiesToKill;
        [SerializeField] private int _enemiesToLoose;

        private Mover _mover;
        private Rotator _rotator;

        private IntervalSpawner<Enemy> _enemySpawner;

        private IWinCondition _iWinCondition;
        private ILostCondition _iLostCondition;

        private void Awake()
        {            
            SpawnPlayer();
            SpawnEnemies();
            SpawnGameManager();
        }

        private void SpawnPlayer()
        {
            _mover = new Mover();
            _rotator = new Rotator();

            _player = Instantiate(_player, new Vector3(0, 1, 0), Quaternion.identity);
            _player.Initialize(_mover, _rotator); // первый игрок не инициализируется
        }

        private void SpawnEnemies()
        {
            _enemySpawner = new IntervalSpawner<Enemy>(_enemy, _spawnPoints, _spawnCooldown, this);

            _enemySpawner.EntitySpawned = ((enemy) => enemy.Initialize(_movementArea));
        }

        private void OnDisable()
        {
            _enemySpawner.Dispose();
        }

        private void SpawnGameManager()
        {
            switch (_winCondition)
            {
                case WinCondition.SurviveForTime:
                    _iWinCondition = new SurviveTimeWinCondition(_timeToWin);
                    break;

                case WinCondition.KillEnemies:
                    _iWinCondition = new KillEnemiesWinCondition(_enemiesToKill);
                    break;
            }

            switch (_lostCondition)
            {
                case LostCondition.TooManyEnemiesSpawned:
                    _iLostCondition = new TooManyEnemiesLooseCondition(_enemiesToLoose);
                    break;

                case LostCondition.PlayerDeath:
                    _iLostCondition = new PlayerDeathLooseCondition(_player);
                    break;
            }

            _gameManager = Instantiate(_gameManager);

            _gameManager.Initialize(_enemySpawner, _iWinCondition, _iLostCondition);
        }
    }
}
