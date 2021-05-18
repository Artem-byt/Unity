using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoTurretDestroyer : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Destroyer());
    }
    private IEnumerator Destroyer()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
}
