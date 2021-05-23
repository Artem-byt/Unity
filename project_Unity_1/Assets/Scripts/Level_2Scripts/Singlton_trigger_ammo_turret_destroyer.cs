using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(SphereCollider))]
public class Singlton_trigger_ammo_turret_destroyer : MonoBehaviour
{
    public static Singlton_trigger_ammo_turret_destroyer Ammo;

    private void Awake()
    {
        Ammo = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PersonMoveWithRigidBody>())
        {
            Debug.Log("Hit!");
            Destroy(gameObject);
        }
        else
        {
            Invoke(nameof(Destroyer), 3f);
        }
           
    }

    private void Destroyer()
    {
        Destroy(gameObject);
    }
}
