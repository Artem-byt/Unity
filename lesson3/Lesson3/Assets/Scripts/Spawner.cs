using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemy;
    

    private GameObject _enemyClone;
    void Update()
    {
        if(_enemyClone == null)
        {
            _enemyClone = Instantiate(_enemy, transform.position, Quaternion.identity);
        }
    }
}
