using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private EnemyController _enemyControllerPrefab;
    [SerializeField] private IdleBehaviour _idleBehaviourSetting;
    [SerializeField] private ReactionOnPlayer _reactionOnPlayerSetting;

    private IIdleBehaviour _idleBehaviour;
    private IReactOnPlayerBehaviour _reactOnPlayerBehaviour;

    private void Awake()
    {
        InitializePoint();
        SpawnEnemy();
    }

    private void InitializePoint()
    {
        switch (_idleBehaviourSetting)
        {
            case IdleBehaviour.Idle:
                _idleBehaviour = new IdleBehaviourLogic();
                break;

            case IdleBehaviour.Patrol:
                _idleBehaviour = new PatrolBehaviourLogic();
                break;

            case IdleBehaviour.Walking:
                _idleBehaviour = new WalkingBehaviourLogic();
                break;
        }

        switch (_reactionOnPlayerSetting)
        {
            case ReactionOnPlayer.RunAway:
                _reactOnPlayerBehaviour = new RunAwayReaction();
                break;

            case ReactionOnPlayer.PlayerChasing:
                _reactOnPlayerBehaviour = new ChasingReaction();
                break;

            case ReactionOnPlayer.Die:
                _reactOnPlayerBehaviour = new DieReaction();
                break;
        }
    }

    private void SpawnEnemy()
    {
        EnemyController newEnemy = Instantiate(_enemyControllerPrefab, transform.position, 
                                                                                    Quaternion.Euler(new Vector3(0,-180, 0)));
        newEnemy.Initialize(_idleBehaviour, _reactOnPlayerBehaviour);
    }
}
