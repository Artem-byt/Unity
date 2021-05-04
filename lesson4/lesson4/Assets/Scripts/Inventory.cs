using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private int[] _items;
    [SerializeField]
    private int _mouseSlot;
    [SerializeField]
    private Lib _libs;

    private bool _flag = false;
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            _flag = false;
        }
    }
    private void OnGUI()
    {
        
        if (Input.GetKey(KeyCode.O) || _flag)
        {
            _flag = true;
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {

                    if (GUI.Button(new Rect(x * 100, y * 100, 100, 100), _libs.Get(_items[y * 5 + x])))
                    {
                        int _loc = _items[y * 5 + x];
                        _items[y * 5 + x] = _mouseSlot;
                        _mouseSlot = _loc;
                    }
                }
            }
            GUI.DrawTexture(new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, 100, 100), _libs.Get(_mouseSlot));
        }
    }
}
