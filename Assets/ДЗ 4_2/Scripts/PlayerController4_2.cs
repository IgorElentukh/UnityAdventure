using UnityEngine;

public class PlayerController4_2 : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed;

    private CharacterController _characterController;

    private CharacterMover _playerMover;
    private CharacterRotator _playerRotator;

    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();

        _playerMover = new CharacterMover(_movementSpeed, _characterController);
        _playerRotator = new CharacterRotator(_rotationSpeed, transform);
    }

    private void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw(HorizontalAxis), 0, Input.GetAxisRaw(VerticalAxis));

        if (input.sqrMagnitude <= 0)
            return;
        
        _playerMover.ProcessMoveTo(input);
        _playerRotator.ProcessRotateTo(input);
    }
}
