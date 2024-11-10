using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Delegates.Events
{
    public class AgentMover : IDisposable
    {
        private float _intervalToChangeDirection;
        private Collider _movementArea;
        private NavMeshAgent _agent;
        private MonoBehaviour _context;

        private Coroutine _movementCoroutine;
        private Vector3 _targetPoint;
        private float _distaneToChangeDirection = 0.5f;

        public AgentMover(float intervalToChangeDirection, Collider movementArea, NavMeshAgent agent, MonoBehaviour context)
        {
            _intervalToChangeDirection = intervalToChangeDirection;
            _movementArea = movementArea;
            _agent = agent;
            _context = context;

            if (_movementCoroutine == null)
                _movementCoroutine = _context.StartCoroutine(ChangeDirection());
        }

        private IEnumerator ChangeDirection()
        {
            while (true)
            { 
                    SetNewRandomDestination();

                    float timeElapsed = 0f;

                    while (timeElapsed < _intervalToChangeDirection)
                    {
                        if (HasReachedTarget())
                        {
                            SetNewRandomDestination();
                            timeElapsed = 0f;
                        }

                        timeElapsed += Time.deltaTime;
                        yield return null;
                    }
            }
        }

        private bool HasReachedTarget() => _agent.remainingDistance <= _distaneToChangeDirection;

        private void SetNewRandomDestination()
        {
            _targetPoint = GetRandomPointInCollider();
            _agent.SetDestination(_targetPoint);
        }

        private Vector3 GetRandomPointInCollider()
        {
            Bounds bounds = _movementArea.bounds;

            float randomX = Random.Range(bounds.min.x, bounds.max.x);
            float randomZ = Random.Range(bounds.min.z, bounds.max.z);

            Vector3 point = new Vector3(randomX, 0f, randomZ);

            return point;
        }

        public void Dispose()
        {
            if (_movementCoroutine != null)
            {
                _context.StopCoroutine(_movementCoroutine);
                _movementCoroutine = null;
            }
        }
    }
}
