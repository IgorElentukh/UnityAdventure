using UnityEngine;

public class RunAwayReaction : IReactOnPlayerBehaviour
{
    public void ReactOnPlayer(EnemyController owner)
    {
        Vector3 runDirection = owner.PlayerController.forward;

        owner.EnemyMover.ProcessMoveTo(runDirection);
        owner.EnemyRotator.ProcessRotateTo(runDirection);
    }
}
