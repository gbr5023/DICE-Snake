using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour 
{
	private float speed = 20.0f;

	private float minFOV = 10f;
	private float maxFOV = 60f;

	private float sensFOV = 15f;

	public float minX = -360f;
	public float maxX = 360f;

	public float minY = -45f;
	public float maxY = 45f;

	public float sensX = 100f;
	public float sensY = 100f;

	float rotationY = 0f;
	float rotationX = 0f;

	void Update()
	{
		if(Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(new Vector3(speed * Time.deltaTime,0,0));
		}
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(new Vector3(-speed * Time.deltaTime,0,0));
		}
		if(Input.GetKey(KeyCode.DownArrow))
		{
			transform.Translate(new Vector3(0,-speed * Time.deltaTime,0));
		}
		if(Input.GetKey(KeyCode.UpArrow))
		{
			transform.Translate(new Vector3(0,speed * Time.deltaTime,0));
		}

		float fov = Camera.main.fieldOfView;

		fov += Input.GetAxis ("Mouse ScrollWheel") * sensFOV;
		fov = Mathf.Clamp (fov, minFOV, maxFOV);
		Camera.main.fieldOfView = fov;

		if (Input.GetMouseButton (0)) 
		{
			rotationX += Input.GetAxis ("Mouse X") * sensX * Time.deltaTime;
			rotationY += Input.GetAxis ("Mouse Y") * sensY * Time.deltaTime;
			rotationY = Mathf.Clamp (rotationY, minY, maxY);
			transform.localEulerAngles = new Vector3 (-rotationY, rotationX, 0);
		}
	}
}
