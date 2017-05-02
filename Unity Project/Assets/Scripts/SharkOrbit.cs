using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkOrbit : MonoBehaviour {

	public float rotationSpeed = 75.0f; //degrees per second

	// Use this for initialization
	void Start () {
	}
		
	void Update() {
		//orbit tornado
		transform.RotateAround(transform.parent.position, Vector3.up, rotationSpeed * Time.deltaTime);

	}
}
	