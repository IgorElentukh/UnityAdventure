using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentManager : MonoBehaviour
{
    public const int LeftMouseButton = 0;

    private OnPointMover _mover;
    private NavMeshAgent _agent;
    private Camera _mainCamera;
    private LayerMask _groundMask;

    private TargetPoint _targetPointPrefab;
    private TargetPoint _curretTargetPoint;

    private bool _isInitialized;

    public void Initialize(OnPointMover mover, NavMeshAgent agent, Camera mainCamera, LayerMask groundMask, TargetPoint targetPointPrefab)
    {
        _mover = mover;
        _agent = agent;
        _mainCamera = mainCamera;
        _groundMask = groundMask;
        _targetPointPrefab = targetPointPrefab;
        _isInitialized = true;
    }

    private void Update()
    {
        if (_isInitialized == false) // Камера почему-то была null в методах CanMoveTo и MovePlayer
            return;

        MovePlayer();
    }

    private void PlaceTargetPoint(Vector3 point)
    {
        if (_curretTargetPoint != null)
            Destroy(_curretTargetPoint.gameObject);

        point.y = -0.2f;

        _curretTargetPoint = Instantiate(_targetPointPrefab, point, Quaternion.identity);
        _curretTargetPoint.Initialize(_agent);
    }

    public bool CanMoveTo(Vector3 rayPoint)
    {
        Ray ray = _mainCamera.ScreenPointToRay(rayPoint);

        return Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, _groundMask);
    }

    private void MovePlayer()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton) && CanMoveTo(Input.mousePosition))
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, _groundMask))
            {
                _mover.MoveOn(hitInfo.point);
                PlaceTargetPoint(hitInfo.point);

            }
        }
    }
}



