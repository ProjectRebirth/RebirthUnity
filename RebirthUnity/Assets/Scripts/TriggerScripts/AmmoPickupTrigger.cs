using UnityEngine;
using System.Collections;

public class AmmoPickupTrigger : ActionTrigger {


	public override void activateTrigger ()
	{
		Collider2D collider = getCurrentCollider ();
		GraysonMechanics player = collider.GetComponent<GraysonMechanics>();
		player.getCurrentWeapon ().addCarriedAmmo (50);
		Destroy (transform.gameObject);
	}



}
