using UnityEngine;
using System.Collections;

/**
 *This class is referring to the spear weapon and not the spearman. Just to clear things up for later
 *on in the future...
 */
public class SpearMechanics : MeleeWeapon {

	public override void checkWeaponEnabled () {
		Collider2D weaponCollider = GetComponent<Collider2D> ();
		if (tribeMechanics.getIsRunning ()) {
			weaponCollider.enabled = true;
		} else {
			weaponCollider.enabled = false;
		}
	}
}
