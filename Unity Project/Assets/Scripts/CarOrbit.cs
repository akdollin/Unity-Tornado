using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarOrbit : MonoBehaviour {

	public float rotationSpeed = 75.0f; //degrees per second
	public int direction = 1;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
//		offset = transform.position - stationaryObject.transform.position;
	}

	void Update() {
		//orbit tornado
		transform.RotateAround(transform.parent.position, Vector3.up, (rotationSpeed * Time.deltaTime)*direction);
	}
}
