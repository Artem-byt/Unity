/// <summary>
/// Camera move.
/// Create by Sky Games
/// </summary>
using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	[SerializeField]
	private GameObject _player;
	[SerializeField]
	private float _speedCam = 15;
	[SerializeField]
	private float _speedScroll = 15;
	[SerializeField]
	private float _minDistance;
	[SerializeField]
	private float _maxDistance;
	
	private float _distance;
	private float _x;
	private float _y;
	
	void LateUpdate () {
		
		// Получение значения сдвига мыши
		_x = Input.GetAxis("Mouse X")*_speedCam*10;
		_y = Input.GetAxis("Mouse Y")*-_speedCam*10;
		
		// Вращение

		transform.RotateAround(_player.transform.position, transform.up, _x*Time.deltaTime);
		transform.RotateAround(_player.transform.position, transform.right, _y*Time.deltaTime);
			
		transform.localRotation = Quaternion.LookRotation(_player.transform.position - transform.position);
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
		
		// Приближение/удаление
		if(Input.GetAxis("Mouse ScrollWheel") != 0)
		{
			_distance = Vector3.Distance(transform.position, _player.transform.position);
			if(Input.GetAxis("Mouse ScrollWheel") > 0 && _distance > _minDistance)
			{
				transform.Translate(Vector3.forward * Time.deltaTime * _speedScroll);
			}
			
			if(Input.GetAxis("Mouse ScrollWheel") < 0 && _distance < _maxDistance)
			{
				transform.Translate(Vector3.forward * Time.deltaTime * -_speedScroll);	
			}
		}
	}
}
