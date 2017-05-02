using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour {

	public Camera cam1;
	public Camera cam2;
	public Camera cam3;
	public Camera cam4;

	public void camControl(int num) {
		Debug.Log (num);

		//chanage camera orientation
		if (num == 0) {
			defaultCam ();
		} else if (num == 1) {
			//car mode
			carCam();
		} else if (num == 2) {
			barnCam ();
		} else if (num == 3){
			sharkCam();
		}
	}
	void defaultCam() {
		cam1.enabled = true;
		cam2.enabled = false;
		cam3.enabled = false;
		cam4.enabled = false;
	}
	void carCam() {

		//enable the control panel
		GameObject controls = GameObject.FindWithTag("CarCam");
		//		Debug.Log ("hello************");
		foreach (Transform t in controls.transform) {
			foreach (Transform pan in t) {
				string panelName = "Camera Panel";
				//				Debug.Log ("***********:   " + pan.tag);
				if (pan.gameObject.tag == panelName) {
					pan.gameObject.SetActive (true);
				}
			}
		}

		cam1.enabled = false;
		cam2.enabled = true;
		cam3.enabled = false;
		cam4.enabled = false;
	}
	void barnCam() {
		cam1.enabled = false;
		cam2.enabled = false;
		cam3.enabled = true;
		cam4.enabled = false;
	}
	void sharkCam() {
		cam1.enabled = false;
		cam2.enabled = false;
		cam3.enabled = false;
		cam4.enabled = true;
	}
}