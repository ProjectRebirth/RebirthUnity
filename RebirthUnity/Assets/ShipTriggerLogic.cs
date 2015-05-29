using UnityEngine;
using System.Collections;

/**
 * This is a test class to activate a way to get to a new scene when an area is reached.
 * 
 * Right now
 */ 
public class ShipTriggerLogic : MonoBehaviour {
	GameObject sign;
	public GameObject test;
	private bool active;

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Grayson" && !active) {
			float x = transform.localPosition.x;
			float y = transform.localPosition.y + 2;
			float z = transform.localPosition.z;

			sign = (GameObject) Instantiate(test, new Vector3(x, y, z), new Quaternion());
			active = true;
		}
	}

	void OnTriggerExit2D(Collider2D collider) {
		if (collider.tag == "Grayson") {
			Destroy (sign);
			active = false;
		}
	}
}
