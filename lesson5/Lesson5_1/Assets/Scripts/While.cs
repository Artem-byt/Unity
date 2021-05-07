using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class While : MonoBehaviour
{
    private int _counter;

    void Update()
    {
        _counter = 0;
        while(_counter < 500)
        {
            Debug.Log(_counter.ToString());
            _counter++;
        }
    }
}
