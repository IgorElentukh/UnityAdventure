using System.Collections.Generic;
using UnityEngine;



public class LootSpawner : MonoBehaviour
{
        
    [SerializeField] private SpeedLoot _speedPrefab; 
    [SerializeField] private HealthLoot _healthPrefab;
    [SerializeField] private BulletLoot _bulletPrefab;

    [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();

    private void Start()
    {
        for (int i = 0; i < _spawnPoints.Count; i++)
        {
            int index = Random.Range(0, 3);

            switch (index)
            {
                case 0:
                    Instantiate(_speedPrefab, _spawnPoints[i].position, Quaternion.identity);
                    break;

                case 1:
                    Instantiate(_healthPrefab, _spawnPoints[i].position, Quaternion.identity);
                    break;

                case 2:
                    Instantiate(_bulletPrefab, _spawnPoints[i].position, Quaternion.identity);
                    break;
            }
        }

    }
    
}

