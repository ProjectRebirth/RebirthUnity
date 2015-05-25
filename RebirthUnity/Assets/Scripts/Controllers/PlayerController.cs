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


	/*
	 * Updates all actions that the player can currently act out and control
	 */ 
	void Update () {
		float horizontalInput = Input.GetAxis ("Horizontal");


		player.moveHorizontal (horizontalInput);

		player.strafe (Input.GetKeyDown(KeyCode.LeftControl));
		player.jump (Input.GetButtonDown ("Jump"));

		player.fireWeapon (Input.GetKey(KeyCode.F));
		player.reloadWeapon (Input.GetKeyDown (KeyCode.R));

	}

	void FixedUpdate() {
		float verticalInput = Input.GetAxis ("Vertical");
		player.moveVertical (verticalInput);
	}


}
