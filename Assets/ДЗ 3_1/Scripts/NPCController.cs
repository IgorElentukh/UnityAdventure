using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField] private int _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _minDistanceToTarget;
    
    [SerializeField] private PointsController _pointsController;

    private int _index = 0;

    private Vector3 _direction;

    private void Update()
    {
        MoveToNextPoint();
        RotateTo(_direction);
    }

    private void MoveToNextPoint()
    {
        _direction = _pointsController.Points[_index].position - transform.position;
        transform.Translate(_direction.normalized * _speed * Time.deltaTime, Space.World);

        if (_direction.magnitude < _minDistanceToTarget)
            _index++;

        if(_index == _pointsController.Points.Count)
        {
            _pointsController.PlacePoints();
            _pointsController.SortPointsByDistance();
            _index = 0;
        }
    }

    private void RotateTo(Vector3 direction)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        float step = _rotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, step);
    }
}
