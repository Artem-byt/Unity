using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicTask : MonoBehaviour
{
    [SerializeField]
    private int[] _counter;
    [SerializeField]
    private int _sum;
    private bool _flag = true;
    GameObject[] _BtnTriggers;
    GameObject[] _Cubes;
    void Start()
    {
        _BtnTriggers = GameObject.FindGameObjectsWithTag("Task");
        _Cubes = GameObject.FindGameObjectsWithTag("Cubes");
        _counter = new int[_Cubes.Length];
        _sum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i< _Cubes.Length; i++)
        {
            if (_Cubes[i].GetComponent<MeshRenderer>().material.color == Color.red)
            {
                _counter[i] = 1;
            }
            else
            {
                _counter[i] = 0;
            }
            _sum += _counter[i];
            
        }
        if (_sum == _Cubes.Length && _flag)
        {
            Debug.Log("Победа");
            _flag = false;
        }
        else
        {
            _sum = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == _BtnTriggers[0])
        {
            _Cubes[0].GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else if(other.gameObject == _BtnTriggers[1])
        {
            _Cubes[1].GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else if(other.gameObject == _BtnTriggers[2])
        {
            _Cubes[2].GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
}
