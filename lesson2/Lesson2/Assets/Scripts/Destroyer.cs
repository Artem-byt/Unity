using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Animator _animator = GetComponent<Animator>();
        rb.MovePosition(rb.position + new Vector3(0, 0, 0.5f)*Time.deltaTime);
        _animator.SetBool("Walk", true);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Granade"))
        {
            Destroy(gameObject);
        }
    }
}
