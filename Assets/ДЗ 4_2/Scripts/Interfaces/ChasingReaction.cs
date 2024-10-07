using UnityEngine;

public class ChasingReaction : IReactOnPlayerBehaviour
{
    public void ReactOnPlayer(EnemyController owner)
    {
        Vector3 direction = owner.PlayerController.position - owner.transform.position;

        owner.EnemyMover.ProcessMoveTo(direction);
        owner.EnemyRotator.ProcessRotateTo(direction);
    }
}
