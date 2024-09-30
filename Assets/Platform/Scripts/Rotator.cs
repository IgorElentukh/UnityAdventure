using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _sensitivity;

    private void Update()
    {
        float aroundZRotation = Input.GetAxis("Horizontal") * _sensitivity;
        float aroundXRotation = Input.GetAxis("Vertical") * _sensitivity;

        transform.Rotate(Vector3.right, aroundXRotation, Space.World);
        transform.Rotate(-Vector3.forward, aroundZRotation, Space.World);

    }
}
