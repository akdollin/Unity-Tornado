using UnityEngine;
using System.Collections;

public class Select: MonoBehaviour {
	private GameObject Object;
	private string selectedObjectTag = "temp";
	private GameObject hoveredObject;

	private Material savedMaterial;
	private bool moving;
	private Vector3 moveTowards;
	private bool killHouse;

	void Update(){
		if (moving) {
			MoveTornado ();				
		}
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast (ray, out hit)) {
//			Debug.Log ("Hovering On: " + hit.collider.name);

			if (hit.collider.tag == "Car" ||
			    hit.collider.tag == "Barn" ||
			    hit.collider.tag == "Shark") {

				if (Input.GetMouseButtonDown (0)) {
//					Debug.Log ("Selected " + hit.collider.name);
					SelectObject (hit.collider, hit.collider.tag);
				}
			}
			if (hit.collider.tag == "House") {
				if (Input.GetMouseButtonDown (0)) 
				{
//					Debug.Log("Destroy: " + hit.point);
					moving = true;
					killHouse = true;
					moveTowards = hit.point;
				}
			}
			if (hit.collider.tag == "Tornado") {
				if (Input.GetMouseButtonDown (0)) 
				{
//					Debug.Log("Destroy: " + hit.point);
					SelectObject (hit.collider, "Tornado Parent");
					StopAll ();
				}
			}
			if (hit.collider.tag == "Ground") {
				if (Input.GetMouseButtonDown (0)) 
				{
//					Debug.Log("Moving to: " + hit.point);
					moving = true;
					moveTowards = hit.point;
				}
			}
		}
	}

	void destroyHouse() {
//		GameObject temp = GameObject.FindWithTag("House");
		GameObject.FindWithTag("House").SetActive (false);
	}

	void MoveTornado() {
			
		GameObject temp = GameObject.FindWithTag("Tornado Parent");

		if (temp.transform.position == moveTowards) {
			if (killHouse) {
				destroyHouse ();
				killHouse = false;
			}
			moving = false;
		} else {
			float step = 10 * Time.deltaTime;
			moveTowards.y = temp.transform.position.y;
			temp.transform.position = Vector3.MoveTowards (temp.transform.position, moveTowards, step);	
		}
	}

	void StopAll() {
		GameObject temp = GameObject.FindWithTag("Tornado Parent");
		//stop rotation
		foreach (Component component in temp.GetComponentsInChildren(typeof(Component))) {
			SetComponentEnabled (component, false);
		}
	}

	void SelectObject(Collider other, string tag) {
		GameObject temp = GameObject.FindWithTag(tag);

		//check if there is something selected
		if (selectedObjectTag != tag && selectedObjectTag != "temp") {
			GameObject unselect = GameObject.FindWithTag(selectedObjectTag);
			foreach (Component component in unselect.GetComponentsInChildren(typeof(Component))) {
					SetComponentEnabled (component, true);
			}
			diselect (selectedObjectTag);
		}
		//stop rotation
		foreach (Component component in temp.GetComponentsInChildren(typeof(Component))) {
			SetComponentEnabled (component, false);
		}
		//enable the selection plane
		foreach (Transform t in temp.transform) {
			if (t.tag == "Select") {
				t.gameObject.SetActive (true);
			}
		}

		//enable the control panel
		GameObject controls = GameObject.FindWithTag("Controls");
//		Debug.Log ("hello************");
		foreach (Transform t in controls.transform) {
			foreach (Transform pan in t) {
				string panelName = other.tag + " " + "Panel";
//				Debug.Log ("***********:   " + pan.tag);
				if (pan.gameObject.tag == panelName) {
					pan.gameObject.SetActive (true);
				}
			}
		}

		selectedObjectTag = tag;
	}

	void diselect(string tag) {
		GameObject temp = GameObject.FindWithTag(tag);
		//disable the selection plane
		foreach (Transform t in temp.transform) {
			if (t.tag == "Select") {
				t.gameObject.SetActive (false);
			}
		}

		//disable control panel
		GameObject controls = GameObject.FindWithTag("Controls");
		foreach (Transform t in controls.transform) {
			foreach (Transform pan in t) {
				pan.gameObject.SetActive (false);
			}
		}

//		//disable control panel
//		GameObject controls = GameObject.FindWithTag("Controls");
//		foreach (Transform t in controls.transform) {
//			foreach (Transform pan in t) {
//				string panelName = tag + " " + "Panel";
//				Debug.Log (panelName);
////				if (t.gameObject.tag == panelName) {
////					t.gameObject.SetActive (false);
////				}
//			}
//		}
	}

	void SetComponentEnabled(Component component, bool value) {
		if (component == null) return;

		if (component is MonoBehaviour) {
			(component as MonoBehaviour).enabled = value;
		} 
	}
}
