using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deselect : MonoBehaviour {
	public void OnClick() {
		Debug.Log ("***********8Hello");
		GameObject temp = GameObject.FindWithTag("Tornado Parent");
		Debug.Log (temp);

		//first reenable the scripts of the selected
		foreach (Component component in temp.GetComponentsInChildren(typeof(Component))) {
			SetComponentEnabled (component, true);
		}

		//called iterator
		iterateChildren (temp.transform);
		Debug.Log("After");

		//disable control panel
		GameObject controls = GameObject.FindWithTag("Controls");
		foreach (Transform t in controls.transform) {
			foreach (Transform pan in t) {
				pan.gameObject.SetActive (false);
			}
		}

	}

	void iterateChildren(Transform t)
	{
		Debug.Log("Here Now " + t);

		//unselection
		if (t.tag == "Select") {
			t.gameObject.SetActive (false);
		}

		if(t.childCount == 0) return;

		foreach(Transform tran in t)
		{
			Debug.Log("Here");
			iterateChildren(tran);
		}
	}

	void SetComponentEnabled(Component component, bool value) {
		if (component == null) return;

		if (component is MonoBehaviour) {
			(component as MonoBehaviour).enabled = value;
		} 
	}
}
