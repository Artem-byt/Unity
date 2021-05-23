using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Buttons : MonoBehaviour
{
    [SerializeField]
    private Button _buttonStart;
    [SerializeField]
    private Button _buttonSettings;
    [SerializeField]
    private Button _buttonCancel;
    [SerializeField]
    private Canvas _settings;
    [SerializeField]
    private Slider _sliderValueAllMusic;
    [SerializeField]
    private AudioSource _horrorMusic;

    private void Awake()
    {
        _sliderValueAllMusic.value = _horrorMusic.volume; 
        _settings.enabled = false;

        _sliderValueAllMusic.onValueChanged.AddListener(VolumeChanged);
        _buttonStart.onClick.AddListener(Starter);
        _buttonSettings.onClick.AddListener(Setting);
        _buttonCancel.onClick.AddListener(Canceler);
    }

    private void VolumeChanged(float arg0)
    {
        _horrorMusic.volume = _sliderValueAllMusic.value;
    }

    private void OnDestroy()
    {
        _sliderValueAllMusic.onValueChanged.RemoveAllListeners();
        _buttonStart.onClick.RemoveAllListeners();
    }

    private void Starter()
    {
        SceneManager.LoadScene("Level_1");
    }

    private void Setting()
    {
        _settings.enabled = true;
    }

    private void Canceler()
    {
        _settings.enabled = false;
    }
}
