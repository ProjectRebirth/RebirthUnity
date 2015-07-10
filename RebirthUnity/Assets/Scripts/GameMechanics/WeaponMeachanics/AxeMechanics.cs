using UnityEngine;
using System.Collections;

public class AxeMechanics : MeleeWeapon {

	public override void checkWeaponEnabled () {
		Collider2D axeCollider = GetComponent<Collider2D> ();
		if (tribeMechanics.getIsAttacking ()) {
			axeCollider.enabled = true;
		} else {
			axeCollider.enabled = false;
		}

	}
}
