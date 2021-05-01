using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookandFolllowing : MonoBehaviour
{
    
    [SerializeField]
    private float _speed;
    
    private Vector3 _targetDir;
    private GameObject _enemy;

    private void FixedUpdate()
    {
        _enemy = GameObject.FindGameObjectWithTag("EnemyRobot");
    }
    private void OnTriggerStay(Collider other)
    {

        // _enemy.transform.LookAt(other.transform); робот-обижака
        _targetDir = other.transform.position - _enemy.transform.position;

        Vector3 newDir = Vector3.RotateTowards(_enemy.transform.forward, _targetDir, _speed * Time.deltaTime, 0.0F);
        Debug.DrawRay(_enemy.transform.position, newDir, Color.red);

        _enemy.transform.rotation = Quaternion.LookRotation(newDir);
        _enemy.transform.position = Vector3.MoveTowards(_enemy.transform.position, other.transform.position, _speed / 20 * Time.deltaTime);
    }
    
}
