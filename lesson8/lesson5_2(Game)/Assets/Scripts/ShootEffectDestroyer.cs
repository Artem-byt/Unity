using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEffectDestroyer : MonoBehaviour
{
    private void Start()
    {
        Invoke(nameof(Destroy), 4f);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
