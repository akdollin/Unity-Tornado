using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	public int rotationSpeed = 5; //degrees per second

	// Use this for initialization
	void Start () {
	}

	void Update() {
		//rotate on y
		transform.Rotate( new Vector3(0, rotationSpeed, 0), Space.Self );
	}

}
