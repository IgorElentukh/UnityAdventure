using UnityEngine;

public class CharacterMover
{
    private float _movementSpeed;
    private float _deadZone = 0.1f;

    private CharacterController _characterController;

    public CharacterMover(float movementSpeed, CharacterController characterController)
    {
        _movementSpeed = movementSpeed;
        _characterController = characterController;
    }

    public void ProcessMoveTo(Vector3 direction)
    {
        if (direction.sqrMagnitude < _deadZone * _deadZone)
            return;

        _characterController.Move(direction.normalized * _movementSpeed * Time.deltaTime);
    }
}
