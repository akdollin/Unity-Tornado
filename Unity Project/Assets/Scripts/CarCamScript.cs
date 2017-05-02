using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCamScript : MonoBehaviour {
	public GameObject car;
	private Vector3 offset;
	float yRotation; 
	float xRotation;

	void Start () {
		Input.gyro.enabled = true; 
	}

	// Update is called once per frame
	void Update () {
		yRotation += -Input.gyro.rotationRateUnbiased.y; 
		xRotation += -Input.gyro.rotationRateUnbiased.x;

		transform.eulerAngles = new Vector3(xRotation, yRotation, 0); 	
	}
}
