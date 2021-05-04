using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Following : MonoBehaviour
{
    [SerializeField]
    private WaypointPatrol _follower;
    [SerializeField]
    private TextMesh _text;

    private int _counter;
    private void Awake()
    {
        _counter = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        _counter++;
        _text.text = _counter.ToString();
        _follower._Player = other.gameObject;
        _follower._IsTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        _follower._Player = null;
        _follower._IsTrigger = false;
    }
}
