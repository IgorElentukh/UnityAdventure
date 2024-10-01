using UnityEngine;


    public class PlayerController2 : MonoBehaviour
    {
        [SerializeField] private Mover3 _mover;
        
        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";

        private void Update()
        {
            Vector3 input = new Vector3(Input.GetAxisRaw(HorizontalAxis), 0, Input.GetAxisRaw(VerticalAxis));

            if (input.magnitude <= 0)
                return;

            _mover.ProcessMoveTo(input);
                _mover.ProcessRotateTo(input);
        }
    }

