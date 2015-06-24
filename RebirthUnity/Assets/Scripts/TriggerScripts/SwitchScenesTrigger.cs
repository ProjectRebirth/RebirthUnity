using UnityEngine;
using System.Collections;

public class SwitchScenesTrigger : ActionTrigger {

	public string nextScene;
	private GraysonMechanics grayson;

	public override void activateTrigger() {
		Collider2D collider = getCurrentCollider ();
		grayson = collider.GetComponent<GraysonMechanics> ();
	}


	void Update() {

		if (getTriggerEntered()) {
			if (grayson.getIsLookingUp()) {
				Application.LoadLevel(nextScene);
			}
		}
	}

}
