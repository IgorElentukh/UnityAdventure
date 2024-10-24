using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private AgentManager _agentManager;
    [SerializeField] private Mine _mine;
    [SerializeField] private TargetPoint _targetPointPrefab;
    [SerializeField] private LayerMask _groundMask;

    [SerializeField] private List<Transform> _minePoints;

    private NavMeshAgent _agent;
    private OnPointMover _mover;
    private AgentManager _manager;
    private Camera _mainCamera;


    private void Awake()
    {
        _mainCamera = Camera.main;
                
        _player = Instantiate(_player, Vector3.zero, Quaternion.identity);
        _agent = _player.GetComponent<NavMeshAgent>();

        foreach(Transform point in _minePoints)
            Instantiate(_mine, point.position, Quaternion.identity);

        _mover = new OnPointMover(_player.GetComponent<NavMeshAgent>());

        _agentManager = Instantiate(_agentManager, Vector3.zero, Quaternion.identity);
        _agentManager.Initialize(_mover, _agent, _mainCamera, _groundMask, _targetPointPrefab);
    }
}
