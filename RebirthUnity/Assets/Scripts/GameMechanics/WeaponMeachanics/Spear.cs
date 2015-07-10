using UnityEngine;
using System.Collections;

public class Spear : MonoBehaviour {
	public SpearmanMechanics spearmanMechanics;


	void Update() {
		Collider2D collider = GetComponent<Collider2D> ();
		if (spearmanMechanics.getIsRunning ()) {
			collider.enabled = true;
		} else {
			collider.enabled = false;
		}
	}
}
