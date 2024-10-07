using UnityEngine;

public class CharacterRotator
{
    private float _rotationSpeed;
    private Transform _owner;

    public CharacterRotator(float rotationSpeed, Transform owner)
    {
        _rotationSpeed = rotationSpeed;
        _owner = owner;
    }

    public void ProcessRotateTo(Vector3 direction)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction.normalized);
        float step = _rotationSpeed * Time.deltaTime;

        _owner.rotation = Quaternion.RotateTowards(_owner.rotation, lookRotation, step);
    }
}
