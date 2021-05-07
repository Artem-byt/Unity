using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercise5Generator : MonoBehaviour
{
    [SerializeField]
    private GameObject _cube;
    private GameObject[] _gameObjects;
    private const int _number = 10000;
    void Start()
    {
        _gameObjects = new GameObject[_number];
        for (int i = 0; i < _number; i++)
        {
            _gameObjects[i] = Instantiate(_cube, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }
    }
}
