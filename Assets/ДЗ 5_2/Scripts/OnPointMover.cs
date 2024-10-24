using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OnPointMover
{
    private NavMeshAgent _agent;
    //private Camera _mainCamera;
    //private LayerMask _interactableLayer;

    public OnPointMover(NavMeshAgent agent /*LayerMask interactableLayer*/)
    {
        _agent = agent;
        //_interactableLayer = interactableLayer;
        //_mainCamera = Camera.main;
    }

    

    public void MoveOn(Vector3 targetPoint)
    {
        _agent.SetDestination(targetPoint);
    }
}
