using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentManager : MonoBehaviour
{
    public const int LeftMouseButton = 0;
    
    [SerializeField] private Player _player;
    [SerializeField] private LayerMask _grounMask;
    [SerializeField] private TargetPoint _targetPoint;

    private OnPointMover _mover;
    private Camera _mainCamera;
    private TargetPoint _curretTargetPoint;
    private float _stopDistance = 1f;

    private void Awake()
    {
        _mover = new OnPointMover(_player.Agent, _grounMask);
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        MovePlayer();
        StopPlayer();

    }

    private void PlaceTargetPoint(Vector3 point)
    {
        if (_curretTargetPoint != null)
            Destroy(_curretTargetPoint.gameObject);

        //point.y = -0.2f;

        _curretTargetPoint = _targetPoint.PlacePoint(point, _player.Agent);
    }

    private void MovePlayer()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton))
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, _grounMask))
            {
                if (_mover.CanMoveTo(hitInfo.point))
                {
                    _mover.MoveOn(hitInfo.point);
                    _player.View.StartRunning();
                    PlaceTargetPoint(hitInfo.point);
                }
            }
        }
    }

    private void StopPlayer()
    {
        if(_curretTargetPoint != null)
        {
            float distanceToTarget = (_player.transform.position - _curretTargetPoint.transform.position).magnitude;

            if(distanceToTarget <= _stopDistance)
                _player.View.StopRunning();
        }
        

    }
}
