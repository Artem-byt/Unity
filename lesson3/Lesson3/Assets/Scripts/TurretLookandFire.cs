using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLookandFire : MonoBehaviour
{
    [SerializeField]
    private Transform _target;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private GameObject _sphere;
    
    private Vector3 _targetDir;

    private void Update()
    {
       if ((gameObject.transform.position - _target.position).magnitude <= 10)
        {
            _targetDir = _target.position - transform.position;
            
            Vector3 newDir = Vector3.RotateTowards(transform.forward, _targetDir, _speed * Time.deltaTime, 0.0F);
            Debug.DrawRay(transform.position, newDir, Color.red);

            transform.rotation = Quaternion.LookRotation(newDir);
            
            
        }
    }
}
