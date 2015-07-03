using UnityEngine;
using System.Collections;

public class ShieldRotation : MonoBehaviour {
	public SpearmanMechanics mechanics;

	void Update() {
		adjustShieldLayer ();
		adjustShieldRotation ();
	}

	private void adjustShieldRotation() {
		float newZAngle = 0;
		if (mechanics.getIsDefending ()) {
			newZAngle = 90;
		} else {
			newZAngle = 0;
		}
		Quaternion goalAngle = Quaternion.Euler (0, 0, newZAngle);
		Quaternion initAngle = transform.rotation;
		Quaternion finalAngle = Quaternion.Slerp (initAngle, goalAngle, Time.deltaTime);

		transform.rotation = finalAngle;
	}

	private void adjustShieldLayer() {
		SpriteRenderer render = GetComponent<SpriteRenderer> ();
		print (mechanics.getIsRight ());
		if (mechanics.isRight) {
			render.sortingOrder = 3;
		} else {
			render.sortingOrder = 5;
		}
	}
}
