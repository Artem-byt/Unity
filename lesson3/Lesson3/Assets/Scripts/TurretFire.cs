using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFire : MonoBehaviour
{
    [SerializeField]
    private GameObject _sphere;
    [SerializeField]
    private Transform _fireExit;
    [SerializeField]
    private GameObject _target;
    [SerializeField]
    private float _force = 5f;

    private Vector3 _FireDir;
    private GameObject _sphereClone;
    private float _StartTime;
    private float _EndtTime;
    private bool _FirstShot = true;
    private void Update()
    {
        _EndtTime = Time.time;
        if (((_target.transform.position - _fireExit.position).magnitude <= 10 && (_EndtTime - _StartTime) >= 1f) || _FirstShot == true)
        {
            Fire();
            _FirstShot = false;
        }
            
        
    }

    private void Fire()
    {     
        _FireDir = _target.transform.position - _fireExit.position;
        _sphereClone = Instantiate(_sphere, _fireExit.position, Quaternion.identity);
        Rigidbody _rb = _sphereClone.GetComponent<Rigidbody>();
        _rb.AddForce(_FireDir * _force, ForceMode.Impulse);
        _StartTime = Time.time;
    }
}
