using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private AgentManager _agentManager;
    [SerializeField] private Mine _mine;
    [SerializeField] private TargetPoint _targetPointPrefab;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;
    [SerializeField] private AudioHandler _audioHandler;

    [SerializeField] private List<Transform> _minePoints;

    private NavMeshAgent _agent;
    private OnPointMover _mover;
    private Jumper _jumper;
    private Camera _mainCamera;


    private void Awake()
    {
        _mainCamera = Camera.main;
        _audioHandler.Initialize();
                
        _player = Instantiate(_player, Vector3.zero, Quaternion.identity);
        _agent = _player.GetComponent<NavMeshAgent>();
        _virtualCamera.Follow = _player.transform;

        foreach (Transform point in _minePoints)
        {
            Mine newMine = Instantiate(_mine, point.position, Quaternion.identity);
            newMine.Initialize(_audioHandler);
        }

        _mover = new OnPointMover(_player.GetComponent<NavMeshAgent>());
        _jumper = new Jumper(this, _agent);

        _agentManager = _player.GetComponent<AgentManager>();
        _agentManager.Initialize(_mover, _agent, _mainCamera, _groundMask, _targetPointPrefab, _jumper, _audioHandler);
    }
}
