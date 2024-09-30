using System.Collections.Generic;
using UnityEngine;

public class PointsController : MonoBehaviour
{
    [SerializeField] private float _xDimensionOfBorders;
    [SerializeField] private float _zDimensionOfBorders;

    [SerializeField] private Transform _npcController;

    private float _minDistanceToNPC = float.MaxValue;

    [field: SerializeField] public List<Transform> Points { get; private set; }

    private void Awake()
    {
        PlacePoints();
        SortPointsByDistance();
    }

    public void PlacePoints()
    {
        foreach (Transform point in Points)
        {
            float xCoordinate = Random.Range(-_xDimensionOfBorders, _xDimensionOfBorders);
            float zCoordinate = Random.Range(-_zDimensionOfBorders, _zDimensionOfBorders);

            point.localPosition = new Vector3(xCoordinate, point.position.y, zCoordinate);
        }
    }

    public void SortPointsByDistance()
    {
        for (int i = 0; i < Points.Count - 1; i++)
        {
            for (int j = i + 1; j < Points.Count; j++)
            {
                float distance1ToNPC = Vector3.Distance(_npcController.position, Points[i].position);
                float distance2ToNPC = Vector3.Distance(_npcController.position, Points[j].position);

                if (distance1ToNPC > distance2ToNPC)
                {
                    Transform temp = Points[i];
                    Points[i] = Points[j];
                    Points[j] = temp;
                }
            }
        }
    }
}
