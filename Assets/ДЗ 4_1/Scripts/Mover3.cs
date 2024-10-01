using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover3 : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;

    private CharacterController _characterController;

    private float _deadZone = 0.1f;

    public float MoveSpeed
    {
        get => _moveSpeed;

        set
        {
            if (value > 0)
                _moveSpeed = value;
        }
    }

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public void ProcessMoveTo(Vector3 direction)
    {
        if (direction.magnitude < _deadZone)
            return;

        _characterController.Move(direction.normalized * MoveSpeed * Time.deltaTime);
    }

    public void ProcessRotateTo(Vector3 direction)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction.normalized);
        float step = _rotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, step);
    }

}
