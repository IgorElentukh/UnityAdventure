using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    private CharacterController _characterController;

    private const string HorizontalAxisName = "Horizontal"; 
    private const string VerticalAxisName = "Vertical";

    private float _deadZone = 0.1f;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw(HorizontalAxisName), 0, Input.GetAxisRaw(VerticalAxisName));

        ProcessMoveTo(input);

        ProcessRotate(input);
    }

    private void ProcessMoveTo(Vector3 direction)
    {
        if (direction.magnitude < _deadZone)
            return;

        _characterController.Move(direction.normalized * _speed * Time.deltaTime);
    }

    private void ProcessRotate(Vector3 direction)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction.normalized);
        float step = _rotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, step);
    }
}
