using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretLookAndFire : MonoBehaviour
{
    [SerializeField]
    private GameObject _shootEffect;
    [SerializeField]
    private GameObject _shootTurret;
    [SerializeField]
    private float _speed = 10f;
    [SerializeField]
    private PersonMove _target;
    [SerializeField]
    private GameObject _sphere;
    [SerializeField]
    private Transform _fireStartPoint;
    [SerializeField]
    private Transform _fireEndPoint;
    [SerializeField]
    private float _force = 10f;
    [SerializeField]
    private Slider _sliderHP;

    private Vector3 _FireDir;
    private GameObject _sphereClone;
    private float _StartTime;
    private float _EndtTime;

    private Vector3 _targetDir;
    private Vector3 _newDir;

    private void Start()
    {
        _StartTime = Time.time;
    }

    private void Update()
    {

        if (_target.IsTriggerTurret)
        {
            _targetDir = _target.gameObject.transform.position - transform.position;
            _newDir = Vector3.RotateTowards(transform.forward, _targetDir, _speed * Time.deltaTime, 0.0F);
            transform.rotation = Quaternion.LookRotation(_newDir);
            if(_sliderHP.value > 0.5f)
                _target.MusicGame.pitch = 1.2f;
        }

        _EndtTime = Time.time;
        if ((_EndtTime - _StartTime) >= 1f && _target.IsTriggerTurret == true)
        {
            Fire();
        }
    }

    private void Fire()
    {
        Instantiate(_shootEffect, _fireEndPoint.position, Quaternion.identity);
        Instantiate(_shootTurret, _fireEndPoint.position, Quaternion.identity);
        _FireDir = _fireEndPoint.position - _fireStartPoint.position;
        _sphereClone = Instantiate(_sphere, _fireEndPoint.position, Quaternion.identity);
        Rigidbody _rb = _sphereClone.GetComponent<Rigidbody>();
        _rb.AddForce(_FireDir * _force, ForceMode.Impulse);
        _StartTime = Time.time;
    }
}
