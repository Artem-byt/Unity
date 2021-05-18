using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTurretSound : MonoBehaviour
{
    private AudioSource _audioSource;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();
        Invoke(nameof(Destroy), 4f);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
