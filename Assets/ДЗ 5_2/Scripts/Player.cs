using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public const float LimitForInjuredLayer = 0.3f;

    private Animator _animator;
    public HealthComponent Health { get; private set; }
    public CharacterView View { get; private set; }
    public NavMeshAgent Agent { get; private set; }

    private void Awake()
    {
        Health = new HealthComponent();
        _animator = GetComponentInChildren<Animator>();
        View = new CharacterView(_animator);
        Agent = GetComponent<NavMeshAgent>();
    }
}
