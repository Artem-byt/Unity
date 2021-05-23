using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider), typeof(Animator))]
public class PersonMoveWithRigidBody : MonoBehaviour
{
    private float _speed;
    private float _force;

    private Vector3 _moveDir;
    private Animator _animator;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _force = 1500f;
        _speed = 2500f;
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _moveDir = transform.TransformDirection(_moveDir);
        _rigidbody.AddForce(_moveDir * _speed);
        _animator.SetBool("Walk", !Mathf.Approximately(Input.GetAxis("Horizontal"), 0f) || !Mathf.Approximately(Input.GetAxis("Vertical"), 0f));
        if(Singlton_trigger_jump.Jump.IsGrounded && Input.GetKey(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector3.up * _force);
        }
    }
}
