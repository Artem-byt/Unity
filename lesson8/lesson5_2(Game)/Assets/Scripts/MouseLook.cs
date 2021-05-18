using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Camera-Control/MouseLook")]
public class MouseLook : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    //Выпадающий список для настройки осей вращения
    [SerializeField]
    private enum RotationAxes {MouseX = 0, MouseY = 1};
    [SerializeField]
    private RotationAxes _axes = RotationAxes.MouseX;
    //Чувствительность мыши по оси Х
    [SerializeField]
    private float _sensitivityX = 2f;
    [SerializeField]
    private float _sensitivityY = 2f;
    //максимальный и минимальный углы вращения по оси X
    private float _minimumX = -360f;
    private float _maximumX = 360f;
    //максимальный и минимальный углы вращения по оси Y
    [SerializeField]
    private float _minimumY = -360f;
    [SerializeField]
    private float _maximumY = 360f;
    //текущий угол вращения
    private float _rotationX = 0f;
    private float _rotationY = 0f;
    //тип вращения
    private Quaternion _originalRotation;
    void Start()
    {
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }
        _originalRotation = transform.localRotation;
    }
    private static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360f) angle += 360f;
        if (angle > 360f) angle -= 360f;
        return Mathf.Clamp(angle, min, max);
    }

    void Update()
    {
        if (_axes == RotationAxes.MouseX)
        {
            _rotationX += Input.GetAxis("Mouse X") * _sensitivityX;
            _rotationX = ClampAngle(_rotationX, _minimumX, _maximumX);
            Quaternion xQuaterion = Quaternion.AngleAxis(_rotationX, Vector3.up);
            transform.localRotation = _originalRotation * xQuaterion;
        }
        else if (_axes == RotationAxes.MouseY)
        {
            _rotationY += Input.GetAxis("Mouse Y") * _sensitivityY;
            _rotationY = ClampAngle(_rotationY, _minimumY, _maximumY);
            Quaternion yQuaterion = Quaternion.AngleAxis(-_rotationY, Vector3.right);
            transform.localRotation = _originalRotation * yQuaterion;
        }
    }
}
