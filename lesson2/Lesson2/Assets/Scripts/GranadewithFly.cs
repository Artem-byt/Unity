using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadewithFly : MonoBehaviour
{
    [SerializeField]
    GameObject _granade;
    [SerializeField]
    GameObject _spawnObject;
    [SerializeField]
    Camera _mainCamera;
    [SerializeField]
    float force;
    

    Vector3 _spawn;
    Rigidbody rb;
    
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            _spawn = new Vector3(_spawnObject.transform.position.x, _spawnObject.transform.position.y, _spawnObject.transform.position.z);
            var granadeClone = Instantiate(_granade, _spawn, Quaternion.identity);
            rb = granadeClone.GetComponent<Rigidbody>();
            rb.AddForce(ray.direction * force, ForceMode.Impulse);
        }       
    }

}
