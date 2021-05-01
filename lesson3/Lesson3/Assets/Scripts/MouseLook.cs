using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Camera-Control/MouseLook")]
public class MouseLook : MonoBehaviour
{
    //���������� ������ ��� ��������� ���� ��������
    public enum RotationAxes {MouseX = 0, MouseY = 1};
    public RotationAxes axes = RotationAxes.MouseX;
    //���������������� ���� �� ��� �
    public float sensitivityX = 2f;
    public float sensitivityY = 2f;
    //������������ � ����������� ���� �������� �� ��� X
    public float minimumX = -360f;
    public float maximumX = 360f;
    //������������ � ����������� ���� �������� �� ��� Y
    public float minimumY = -360f;
    public float maximumY = 360f;
    //������� ���� ��������
    float rotationX = 0f;
    float rotationY = 0f;
    //��� ��������
    Quaternion originalRotation;
    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }
        originalRotation = transform.localRotation;
    }
    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360f) angle += 360f;
        if (angle > 360f) angle -= 360f;
        return Mathf.Clamp(angle, min, max);
    }

    // Update is called once per frame
    void Update()
    {
        if (axes == RotationAxes.MouseX)
        {
            rotationX += Input.GetAxis("Mouse X") * sensitivityX;
            rotationX = ClampAngle(rotationX, minimumX, maximumX);
            Quaternion xQuaterion = Quaternion.AngleAxis(rotationX, Vector3.up);
            transform.localRotation = originalRotation * xQuaterion;
        }
        else if (axes == RotationAxes.MouseY)
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = ClampAngle(rotationY, minimumY, maximumY);
            Quaternion yQuaterion = Quaternion.AngleAxis(-rotationY, Vector3.right);
            transform.localRotation = originalRotation * yQuaterion;
        }
    }
}
