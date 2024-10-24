using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour, IDamageable
{
    public const float LimitForInjuredLayer = 0.3f;
    public const float InjuredSpeed = 4f;
    public const float DeadZone = 2f;

    private Animator _animator;
    private NavMeshAgent _agent;
    public HealthComponent Health { get; private set; }
    public CharacterView View { get; private set; }

    private void Awake()
    {
        Health = new HealthComponent();
        _animator = GetComponentInChildren<Animator>();
        View = new CharacterView(_animator);
        _agent = GetComponent<NavMeshAgent>();
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
        {
            Debug.LogError("Урон не может быть меньше 0");
            return;
        }

        Health.TakeDamage(damage);

        if(Health.CurrentHealth <= 0)
        {
            View.Die();
            _agent.enabled = false;
        }
        
        View.GetHit();

        if (Health.CurrentHealth <= HealthComponent.MaxHealth * LimitForInjuredLayer)
        {
            View.SwitchInjuredLayer();
            _agent.speed = InjuredSpeed;
        }   
    }

    private void Update()
    {
        if(_agent.velocity.magnitude > DeadZone)
            View.StartRunning();
        else
            View.StopRunning();
    }
}
