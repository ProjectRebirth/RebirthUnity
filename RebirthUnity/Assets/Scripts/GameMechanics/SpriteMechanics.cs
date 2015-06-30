using UnityEngine;
using System.Collections;

public class SpriteMechanics : MonoBehaviour {
	public bool isRight;
	private bool inAir;
	private bool madeJump;
	private bool isRunning;
	public float speed;//The speed that the sprite will be moving from side to side
	public float horiztonalMomentum;//The higher the number, the faster the sprite will come to a stop
	private bool isHit;

	public SpriteStats spriteStats;

	protected virtual void Update() {
		checkIsHit ();
		isDeadCleanup ();
		inAir = checkInAir ();
		isRunning = checkIsRunning ();

	}



	protected virtual void Start() {
		if (!isRight) {//This if statement flips the texture of the sprite upon creation if the 
			//designer so chooses to start a character in the left position
			this.transform.localScale = new Vector2 (-1, 1);
		}
		//health = maxHealth;
	}

	/**
	 * If the player is moving horizontally, then they are considered to be
	 * running according to this logic. Could use a better implementation,
	 * but for what is needed it seems to be working fine
	 */ 
	public bool checkIsRunning() {
		Rigidbody2D rigid = GetComponent<Rigidbody2D> ();
		float x = rigid.velocity.x;
		return Mathf.Abs (x) > 0f;
	}

	public void checkIsHit () {
		if (!inAir && isHit) {
			isHit = false;
		}
	}

	public void moveHorizontal(float horizontalInput) {
		checkFlipTexture (horizontalInput);
		Rigidbody2D rigid = GetComponent<Rigidbody2D> ();
		float x = speed * horizontalInput;
		if (isHit) {
			x = rigid.velocity.x;
		}
		Vector3 vec = new Vector3 (x, rigid.velocity.y, 0);
		rigid.velocity = vec;

	}

	public virtual void moveVertical(float verticalInput) {

	}

	private float smoothMovement(float currentVelocity, float goalVelocity) {
		float newVelocity = goalVelocity;
		if (goalVelocity < currentVelocity) {
			newVelocity = currentVelocity - (horiztonalMomentum * Time.deltaTime);
			if (newVelocity < goalVelocity) {
				newVelocity = goalVelocity;
			}
		}

		if (goalVelocity > currentVelocity) {
			newVelocity = currentVelocity + (horiztonalMomentum * Time.deltaTime);
			if (newVelocity > goalVelocity) {
				newVelocity = goalVelocity;
			}
		}
		return newVelocity;
	}

	/**
	 * Method that helps to see if the character should flip
	 * orientation horizontally
	 */ 
	private void checkFlipTexture(float horizontalInput) {
		if (true) {//!madeJump && !Input.GetKey(KeyCode.F)
			if (isRight && horizontalInput < 0) {
				isRight = false;
				transform.localScale = new Vector2 (-1, 1);
			}
			if (!isRight && horizontalInput > 0) {
				transform.localScale = new Vector2 (1, 1);
				isRight = true;
			}
		}
		
	}



	/***************Getters Go Here************/

	//Returns the speed of the player
	public float getSpeed() {
		return speed;
	}

	//Returns the direction that the player is facing
	public bool getIsRight() {
		return isRight;
	}

	//Lets you know whether or not the player is free falling
	public bool getInAir() {
		return inAir;
	}

	//Checks if the player made a valid jump. If false they either fell or are on the ground
	public bool getMadeJump() {
		return madeJump;
	}

	//Variable that lets you know that the player is moving horizontally.
	//......Maybe the name should be changed in a future update.
	public bool getIsRunning() {
		return isRunning;
	}

	public bool getIsHit() {
		return isHit;
	}

	

	/******Setters Go Here***************/
	public void setIsRunning(bool isRunning) {
		this.isRunning = isRunning;
	}

	public void setMadeJump(bool madeJump) {
		this.madeJump = madeJump;
	}

	public void setIsRight(bool isRight) {
		this.isRight = isRight;
	}

	public void setInAir(bool inAir) {
		this.inAir = inAir;
		if (!inAir) {
			this.madeJump = false;
		}
	}

	public void setIsHit(bool isHit) {
		this.isHit = isHit;
	}

	protected virtual void isDeadCleanup() {
		if (spriteStats.getIsDead()) {
			Collider2D collider = GetComponent<Collider2D> ();
			Rigidbody2D rigid = GetComponent<Rigidbody2D>();
			rigid.velocity = new Vector2();
			rigid.gravityScale = 0;
			Destroy (collider);
		}
	}
	

	/**
	 * If the player is moving vertically then the player is considered in the air.
	 * May not be the best implementation, but its worked so far, so.... yeah...
	 */
	public bool checkInAir() {
		Rigidbody2D rigid = GetComponent<Rigidbody2D> ();
		
		return (Mathf.Abs (rigid.velocity.y) > 0.0001f && madeJump) || Mathf.Abs (rigid.velocity.y) > .05; 
	}

}
