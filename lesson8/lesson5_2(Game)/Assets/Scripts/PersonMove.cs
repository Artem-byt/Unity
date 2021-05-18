using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(Animator))]
public class PersonMove : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;
    private float _jumpspeed = 8.0f;
    private float _gravity = 20.0f;

    private Vector3 _moveDir = Vector3.zero;
    private CharacterController _controller;
    private Animator _Animator;
    private AudioSource _musicGame;

    private bool _hasHorizontalInput;
    private bool _hasVerticalInput;
    private bool _isWalking;
    private float _horizontal;
    private float _vertical;
    private bool _triggerTurret;
    private float _StartTime;
    private float _EndTime;
    private bool _speedTablet;

    public bool IsTriggerTurret
    {
        get { return _triggerTurret; }
    }
    public AudioSource MusicGame
    {
        get { return _musicGame; }
        set { _musicGame = value; }
    }

    private void Awake()
    {
        _Animator = GetComponent<Animator>();
        _controller = GetComponent<CharacterController>();
        _triggerTurret = false;
        _speedTablet = false;
        _musicGame = GetComponent<AudioSource>();
        _musicGame.pitch = 0.8f;
    }

    void Update()
    {
        _EndTime = Time.time;
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        if (_controller.isGrounded)
        {
            _moveDir = new Vector3(_horizontal, 0, _vertical);
            _moveDir = transform.TransformDirection(_moveDir);
            _moveDir *= _speed;
        }
        if (Input.GetKey(KeyCode.Space) && _controller.isGrounded)
        {
            _moveDir.y = _jumpspeed * 1.5f;
        }
        if (Input.GetKeyDown(KeyCode.Space) && _controller.isGrounded)
        {
            _moveDir.y = _jumpspeed;
        }
        
        if ((_EndTime - _StartTime) <= 25f && _speedTablet)
        {
            _speed = 8.0f;
        }
        else
        {
            _speed = 4.0f;
            _speedTablet = false;
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
        if (other.gameObject.GetComponentInParent<TurretLookAndFire>())
        {
            _triggerTurret = true;
        }
        if(other.gameObject.GetComponent<SphereCollider>())
        {
            _speedTablet = true;
            _StartTime = Time.time;
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponentInParent<TurretLookAndFire>())
        {
            _triggerTurret = false;
        }
    }
}

