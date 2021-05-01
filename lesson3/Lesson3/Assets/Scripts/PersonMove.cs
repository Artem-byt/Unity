using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonMove : MonoBehaviour
{
    private float _speed = 4.0f;

    private float _jumpspeed = 8.0f;

    private float _gravity = 20.0f;

    private Vector3 _moveDir = Vector3.zero;

    private CharacterController _controller;

    private Animator _Animator;

    void Start()
    {
        _Animator = GetComponent<Animator>();
        _controller = GetComponent<CharacterController>();
        
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (_controller.isGrounded)
        {
           _moveDir = transform.TransformDirection(new Vector3(horizontal, 0, vertical).normalized * _speed);   
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _moveDir.y = _jumpspeed;
        }

        _moveDir.y -= _gravity * Time.deltaTime;

        _controller.Move(_moveDir * Time.deltaTime);


        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        _Animator.SetBool("Walk", isWalking);
    }
}

