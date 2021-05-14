using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyHint : MonoBehaviour
{
    public UnityEvent OnStart;

    private void Start()
    {
        if (OnStart == null)
            OnStart = new UnityEvent();
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            OnStart.Invoke();
        }
    }
}
