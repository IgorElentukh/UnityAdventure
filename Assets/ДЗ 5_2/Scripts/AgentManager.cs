using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class AgentManager : MonoBehaviour
{
    public const int LeftMouseButton = 0;

    [SerializeField] private AnimationCurve _jumpCurve;
    [SerializeField] private float _jumpTime;

    private OnPointMover _mover;
    private Jumper _jumper;
    private NavMeshAgent _agent;
    private Camera _mainCamera;
    private LayerMask _groundMask;
    private AudioHandler _audioHandler;

    private TargetPoint _targetPointPrefab;
    private TargetPoint _curretTargetPoint;

    private bool _isInitialized;

    public void Initialize(OnPointMover mover, NavMeshAgent agent, Camera mainCamera, LayerMask groundMask, TargetPoint targetPointPrefab, Jumper jumper, AudioHandler audioHandler)
    {
        _mover = mover;
        _jumper = jumper;
        _agent = agent;
        _mainCamera = mainCamera;
        _groundMask = groundMask;
        _targetPointPrefab = targetPointPrefab;
        _isInitialized = true;
        _audioHandler = audioHandler;
    }

    private void Update()
    {
        if (_isInitialized == false) // Камера почему-то была null в методах CanMoveTo и MovePlayer
            return;

        if (_agent.isOnOffMeshLink)
            _jumper.Jump(_jumpCurve, _jumpTime);

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
        if (Input.GetMouseButtonDown(LeftMouseButton))
        {
            _audioHandler.PlaySound(0);

            if (CanMoveTo(Input.mousePosition) && IsUIClicked() == true)
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

    private bool IsUIClicked()
    {
        return !EventSystem.current.IsPointerOverGameObject();
    }
}



