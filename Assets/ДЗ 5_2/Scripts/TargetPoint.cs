using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TargetPoint : MonoBehaviour
{
    private NavMeshAgent _agent;
    private float _destroyDistance = 1f;

   public TargetPoint PlacePoint(Vector3 position, NavMeshAgent agent)
    {
        TargetPoint newPoint = Instantiate(this, position, Quaternion.identity);
        newPoint._agent = agent;

        return newPoint;
    }

    private void Update()
    {   
        if ((_agent.transform.position - transform.position).magnitude < _destroyDistance)
            Destroy(gameObject);
    }
}
