using UnityEngine;
using System.Collections;

public class SkeletonStats : BaseStats {
	public bool isInvincible;
	public float chanceReflect;
	public float invincibleCoolDown;
	private float invincibleCoolDownTimer;

	public override void takeDamage (float rawDamage) {

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
}
