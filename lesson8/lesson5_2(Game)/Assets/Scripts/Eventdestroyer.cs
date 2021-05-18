using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eventdestroyer : MonoBehaviour
{
    [SerializeField]
    private DestroyHint _destroy;

    private void Start()
    {
        _destroy.OnStart.AddListener(Destroyer);
    }

    private void OnDestroy()
    {
        _destroy.OnStart.RemoveAllListeners();
    }

    private void Destroyer()
    {
            Destroy(gameObject);
    }
}
