using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Triggers : MonoBehaviour
{
    //для поворота туррели
    [SerializeField]
    private GameObject _turretMGMAin;
    [SerializeField]
    private float _speed = 10f;

    //[SerializeField]
    //private GameObject _shootEffect;
    //[SerializeField]
    //private GameObject _shootTurret;
    //Для снаряда туррели
    [SerializeField]
    private GameObject _sphere;
    [SerializeField]
    private Transform _fireStartPoint;
    [SerializeField]
    private Transform _fireEndPoint;
    [SerializeField]
    private float _force = 10f;

    //разворот туррели
    private Vector3 _targetDir;
    private Vector3 _newDir;

    //Для снаряда Туррели
    private Vector3 _FireDir;
    private GameObject _sphereClone;
    private float _StartTime;
    private float _EndtTime;
    private Rigidbody _rb;


    [SerializeField]
    private Transform[] _waypoints;
    private int _CurrentWaypointIndex = 0;
    private float _timeStart;
    private float _timeEnd;

    private void Update()
    {
        if (Siglton_Trigger_Turret.Turret.IsTriggerTurret)
        {
            _targetDir = transform.position - _turretMGMAin.transform.position;
            _newDir = Vector3.RotateTowards(_turretMGMAin.transform.forward, _targetDir, _speed * Time.deltaTime, 0.0F);
            _turretMGMAin.transform.rotation = Quaternion.LookRotation(_newDir);
        }

        _EndtTime = Time.time;
        if ((_EndtTime - _StartTime) >= 1f && Siglton_Trigger_Turret.Turret.IsTriggerTurret)
        {
            Fire();
        }

        _timeEnd = Time.time;
        if (Singlton_Trigger_Enemy.TriggerEnemy.Enemy.GetComponent<NavMeshAgent>() && Singlton_Trigger_Enemy.TriggerEnemy.Enemy.GetComponent<NavMeshAgent>().remainingDistance < Singlton_Trigger_Enemy.TriggerEnemy.Enemy.GetComponent<NavMeshAgent>().stoppingDistance && !Singlton_Trigger_Enemy.TriggerEnemy.IsTriggerenemy && (_timeEnd - _timeStart) > 5f)
        {
            Singlton_Trigger_Enemy.TriggerEnemy.Enemy.GetComponent<Animator>().SetBool("Walk", true);
            _CurrentWaypointIndex = (_CurrentWaypointIndex + 1) % _waypoints.Length;
            Singlton_Trigger_Enemy.TriggerEnemy.Enemy.GetComponent<NavMeshAgent>().SetDestination(_waypoints[_CurrentWaypointIndex].position);
        }
        else if (Singlton_Trigger_Enemy.TriggerEnemy.IsTriggerenemy)
        {
            Singlton_Trigger_Enemy.TriggerEnemy.Enemy.GetComponent<Animator>().SetBool("Walk", true);
            Singlton_Trigger_Enemy.TriggerEnemy.Enemy.GetComponent<NavMeshAgent>().ResetPath();
            _timeStart = Time.time;
            _targetDir = transform.position - Singlton_Trigger_Enemy.TriggerEnemy.Enemy.transform.position;
            Vector3 newDir = Vector3.RotateTowards(Singlton_Trigger_Enemy.TriggerEnemy.Enemy.transform.forward, _targetDir, _speed * Time.deltaTime, 0.0F);
            Singlton_Trigger_Enemy.TriggerEnemy.Enemy.transform.rotation = Quaternion.LookRotation(newDir);
            Singlton_Trigger_Enemy.TriggerEnemy.Enemy.transform.position = Vector3.MoveTowards(Singlton_Trigger_Enemy.TriggerEnemy.Enemy.transform.position, transform.position, _speed / 2 * Time.deltaTime);
        }
        if (!Singlton_Trigger_Enemy.TriggerEnemy.IsTriggerenemy && !Singlton_Trigger_Enemy.TriggerEnemy.Enemy.GetComponent<NavMeshAgent>().hasPath && (_timeEnd - _timeStart) < 5f)
        {
            Singlton_Trigger_Enemy.TriggerEnemy.Enemy.GetComponent<Animator>().SetBool("Walk", false);
        }
    }

    private void Fire()
    {
        //Instantiate(_shootEffect, _fireEndPoint.position, Quaternion.identity);
        //Instantiate(_shootTurret, _fireEndPoint.position, Quaternion.identity);
        _FireDir = _fireEndPoint.position - _fireStartPoint.position;
        _sphereClone = Instantiate(_sphere, _fireEndPoint.position, Quaternion.identity);
        _rb = _sphereClone.GetComponent<Rigidbody>();
        _rb.AddForce(_FireDir * _force, ForceMode.Impulse);
        _StartTime = Time.time;
    }
}
