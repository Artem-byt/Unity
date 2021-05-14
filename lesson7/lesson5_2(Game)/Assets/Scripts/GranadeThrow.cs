using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadeThrow : MonoBehaviour
{
    [SerializeField]
    float _force;
    [SerializeField]
    private Rigidbody _granade;
    [SerializeField]
    private Transform _spawn;
    [SerializeField]
    private int _granadeAmmo = 5;
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0) && _granadeAmmo > 0)
        {
            _granadeAmmo--;
            var granadeClone = Instantiate(_granade, _spawn.position, Quaternion.identity);
            granadeClone.AddForce(_spawn.forward * _force, ForceMode.Impulse);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<RotatorAmmo>() != null && _granadeAmmo < 5)
        {
            _granadeAmmo = 5;
            Destroy(other.gameObject);
        }
    }
}
