using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpRegulate : MonoBehaviour
{
    [SerializeField]
    private Slider _sliderHP;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<AmmoTurretDestroyer>() != null)
        {
            _sliderHP.value -= 0.1f;
        }
        if (_sliderHP.value <= 0)
        {
            Debug.Log("Поражение");
            Application.Quit();
        }
    }
}
