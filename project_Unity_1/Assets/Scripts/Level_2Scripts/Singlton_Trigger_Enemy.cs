using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Singlton_Trigger_Enemy : MonoBehaviour
{
    public static Singlton_Trigger_Enemy TriggerEnemy;

    private bool _triggerEnemy;
    private GameObject _enemy;

    public bool IsTriggerenemy => _triggerEnemy;
    public GameObject Enemy
    {
        get { return _enemy; }
        set { _enemy = value; }
    }
    private void Awake()
    {
        _triggerEnemy = false;
        TriggerEnemy = this;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<NavMeshAgent>())
        {
            _enemy = other.gameObject;
        }
        else
        {
            _triggerEnemy = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        _triggerEnemy = false;
    }
}
