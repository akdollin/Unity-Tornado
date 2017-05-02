using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkOsc : MonoBehaviour {

	public float amp = 5.0f;
	public float ome = 2.0f;

	float index;

	public void Update()
	{
		index += Time.deltaTime;
		float y = amp*Mathf.Sin (ome*index);
		transform.localPosition = new Vector3(transform.localPosition.x,y,transform.localPosition.z);
	}
}
