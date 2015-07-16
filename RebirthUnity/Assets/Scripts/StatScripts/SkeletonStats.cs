using UnityEngine;
using System.Collections;

public class SkeletonStats : BaseStats {
	private bool isInvincible;
	public float chanceReflect;
	public float invincibleCoolDown;
	private float invincibleCoolDownTimer;
	private bool isFiring;

	public override void takeDamage (float rawDamage) {
		base.takeDamage (rawDamage);
	}

	protected override void Update() {
		base.Update ();
		invincibleCoolDownTimer -= Time.deltaTime;
		if (invincibleCoolDownTimer < 0f) {
			invincibleCoolDownTimer = 0f;
		}
	}

	public float getInvincibleTimer() {
		return invincibleCoolDownTimer;
	}

	public bool canActivateInvincible() {
		return invincibleCoolDownTimer <= 0f;
	}

	public bool getIsInvincible() {
		return isInvincible;
	}

	public void setIsInvincible(bool isInvinicible) {
		this.isInvincible = isInvincible;
	}

	public void setIsFiring(bool isFiring) {
		this.isFiring = isFiring;
	}


	public bool getIsFiring() {
		return isFiring;
	}
}
