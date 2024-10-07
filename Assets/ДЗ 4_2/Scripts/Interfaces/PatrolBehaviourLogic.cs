using UnityEngine;

public class PatrolBehaviourLogic : IIdleBehaviour
{
    private const float MinDistanceToChangeDirection = 0.1f;

    private Vector3 _currentTarget;
    private int index = 0;
    public void IdleBehaviour(EnemyController owner)
    {
        _currentTarget = owner.PatrolPoints.Points[index].position;

        Vector3 direction = _currentTarget - owner.transform.position;

        owner.EnemyMover.ProcessMoveTo(direction);
        owner.EnemyRotator.ProcessRotateTo(direction);

        if (direction.magnitude < MinDistanceToChangeDirection)
        {
            index++;

            if (index == owner.PatrolPoints.Points.Length)
                index = 0;
        }
    }

    public void StopIdleBehaviour()
    {
      
    }
}
