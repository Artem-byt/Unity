using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskOpenGates : MonoBehaviour
{
    [SerializeField]
    private GameObject _Gates;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<EmptyScriptForTask>() != null)
        {
            Destroy(_Gates);
        }
    }
}
