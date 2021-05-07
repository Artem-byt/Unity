using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercise5Rotator : MonoBehaviour
{
    private const int _number = 10000;
    private const float _speed = 10;
    void Update()
    {
        for (int i = 0; i < _number; i++)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * _speed);
        }
    }
}
