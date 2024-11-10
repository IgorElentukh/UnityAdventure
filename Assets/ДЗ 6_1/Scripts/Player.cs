using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Delegates.Events
{
    public class Player : MonoBehaviour, IDamageable
    {
        private const string HorizontalInput = "Horizontal";
        private const string VerticalInput = "Vertical";
        private const int LeftMouseButton = 0;

        public event Action PlayerDied;

        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _shootForce;
        [SerializeField] private int _maxHealth;

        [SerializeField] private Bullet _bullet;
        [SerializeField] private Transform _shootPosition;
        [SerializeField] private int _damage;

        private Mover _mover;
        private Rotator _rotator;
        private CharacterController _characterController;
        
        public Health Health { get; private set; }

        public void Initialize(Mover mover, Rotator rotator)
        {
            _mover = mover;
            _rotator = rotator;
            _characterController = GetComponent<CharacterController>();
            Health = new Health(_maxHealth);

            Health.Changed += OnHealthChanged;
        }

        public void TakeDamage(int damage)
        {
            Health.Reduce(damage);
        }

        private void Update()
        {
            if(Input.GetMouseButtonDown(LeftMouseButton))
            {
                Bullet newBullet = Instantiate(_bullet, _shootPosition.position, Quaternion.identity);
                newBullet.Launch(_shootForce, transform.forward, _damage);
            }
            
            Vector3 input = new Vector3(Input.GetAxisRaw(HorizontalInput), 0, Input.GetAxisRaw(VerticalInput));

            if (input.sqrMagnitude <= 0)
                return;

            _mover.MoveTo(input, _movementSpeed, _characterController);
            _rotator.RotateTo(input, _rotationSpeed, transform);
        }

        private void OnHealthChanged(int currentHealth)
        {
            Debug.Log(currentHealth);

            if(currentHealth <= 0)
            {
                PlayerDied?.Invoke();
                Destroy(gameObject);
            }
               
        }

        private void OnDestroy()
        {
            Health.Changed -= OnHealthChanged;
        }
    }
}
