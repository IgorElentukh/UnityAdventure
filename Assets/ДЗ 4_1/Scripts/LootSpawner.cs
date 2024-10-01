using System.Collections.Generic;
using UnityEngine;



public class LootSpawner : MonoBehaviour
{
    [SerializeField] private Loot[] _lootPrefabs;    
    [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();

    private void Start()
    {
        foreach(Transform point in _spawnPoints)
        {
            Instantiate(_lootPrefabs[Random.Range(0, _lootPrefabs.Length)], point.position, Quaternion.identity);
        }
    }
    
}

