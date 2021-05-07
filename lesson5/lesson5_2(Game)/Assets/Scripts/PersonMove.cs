using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(Animator))]
public class PersonMove : MonoBehaviour
{
    private float _speed = 4.0f;
    private float _jumpspeed = 8.0f;
    private float _gravity = 20.0f;

    private Vector3 _moveDir = Vector3.zero;
    private CharacterController _controller;
    private Animator _Animator;

    private bool _hasHorizontalInput;
    private bool _hasVerticalInput;
    private bool _isWalking;
    private float _horizontal;
    private float _vertical;
    private bool _triggerTurret;
    private bool _triggerEnemy;

    public bool IsTriggerTurret
    {
        get { return _triggerTurret; }
    }

    public bool IsTriggerEnemy
    {
        get { return _triggerEnemy; }
    }

    void Start()
    {
        _Animator = GetComponent<Animator>();
        _controller = GetComponent<CharacterController>();
        _triggerTurret = false;
        _triggerEnemy = false;
    }

    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        if (_controller.isGrounded)
        {
            _moveDir = new Vector3(_horizontal, 0, _vertical);
            _moveDir = transform.TransformDirection(_moveDir);
            _moveDir *= _speed;
        }

        if (Input.GetKeyDown(KeyCode.Space) && _controller.isGrounded)
        {
            _moveDir.y = _jumpspeed;
        }

        _moveDir.y -= _gravity * Time.deltaTime;
        _controller.Move(_moveDir * Time.deltaTime);

        _hasHorizontalInput = !Mathf.Approximately(_horizontal, 0f);
        _hasVerticalInput = !Mathf.Approximately(_vertical, 0f);
        _isWalking = _hasHorizontalInput || _hasVerticalInput;
        _Animator.SetBool("Walk", _isWalking);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<TurretLookAndFire>() != null)
        {
            _triggerTurret = true;
        }
        //else if (other.gameObject.GetComponent<>())
        //{
        //    _triggerEnemy = true;
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponentInParent<TurretLookAndFire>() != null)
        {
            _triggerTurret = false;
        }
        //else if (other.gameObject.GetComponent<>())
        //{
        //    _triggerEnemy = false;
        //}
    }
}

