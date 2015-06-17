using UnityEngine;
using System.Collections;

public class ArcherMechanics : TribeMechanics {
	private float coolDownTimer;
	public float fireCoolDown;
	public BulletMechanics tribeArrow;
	public Transform archerBow;
	private bool awaitingFire;


	protected override void Update() {
		checkFirePorjectile ();
		base.Update ();
		coolDownTimer -= Time.deltaTime;
		if (coolDownTimer < 0) {
			coolDownTimer = 0;
		}


	}



	void checkFirePorjectile() {
		Animator animator = GetComponent<Animator> ();
		AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo (0);
		if(getCanAttack()) {
			awaitingFire = true;
		}
		if (getIsAttacking() && stateInfo.normalizedTime > .8 && awaitingFire) {
			GameObject obj = (GameObject)Instantiate(tribeArrow.gameObject, 
			                                                               archerBow.position, new Quaternion());
			BulletMechanics bulletMechanics = obj.GetComponent<BulletMechanics>();
			if (getIsRight()) {
				bulletMechanics.setDirection(new Vector2(1, 0));
			}else {
				bulletMechanics.setDirection(new Vector2(-1, 0));
				bulletMechanics.transform.localScale = new Vector2(-1, 1);
			}
			coolDownTimer = fireCoolDown;
			awaitingFire = false;
		}
	}

	protected override bool checkCanAttack() {
		return !getIsAttacking () && coolDownTimer <= 0;
	}

}
