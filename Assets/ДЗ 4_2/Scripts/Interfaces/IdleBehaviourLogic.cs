using UnityEngine;

public class IdleBehaviourLogic : IIdleBehaviour
{
    public void IdleBehaviour(EnemyController owner)
    {
        Debug.Log("� ���� �� �����");
    }

    public void StopIdleBehaviour()
    {
        
    }
}
