using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroygranade : MonoBehaviour
{
    [SerializeField]
    private GameObject _explosion;

    void OnCollisionEnter(Collision collision)
    {
        Instantiate(_explosion, this.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
