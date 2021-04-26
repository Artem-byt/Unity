using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField]
    private GameObject _door;
    private void OnTriggerEnter(Collider other)
    {
        Destroy(_door);
    }
}
