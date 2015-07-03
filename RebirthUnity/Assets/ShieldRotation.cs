using UnityEngine;
using System.Collections;

public class ShieldRotation : MonoBehaviour {
	public SpearmanMechanics mechanics;

	void Update() {
		Vector3 currentRotation = transform.eulerAngles;
		float x = currentRotation.x;
		float y = currentRotation.y;
		float zAngle = currentRotation.z;

		if (mechanics.getIsDefending ()) {
			float newZAngle = Mathf.MoveTowards (zAngle, 90, Time.deltaTime);
		} else {
			float newZAngle = Mathf.MoveTowards(zAngle, 0, Time.deltaTime);
		}
	}
}
