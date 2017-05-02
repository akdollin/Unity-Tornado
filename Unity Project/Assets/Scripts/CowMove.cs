using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowMove : MonoBehaviour {
	
	public GameObject barn;
	private float savedTime;

	// Use this for initialization
	void Start () {
		savedTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		//move in and out of barn while staying in rotation of barn
		if (Time.time - savedTime <= 5) {
			transform.Translate (Vector3.forward * Time.deltaTime*2, Space.Self);	
		} else if (Time.time - savedTime > 5 && Time.time - savedTime <= 10) {
			transform.Translate (Vector3.back * Time.deltaTime*2, Space.Self);	
		} else if (Time.time - savedTime > 12) {
			savedTime = Time.time;
		}
	}
}
