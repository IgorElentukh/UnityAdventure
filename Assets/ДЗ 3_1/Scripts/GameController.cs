using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _npc;

    [SerializeField] private float _maxDistanceToNPC;
    [SerializeField] private float _riskDistanceToNPC;
    [SerializeField] private float _timeToWin;
    
    private float _actualDistance;
    private float _timer;
    private bool _isGameFinished = false;

    private Vector3 _directionOnNPC;
    private Vector3 _playerPosition;
    private Vector3 _npcPosition;

    private void Awake()
    {
        _playerPosition = _player.position;
        _npcPosition = _npc.position;
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _timeToWin)
            WinGame();
        
        _directionOnNPC = _npc.position - _player.position;
        _actualDistance = _directionOnNPC.magnitude;

        if (_maxDistanceToNPC - _actualDistance  > _riskDistanceToNPC)
            Debug.DrawRay(_player.position, _directionOnNPC, Color.green);
        else if (_maxDistanceToNPC - _actualDistance < _riskDistanceToNPC)
            Debug.DrawRay(_player.position, _directionOnNPC, Color.yellow);

        if (_actualDistance > _maxDistanceToNPC)
            GameOver();

        if (_isGameFinished == false)
            return;

        if(Input.GetKeyDown(KeyCode.Space))
            RestartGame();
    }

    private void WinGame()
    {
        EndGame();

        Debug.Log("Поздравляем, вы выиграли! Для перезапуска игры нажмите Пробел");
    }

    private void GameOver()
    {
        EndGame();

        Debug.Log("К сожалению вы отстали от врага и проиграли. Для перезапуска игры нажмите Пробел");
    }
    private void RestartGame()
    {
        _player.gameObject.SetActive(true);
        _npc.gameObject.SetActive(true);

        _isGameFinished = false;
        _timer = 0;

        _player.position = _playerPosition;
        _npc.position = _npcPosition;
    }

    private void EndGame()
    {
        _player.gameObject.SetActive(false);
        _npc.gameObject.SetActive(false);
        _isGameFinished = true;
    }
}
