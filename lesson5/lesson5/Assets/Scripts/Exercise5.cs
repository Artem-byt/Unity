using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercise5 : MonoBehaviour
{
    [SerializeField]
    private GameObject _cube;
    private GameObject[] _gameObjects;
    private const int _number = 10000;
    private const float _speed = 10;
    void Start()
    {
        _gameObjects = new GameObject[_number];
        for(int i  = 0; i < _number; i++)
        {
            _gameObjects[i] = Instantiate(_cube, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }
    }

    void Update()
    {
        for(int i = 0; i<_number; i++)
        {
            _gameObjects[i].transform.Rotate(Vector3.up * Time.deltaTime * _speed);
        }
    }
}
