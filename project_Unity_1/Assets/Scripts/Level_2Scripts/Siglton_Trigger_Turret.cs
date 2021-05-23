using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siglton_Trigger_Turret : MonoBehaviour
{
    public static Siglton_Trigger_Turret Turret;
    private bool _triggerTurret;

    public bool IsTriggerTurret => _triggerTurret;

    private void Awake()
    {
        Turret = this;
        _triggerTurret = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PersonMoveWithRigidBody>())
            _triggerTurret = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PersonMoveWithRigidBody>())
            _triggerTurret = false;
    }
}
