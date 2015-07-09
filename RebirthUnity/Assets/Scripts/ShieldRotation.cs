using UnityEngine;
using System.Collections;

public class ShieldRotation : MonoBehaviour {
	public SpearmanStats spearmanStats;
	public TribeMechanics mechanics;
	public float rotationSpeed;

	void Update() {
		adjustShieldLayer ();
		adjustShieldRotation ();
	}

	private void adjustShieldRotation() {
		float newZAngle = 0;
		if (spearmanStats.getIsDefending ()) {
			newZAngle = 90;
		} else {
			newZAngle = 0;
		}
		Quaternion goalAngle = Quaternion.Euler (0, 0, newZAngle);
		Quaternion initAngle = transform.rotation;
		Quaternion finalAngle = Quaternion.Slerp (initAngle, goalAngle, rotationSpeed * Time.deltaTime);

		transform.rotation = finalAngle;
	}

	private void adjustShieldLayer() {
		SpriteRenderer render = GetComponent<SpriteRenderer> ();
		if (mechanics.isRight) {
			render.sortingOrder = 3;
		} else {
			render.sortingOrder = 5;
		}
	}
}
