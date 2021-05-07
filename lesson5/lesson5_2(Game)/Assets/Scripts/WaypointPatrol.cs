using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class WaypointPatrol : MonoBehaviour
{

    [SerializeField]
    private Transform[] _waypoints;

    private NavMeshAgent _navMeshAgent;
    private int _CurrentWaypointIndex;
    [SerializeField]
    private bool _isTrigger;

    private GameObject _player;
    private Animator _animator;

    private float _timeStart;
    private float _timeEnd;

    public GameObject _Player
    {
        get { return _player; }
        set { _player = value; }
    }
    public bool _IsTrigger
    {
        get { return _isTrigger; }
        set { _isTrigger = value; }
    }
    private void Awake()
    {
        _isTrigger = false;
    }

    private void Start ()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.SetDestination(_waypoints[0].position);
        _animator = GetComponent<Animator>();
    }

    private void Update ()
    {
        _timeEnd = Time.time;
        if (_navMeshAgent.remainingDistance < _navMeshAgent.stoppingDistance && !_isTrigger && (_timeEnd - _timeStart) > 5f)
        {
            _animator.SetBool("Walk", true);
            _CurrentWaypointIndex = (_CurrentWaypointIndex + 1) % _waypoints.Length;
            _navMeshAgent.SetDestination(_waypoints[_CurrentWaypointIndex].position);
        }
        else if (_isTrigger)
        {
            _navMeshAgent.ResetPath();
            _timeStart = Time.time;
        }
        if(!_isTrigger && !_navMeshAgent.hasPath && (_timeEnd - _timeStart) < 5f)
        {
            _animator.SetBool("Walk", false);
        }
    }
}
