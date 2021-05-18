using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ExplosionCode : MonoBehaviour
{
    private AudioSource _audioClip;
    void Start()
    {
        _audioClip = GetComponent<AudioSource>();
        _audioClip.Play();
        Invoke(nameof(Delay), 2f);
    }

    private void Delay()
    {
        Destroy(gameObject);
    }
}
