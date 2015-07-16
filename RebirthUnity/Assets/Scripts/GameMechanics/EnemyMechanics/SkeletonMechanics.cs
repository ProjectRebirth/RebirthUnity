using UnityEngine;
using System.Collections;

public class SkeletonMechanics : TribeMechanics {
	private SkeletonStats skeletonStats;

	protected override void Start() {
		base.Start ();
		skeletonStats = (SkeletonStats)baseStats;
	}

	public bool getIsInvincible() {
		return skeletonStats.getIsInvincible ();
	}

	public void goInvincible(bool invincibleDown) {
		if (skeletonStats.canActivateInvincible ()) {
			skeletonStats.setIsInvincible(invincibleDown);
		}
	}



}
