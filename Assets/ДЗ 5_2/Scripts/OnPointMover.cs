using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OnPointMover
{
    private NavMeshAgent _agent;
    private AnimationCurve _jumpCurve;

    public OnPointMover(NavMeshAgent agent)
    {
        _agent = agent;
    }

    public void MoveOn(Vector3 targetPoint)
    {
        _agent.SetDestination(targetPoint);
    }
}
