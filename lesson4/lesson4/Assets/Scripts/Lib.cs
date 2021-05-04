using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lib : MonoBehaviour
{
    [SerializeField]
    private string[] _names;
    [SerializeField]
    private Texture[] _Images;

    public Texture Get(int i)
    {
        return _Images[i];
    }

}
