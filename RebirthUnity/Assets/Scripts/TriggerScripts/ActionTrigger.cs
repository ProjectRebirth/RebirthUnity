using UnityEngine;
using System.Collections;

public abstract class ActionTrigger : MonoBehaviour {
	public string triggerTag;
	private Collider2D triggeredCollider;
	private bool triggerEntered;

	public abstract void activateTrigger();

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == triggerTag) {
			triggeredCollider = collider;
			triggerEntered = true;
			activateTrigger ();
		}
	}
	
	void OnTriggerExit2D (Collider2D collider) {
		if (collider.tag == triggerTag) {
			triggeredCollider = null;
			triggerEntered = false;

		}
	}

	public bool getTriggerEntered(){
		return triggerEntered;
	}

	public Collider2D getCurrentCollider() {
		return triggeredCollider;
	}
}
