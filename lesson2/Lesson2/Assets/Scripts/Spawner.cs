using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    [SerializeField]
    GameObject enemy;
    GameObject _enemyClone;
    // Update is called once per frame
    void Update()
    {
        if (_enemyClone == null)
        {
            _enemyClone = Instantiate(enemy, this.transform.position, Quaternion.identity);
     
        }
    }

    
}
