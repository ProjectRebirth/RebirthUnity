using UnityEngine;
using System.Collections;


/*
 * This script is used for all of Grayson's mechanics
 * 
 */ 
public class GraysonMechanics : MonoBehaviour {
	public float speed;//The speed that Grayson will be moving from side to side
	public float jumpSpeed;//The height of that Grayson will jump
	public Transform torso;
	public Transform legs;


	private bool inAir;
	private bool isRunning;
	private bool canFire;
	private bool canReload;
	private bool isReloading;
	private bool isFiring;



	void Update() {
		inAir = checkInAir ();
		isRunning = checkISRunning ();

		isFiring = checkIsFiring();
		isReloading = checkIsReloading ();

		//print ("Can Reload: " + canReload);
	}


	/*
	 * Logic for moving forward based on inputs from the player
	 */ 
	public void moveHorizontal(float horizontalInput) {
		Rigidbody2D rigid = GetComponent<Rigidbody2D>();
		Vector2 vec = new Vector2 (speed * horizontalInput, rigid.velocity.y);
		rigid.velocity = vec;
	}

	/*
	 * Logic for the jump mechanic. If his z velocity is 0 then he can jump
	 */ 
	public void jump(bool jumpKey) {
		Rigidbody2D rigid = GetComponent<Rigidbody2D> ();

		if (Mathf.Abs(rigid.velocity.y) == 0 && jumpKey) {
			Vector2 vec = new Vector2 (rigid.velocity.x, jumpSpeed);
			rigid.velocity = vec;
		}
	}

	public void fireWeapon(bool fireButton) {
		if (checkCanFire ()) {
			canFire = fireButton;
		} else {
			canFire = false;
		}
	}

	public void reloadWeapon(bool reloadButton) {
		if (checkCanReload ()) {
			canReload = reloadButton;

			//print (reloadButton);
		} else {
			canReload = false;
		}
	}

	private bool checkInAir() {
		Rigidbody2D rigid = GetComponent<Rigidbody2D> ();

		return Mathf.Abs (rigid.velocity.y) > 0f; 
	}

	private bool checkISRunning() {
		Rigidbody2D rigid = GetComponent<Rigidbody2D> ();
		float x = rigid.velocity.x;
		return Mathf.Abs (x) > 0f;
	}

	private bool checkCanReload() {
		return !isReloading;
	}

	private bool checkCanFire() {
		return !isReloading && !isFiring;
	}

	private bool checkIsReloading() {
		Animator torsoAnimator = torso.GetComponent<Animator> ();
		AnimatorStateInfo currentClip = torsoAnimator.GetCurrentAnimatorStateInfo (0);
		if (currentClip.IsName("Reload_Torso")) {
			return true;
		}
		return false;
	}

	private bool checkIsFiring() {
		Animator torsoAnimator = torso.GetComponent<Animator> ();
		AnimatorStateInfo currentState = torsoAnimator.GetCurrentAnimatorStateInfo (0);
		if (currentState.IsName ("Fire_Torso")) {
			return true;
		}
		return false;
	}

	public bool getCanReload() {
		return canReload;
	}

	public bool getCanFire() {
		return canFire;
	}

	public bool getIsRunning() {
		return isRunning;
	}

	public bool getInAir() {
		return inAir;
	}
}
