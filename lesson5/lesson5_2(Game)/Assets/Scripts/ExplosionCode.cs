using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionCode : MonoBehaviour
{

    void Start()
    {
        Invoke("Delay", 2f);
    }

    private void Delay()
    {
        Destroy(gameObject);
    }
}
