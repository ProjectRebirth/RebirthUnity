using UnityEngine;
using System.Collections;

public class SkeletonMechanics : TribeMechanics {

	private bool isInvincible;
	private bool isFiring;
	public float invincibleCoolDown;



	public void activateInvincible() {
		if (canGoInvincible ()) {

		}
	}


	private bool canGoInvincible() {
		return invincibleCoolDown <= 0;
	}

	protected override void Update() {
		base.Update ();
		invincibleCoolDown -= Time.deltaTime;
	}

	public bool getIsInvincible() {
		return isInvincible;
	}



	public bool getIsFiring() {
		return isFiring;
	}

}
