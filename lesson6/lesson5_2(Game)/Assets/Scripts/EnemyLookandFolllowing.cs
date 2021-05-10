using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookandFolllowing : MonoBehaviour
{
    
    [SerializeField]
    private float _speed;
    
    private Vector3 _targetDir;
    [SerializeField]
    private Spawner _spawnEnemy;

    private GameObject _enemy;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<WaypointPatrol>())
        {
            Debug.Log("Поражение");
            Application.Quit();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.GetComponent<EmptyScriptForEnemy>() != null)
        {
            _enemy = _spawnEnemy.EnemyClone;
            _enemy.GetComponent<WaypointPatrol>()._IsTrigger = true;
            _targetDir = transform.position - _enemy.transform.position;

            Vector3 newDir = Vector3.RotateTowards(_enemy.transform.forward, _targetDir, _speed * Time.deltaTime, 0.0F);
            Debug.DrawRay(_enemy.transform.position, newDir, Color.red);

            _enemy.transform.rotation = Quaternion.LookRotation(newDir);
            _enemy.transform.position = Vector3.MoveTowards(_enemy.transform.position, transform.position, _speed / 20 * Time.deltaTime);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.GetComponent<EmptyScriptForEnemy>() != null)
            _enemy.GetComponent<WaypointPatrol>()._IsTrigger = false;
    }
}
