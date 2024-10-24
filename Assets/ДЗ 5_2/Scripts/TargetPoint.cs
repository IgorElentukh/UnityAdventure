using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TargetPoint : MonoBehaviour
{
    private NavMeshAgent _agent;
    private float _destroyDistance = 1f;
    public void Initialize(NavMeshAgent agent)
    {
        _agent = agent;
    }

    private void Update()
    {
        if ((_agent.transform.position - transform.position).magnitude < _destroyDistance)
            Destroy(gameObject);
    }
}
