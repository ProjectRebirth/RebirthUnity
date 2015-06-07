using UnityEngine;
using System.Collections;

public abstract class ActionTrigger : MonoBehaviour {
	private GraysonMechanics grayson;

	public abstract void activateTrigger();

	public GraysonMechanics getPlayerMechanics() {
		return grayson;
	}


	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.transform.tag == "Grayson") {
			grayson = collider.GetComponent<GraysonMechanics>();
			activateTrigger ();
		}
	}

	void OnTriggerExit2D(Collider2D collider) {
		if (collider.transform.tag == "Grayson") {
			grayson = null;
		}
	}



}
