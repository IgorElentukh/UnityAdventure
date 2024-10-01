using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover2 : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;

    private Rigidbody _rigidbody;

    private float _xInput;
    private bool _isJump;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _xInput = Input.GetAxisRaw("Horizontal");



        if(Input.GetKeyDown(KeyCode.Space))
            _isJump = true;

        
        
    }

    private void FixedUpdate()
    {
        if (_xInput != 0)
        {
            _rigidbody.AddTorque(-Vector3.forward * _xInput);
        }

        if (_isJump == true)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce * Time.deltaTime, ForceMode.Impulse);
            _isJump=false;
        }
    }
}
