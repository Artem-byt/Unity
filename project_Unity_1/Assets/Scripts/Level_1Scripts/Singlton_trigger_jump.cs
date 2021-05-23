using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singlton_trigger_jump : MonoBehaviour
{
    public static Singlton_trigger_jump Jump;
    private bool _isGrounded;

    private const int IndexGround = 3;
    public bool IsGrounded => _isGrounded;
   
    private void Awake()
    {
        if (Jump == null)
            Jump = this;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.layer == IndexGround)
        {
            Debug.Log("True");
            _isGrounded = true;
        }

            
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == IndexGround)
        {
            Debug.Log("False");
            _isGrounded = false;
        }
    }
}
