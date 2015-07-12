using UnityEngine;
using System.Collections;

public class SkeletonInsignia : MonoBehaviour {

	public SkeletonMechanics skeletonMechanics;
	public BaseStats skeletonStats;
	public Animator animator;

	// Update is called once per frame
	void Update () {
		animator.SetBool ("isInvincible", skeletonMechanics.getIsInvincible ());
		animator.SetBool ("isDead", skeletonStats.getIsDead ());
	}

}
