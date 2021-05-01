using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExplosion : MonoBehaviour
{
    [SerializeField]
    private float _force;
    private CharacterController _object;
    private void Start()
    {
        Invoke(nameof(Delay), 2f);
    }

    private void Delay()
    {
        Destroy(gameObject);
    }
}
