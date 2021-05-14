using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemy;

    private int _counter = 0;

    private GameObject _enemyClone;

    public GameObject EnemyClone
    {
        get { return _enemyClone; }
    }
    void Update()
    {
        if(_enemyClone == null && _counter == 0)
        {
            _counter++;
            _enemyClone = Instantiate(_enemy, transform.position, Quaternion.identity);
        }
    }
}
