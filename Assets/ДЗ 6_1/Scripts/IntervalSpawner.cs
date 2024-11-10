using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Delegates.Events
{
    public class IntervalSpawner<T> : IDisposable where T : MonoBehaviour
    {
        private T _entity;
        private List<Vector3> _spawnPositions;
        private float _spawnCooldown;

        private MonoBehaviour _context;
        private Coroutine _spawnCoroutine;

        public Action<T> EntitySpawned;

        public IntervalSpawner(T entity, List<Transform> spawnPositions, float spawnCooldown, MonoBehaviour context)
        {
            _entity = entity;
            _spawnPositions = spawnPositions.Select(position => position.position).ToList();
            _spawnCooldown = spawnCooldown;
            _context = context;

            _spawnCoroutine = _context.StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            while (true)
            {
                int index = Random.Range(0, _spawnPositions.Count);

                T newEntity = MonoBehaviour.Instantiate(_entity, _spawnPositions[index], Quaternion.identity);
                EntitySpawned?.Invoke(newEntity);

                yield return new WaitForSeconds(_spawnCooldown);
            }
        }

        public void Dispose()
        {
            _context.StopCoroutine(_spawnCoroutine);
            _spawnCoroutine = null;
        }
    }
}
