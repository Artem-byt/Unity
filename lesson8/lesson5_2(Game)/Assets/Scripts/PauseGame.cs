using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    private bool _isPauseActive;

    [SerializeField]
    private Camera _mainCamera;
    [SerializeField]
    private Button _button;
    [SerializeField]
    private Canvas _pauseMenu;


    private void Awake()
    {
        _isPauseActive = false;
        _pauseMenu.enabled = false;
        _button.onClick.AddListener(Pause);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_isPauseActive)
        {
            _pauseMenu.enabled = true;
            Time.timeScale = 0;
            _isPauseActive = true;
            Enabling(false);
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && _isPauseActive)
        {
            _pauseMenu.enabled = false;
            Time.timeScale = 1;
            _isPauseActive = false;
            Enabling(true);
        }
    }
    private void OnDestroy()
    {
        _button.onClick.RemoveAllListeners();
    }

    private void Pause()
    {
        _pauseMenu.enabled = false;
        Time.timeScale = 1;
        _isPauseActive = false;

        Enabling(true);
    }

    private void Enabling(bool value)
    {
        gameObject.GetComponent<PersonMove>().enabled = value;
        gameObject.GetComponent<MouseLook>().enabled = value;
        gameObject.GetComponent<GranadeThrow>().enabled = value;
        _mainCamera.GetComponent<MouseLook>().enabled = value;
    }
}
