using UnityEngine;
using System.Collections;

public class AmmoPickupTrigger : ActionTrigger {


	public override void activateTrigger ()
	{
		GraysonMechanics player = getPlayerMechanics ();
		player.getCurrentWeapon ().addCarriedAmmo (50);
		Destroy (transform.gameObject);
	}



}
