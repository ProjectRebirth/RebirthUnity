using UnityEngine;
using System.Collections;

public class BatMechanics : TribeMechanics {
	public float verticalSpeed;
	public string deathAnimation;
	public float fireCoolDown;
	private float coolDownTimer;
	public GameObject projectile;


	protected override void Update() {
		coolDownTimer -= Time.deltaTime;
		if (coolDownTimer < 0) {
			coolDownTimer = 0;
		}
		checkFireProjectile ();
		base.Update ();
	

	}

	void checkFireProjectile() {
		if (getCanAttack ()) {
			coolDownTimer = fireCoolDown;
			GameObject obj = (GameObject)Instantiate(projectile, transform.position, new Quaternion());
			BulletMechanics mech = obj.GetComponent<BulletMechanics>();
			if(getIsRight()) {
				mech.setDirection(new Vector2(Mathf.Sqrt(2), -Mathf.Sqrt(2)));
			}
			else {
				mech.setDirection(new Vector2(-Mathf.Sqrt(2), -Mathf.Sqrt(2)));
			}
			
		}
	}


	protected override void isDeadCleanup() {
		Animator animator = getAnimator ();
		if (spriteStats.getIsDead()) {
			Rigidbody2D rigid = GetComponent<Rigidbody2D>();
			rigid.gravityScale = 1;
			AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

			if (getInAir() && stateInfo.IsName(deathAnimation) && stateInfo.normalizedTime > .05){
				animator.enabled = false;
			}
			else animator.enabled = true;
		}
	}


	protected override bool checkCanAttack() {
		return !getIsAttacking () && coolDownTimer <= 0 && !getCanAttack ();
	}

	public override void moveVertical(float verticalInput) {
		Rigidbody2D rigid = GetComponent<Rigidbody2D> ();
		float x = rigid.velocity.x;
		float y = verticalInput * verticalSpeed;
		if (!spriteStats.getIsDead()) {
			rigid.velocity = new Vector2 (x, y);
		}
	}
}
