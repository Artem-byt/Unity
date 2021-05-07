using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoTurretDestroyer : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(Destroyer());
    }
    private IEnumerator Destroyer()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
