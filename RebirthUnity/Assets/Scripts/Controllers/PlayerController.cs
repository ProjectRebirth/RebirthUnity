using UnityEngine;
using System.Collections;


/**
 * This class handles any input that comes from the player.
 * All information that involves a key or button input
 * should be placed here!
 */ 
public class PlayerController : MonoBehaviour {

	private int currentForm;//This might help in order to (NOT USED NOW) 
	public GraysonMechanics player;//The character that the player is controlling
	public bool isRight;//The direction of the character sprite



	void Start() {
		if (!isRight) {
			this.transform.localScale = new Vector2 (-1, 1);
		}
	}

	/*
	 * Updates all actions that the player can currently act out
	 */ 
	void Update () {
		float horizontalInput = Input.GetAxis ("Horizontal");
		float verticalInput = Input.GetAxis ("Vertical");

		player.moveHorizontal (horizontalInput);
		player.moveVertical (verticalInput);
		player.jump (Input.GetButtonDown ("Jump"));
		player.fireWeapon (Input.GetKey(KeyCode.F));
		player.reloadWeapon (Input.GetKeyDown (KeyCode.R));
		checkFlipTexture ();
	}

	/**
	 * Method that helps to see if the character should flip
	 * orientation horizontally
	 */ 
	private void checkFlipTexture() {
		float horizontalInput = Input.GetAxis ("Horizontal");
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
