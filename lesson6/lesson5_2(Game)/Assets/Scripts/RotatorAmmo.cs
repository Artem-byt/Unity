using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorAmmo : MonoBehaviour
{
    void Update()
    {
        gameObject.transform.Rotate(Vector3.right);
    }
}
