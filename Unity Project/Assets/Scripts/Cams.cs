using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cams : MonoBehaviour {

	public GameObject target;
	public GameObject parent;
	public int offset;
	// Use this for initialization
	void Start () {
		Vector3 pos = parent.transform.position;
		pos.y = pos.y - offset;

		transform.position = parent.transform.position;
		transform.LookAt(target.transform);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = parent.transform.position;
		pos.y = pos.y - offset;

		transform.position = pos;
		transform.LookAt(target.transform);

	}
}
