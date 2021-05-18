using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivationGame : MonoBehaviour
{
    [SerializeField]
    private PersonMove _banditMove;
    [SerializeField]
    private MouseLook _banditLook;
    [SerializeField]
    private GranadeThrow _banditGranade;
    [SerializeField]
    private Button _button;
    [SerializeField]
    private Button _buttonSettings;
    [SerializeField]
    private Canvas _gameInterface;
    [SerializeField]
    private Canvas _menuSettings;
    private void Awake()
    {
        gameObject.SetActive(true);
        _banditMove.enabled = false;
        _banditLook.enabled = false;
        _banditGranade.enabled = false;
        _gameInterface.enabled = false;
        _menuSettings.enabled = false;
        _button.onClick.AddListener(ActivateGame);
        _buttonSettings.onClick.AddListener(ActivateSettings);
        Time.timeScale = 0;
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveAllListeners();
    }
    private void ActivateGame()
    {
        Time.timeScale = 1;
        _banditMove.enabled = true;
        _banditLook.enabled = true;
        _banditGranade.enabled = true;
        _gameInterface.enabled = true;
        Destroy(gameObject);
    }

    private void ActivateSettings()
    {
        _menuSettings.enabled = true;
    }
}
