using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Delegates.Events
{
    public class Enemy : MonoBehaviour, IDamageable
    {
        public event Action<Enemy> EnemyDied;
        
        [SerializeField] private float _intervalToChangeDirection;
        [SerializeField] private int _damage;
        [SerializeField] private int _maxHealth;

        private Collider _movementArea;
        private NavMeshAgent _agent;
        private AgentMover _mover;
        
        public Health Health { get; private set; }

        public void Initialize(Collider movementArea)
        {
            _movementArea = movementArea;
            _agent = GetComponent<NavMeshAgent>();

            _mover = new AgentMover(_intervalToChangeDirection, _movementArea, _agent, this);

            Health = new Health(_maxHealth);
            Health.Changed += OnHealthChanged;
        }

        private void OnHealthChanged(int currentHealth)
        {
            if(currentHealth <= 0)
            {
                EnemyDied?.Invoke(this);
                Destroy(gameObject);
            } 
        }

        public void TakeDamage(int damage)
        {
            Health.Reduce(damage);
        }

        private void OnCollisionEnter(Collision collision)
        {
            IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();

            if (damageable != null && damageable is Player player)
            {
                damageable.TakeDamage(_damage);
            }
        }
    }
}
