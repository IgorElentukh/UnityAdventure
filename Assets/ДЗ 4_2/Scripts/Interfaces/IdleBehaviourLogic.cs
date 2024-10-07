using UnityEngine;

public class IdleBehaviourLogic : IIdleBehaviour
{
    public void IdleBehaviour(EnemyController owner)
    {
        Debug.Log("Я стою на месте");
    }

    public void StopIdleBehaviour()
    {
        
    }
}
