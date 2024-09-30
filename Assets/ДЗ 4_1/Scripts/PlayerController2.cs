using UnityEngine;


    public class PlayerController2 : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _health;
        
        private CharacterController _characterController;

        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";

        private float _deadZone = 0.1f;

    public float MoveSpeed 
    { 
       get => _moveSpeed;
            
       set
       {
           if(value > 0) 
             _moveSpeed = value;
       }
    }

    public float Health 
    { 
        get => _health;

        set
        {           
            if(value > 0)
               _health = value;
        }
    }

    private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            Vector3 input = new Vector3(Input.GetAxisRaw(HorizontalAxis), 0, Input.GetAxisRaw(VerticalAxis));

            if (input.magnitude <= 0)
                return;

            ProcessMoveTo(input);
            ProcessRotateTo(input);
        }

        private void ProcessRotateTo(Vector3 direction)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction.normalized);
            float step = _rotationSpeed * Time.deltaTime;

            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, step);
        }

        private void ProcessMoveTo(Vector3 direction)
        {
            if (direction.magnitude < _deadZone)
                return;

            _characterController.Move(direction.normalized * MoveSpeed * Time.deltaTime);
        }
    }

