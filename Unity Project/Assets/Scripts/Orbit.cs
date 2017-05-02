using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {

	public int rotationSpeed = 5; //degrees per second

	// Use this for initialization
	void Start () {
	}

	void Update() {
		transform.RotateAround(Vector3.zero, Vector3.up, rotationSpeed * Time.deltaTime);
	}
}
