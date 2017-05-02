using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanels : MonoBehaviour {
	public GameObject barn;
	public GameObject tornado;
	public GameObject car;
	public GameObject shark;

	private CarOrbit carOrbit;
	private BarnOrbit barnOrbit;
	private BarnRotate barnRotate;
	private SharkOrbit sharkOrbit;
	private SharkOsc sharkOsc;

	public void BarnOrbitControl(float num) {
		barnOrbit = (BarnOrbit) FindObjectOfType(typeof(BarnOrbit));
		barnOrbit.rotationSpeed = (int) num;
	}
	public void BarnRotateControl(float num) {
		barnRotate = (BarnRotate) FindObjectOfType(typeof(BarnRotate));
		barnRotate.rotationSpeed = (int) num;
	}
	public void CarSpeedControl(float num) {
		carOrbit = (CarOrbit) FindObjectOfType(typeof(CarOrbit));
		carOrbit.rotationSpeed = (int) num;
	}
	public void CarDirectControl() {
		carOrbit = (CarOrbit) FindObjectOfType(typeof(CarOrbit));
		int direct = carOrbit.direction;

		if (direct == -1) {
			//set direction to 1
			carOrbit.direction = 1;
		} else if (direct == 1) {
			//set direction to -1
			carOrbit.direction = -1;
		}
		var rotationVector = car.transform.rotation.eulerAngles;
		rotationVector.y = rotationVector.y - 185;
		car.transform.rotation = Quaternion.Euler(rotationVector);
	}
	public void TornadoControlUp() {
		GameObject game = GameObject.FindWithTag("Tornado");
		if (game.transform.localScale.x < 5) {
			game.transform.localScale += new Vector3(0.3F, 0.3f, 0.3f);

//			game.transform.localScale.x += .3f; 
//			game.transform.localScale.y += .3f;
//			game.transform.localScale.z += .3f;
		}
	}

	public void TornadoControlDown() {
		GameObject game = GameObject.FindWithTag("Tornado");
		if (game.transform.localScale.x < 5) {
			game.transform.localScale -= new Vector3(0.3F, 0.3f, 0.3f);

//			game.transform.localScale.x -= .3f; 
//			game.transform.localScale.y -= .3f;
//			game.transform.localScale.z -= .3f;
		}
	}

	public void SharkSpeedControl(float num) {
		sharkOsc = (SharkOsc) FindObjectOfType(typeof(SharkOsc));
		sharkOsc.ome = num;
	}
	public void SharkOrbitControl(float num) {
		sharkOrbit = (SharkOrbit) FindObjectOfType(typeof(SharkOrbit));
		sharkOrbit.rotationSpeed = (int) num;
	}	
	public void SharkRangeControl(float num) {
		sharkOsc = (SharkOsc) FindObjectOfType(typeof(SharkOsc));
		sharkOsc.amp = num;
	}
	public void up() {
		Camera temp = Camera.main;
		temp.transform.Rotate(new Vector3(-2,0,0)); 
	}
	public void down() {
		Camera temp = Camera.main;
		temp.transform.Rotate(new Vector3(2,0,0)); 
	}
	public void left() {
		Camera temp = Camera.main;
		temp.transform.Rotate(new Vector3(0,-2,0)); 
	}
	public void right() {
		Camera temp = Camera.main;
		temp.transform.Rotate(new Vector3(0,2,0)); 
	}
}
