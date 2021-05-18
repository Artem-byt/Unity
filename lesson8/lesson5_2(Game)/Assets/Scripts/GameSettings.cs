using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    [SerializeField]
    private Button _button;
    [SerializeField]
    private Slider _sliderVolume;
    [SerializeField]
    private AudioSource _HorrorMusic;
    private void Awake()
    {
        _sliderVolume.value = _HorrorMusic.volume;
        _button.onClick.AddListener(CloseSettings);
        _sliderVolume.onValueChanged.AddListener(ChangeHorrorVolume);
    }

    private void ChangeHorrorVolume(float arg0)
    {
        _HorrorMusic.volume = _sliderVolume.value;
    }

    private void CloseSettings()
    {
        gameObject.GetComponent<Canvas>().enabled = false;
    }
}
