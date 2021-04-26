using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonMove : MonoBehaviour
{
    float _speed = 4.0f;

    float _jumpspeed = 8.0f;

    float gravity = 20.0f;

    Vector3 moveDir = Vector3.zero;

    CharacterController controller;

    Animator m_Animator;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (controller.isGrounded)
        {
            moveDir = new Vector3(horizontal, 0, vertical);
            moveDir = transform.TransformDirection(moveDir);
            moveDir *= _speed;
        }

        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            moveDir.y = _jumpspeed;
        }

        moveDir.y -= gravity * Time.deltaTime;

        controller.Move(moveDir * Time.deltaTime);


        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool("Walk", isWalking);


    }

    void Update()
    {
       
    }

    void OnAnimatorMove()
    {
        
    }
}

