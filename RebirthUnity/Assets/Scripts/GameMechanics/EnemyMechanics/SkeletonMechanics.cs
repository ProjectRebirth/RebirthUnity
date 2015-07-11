using UnityEngine;
using System.Collections;

public class SkeletonMechanics : TribeMechanics {

	private SkeletonStats skeletonStats;
	public bool isInvincible;
	public float chanceReflection;//The likelihood that the skeleton will reflect a bullet that is being shot at him when invincible
	public float invincibleCoolDown;
	public string reflectTag;//The tag associated with items that are to be reflected by the skeleton
	private float invCoolDownTimer;
	private bool isFiring;


	protected override void Start() {
		base.Start ();
		skeletonStats = (SkeletonStats)baseStats;
	}

	protected override void Update() {
		base.Update ();
		invCoolDownTimer -= Time.deltaTime;
	}

	public void activateInvincible(bool invincibleDown) {
		if (canGoInvincible ()) {

		}
	}

	public void fireWeapon(bool fireDown) {
	
	}

	private bool canGoInvincible() {
		return invincibleCoolDown <= 0;
	}

	public bool getIsInvincible() {
		return isInvincible;
	}



	public bool getIsFiring() {
		return isFiring;
	}

	public void resetCoolDown() {
		invCoolDownTimer = invincibleCoolDown;
	}


	void OnTriggerEnter2D (Collider2D collider) {

	}
}
