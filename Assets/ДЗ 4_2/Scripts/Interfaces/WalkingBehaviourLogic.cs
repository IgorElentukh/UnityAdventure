using UnityEngine;

public class WalkingBehaviourLogic : IIdleBehaviour
{
    private float _timer;
    private float _yRotationDeg;
    public void IdleBehaviour(EnemyController owner)
    {
        _timer += Time.deltaTime;

        if (_timer >= 1f)
        {
            _timer = 0f;
            _yRotationDeg = ChangeDirection();
        }

        owner.transform.rotation = Quaternion.Euler(0, _yRotationDeg, 0);

        owner.EnemyMover.ProcessMoveTo(owner.transform.forward);
        owner.EnemyRotator.ProcessRotateTo(owner.transform.forward);
    }

    public void StopIdleBehaviour()
    {
      
    }

    private int ChangeDirection()
    {
        return Random.Range(0, 361);
    }

    
}
