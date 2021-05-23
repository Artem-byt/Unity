using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(Animator))]
public class PersonMove : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;
    private const float _jumpspeed = 8.0f;
    private const float _gravity = 20.0f;

    private Vector3 _moveDir = Vector3.zero;
    private CharacterController _controller;
    private Animator _animator;

    private float _horizontal;
    private float _vertical;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        if (Singlton_trigger_jump.Jump.IsGrounded)
        {
            _moveDir = new Vector3(_horizontal, 0, _vertical);
            _moveDir = transform.TransformDirection(_moveDir);
            _moveDir *= _speed;
        }
     
        if (Input.GetKey(KeyCode.Space) && Singlton_trigger_jump.Jump.IsGrounded)
        {
            _moveDir.y = _jumpspeed;
        }

        _moveDir.y -= _gravity * Time.deltaTime;
        _controller.Move(_moveDir * Time.deltaTime);

        _animator.SetBool("Walk", !Mathf.Approximately(_horizontal, 0f) || !Mathf.Approximately(_vertical, 0f));
    }
}

