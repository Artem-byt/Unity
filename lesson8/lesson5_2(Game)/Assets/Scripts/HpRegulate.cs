using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HpRegulate : MonoBehaviour
{
    [SerializeField]
    private PersonMove _target;

    private AudioSource _GameMusicHorror;

    [SerializeField]
    private Slider _sliderHP;

    private void Awake()
    {
        _GameMusicHorror = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<AmmoTurretDestroyer>())
        {
            _sliderHP.value -= 0.1f;
        }
        if (_sliderHP.value <= 0)
        {
            Debug.Log("Поражение");
            SceneManager.LoadScene("SampleScene");
            //Application.Quit();
        }
        if (_sliderHP.value <= 0.5f)
        {
            _GameMusicHorror.pitch = 1.4f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_sliderHP.value > 0.5f)
        {
            _GameMusicHorror.pitch = 0.8f;
        }
    }
}
