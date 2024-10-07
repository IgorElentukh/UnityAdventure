using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public const float MovementSpeed = 6f;
    public const float RotationSpeed = 300f;
    public const float AgroDistance = 10f;

    private CharacterController _characterController;

    private IIdleBehaviour _idleBehaviour;
    private IReactOnPlayerBehaviour _reactOnPlayerBehaviour;

    [field: SerializeField] public ParticleSystem DieEffect { get; private set; }
    public Transform PlayerController { get; private set; }
    public CharacterMover EnemyMover { get; private set; }
    public CharacterRotator EnemyRotator { get; private set; }
    public PatrolPoints PatrolPoints { get; private set; }

    public void Initialize(IIdleBehaviour idleBehaviour, IReactOnPlayerBehaviour reactOnPlayerBehaviour)
    {
        _idleBehaviour = idleBehaviour;
        _reactOnPlayerBehaviour = reactOnPlayerBehaviour;
    }

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();

        PlayerController = GameObject.FindObjectOfType<PlayerController4_2>().GetComponent<Transform>();
        PatrolPoints = GameObject.FindObjectOfType<PatrolPoints>().GetComponent<PatrolPoints>();

        EnemyMover = new CharacterMover(MovementSpeed, _characterController);
        EnemyRotator = new CharacterRotator(RotationSpeed, transform);
    }

    private void Update()
    {
        float distanceToPlayer = (PlayerController.position - transform.position).magnitude;

        if (distanceToPlayer <= AgroDistance)
        {
            _idleBehaviour.StopIdleBehaviour();
            _reactOnPlayerBehaviour.ReactOnPlayer(this);
        }
        else
        {
            _idleBehaviour.IdleBehaviour(this);
        }
    }


}
