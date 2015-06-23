using UnityEngine;
using System.Collections;

public class NPCController : MonoBehaviour {
	public TribeMechanics npc;

	
	/**
	 * This is where all the inputs will be checked in the game.
	 * The controller classes will typically be where inputs from outside users are checked
	 */ 
	void FixedUpdate () {
		float horiztonalInput = Input.GetAxis ("Horizontal");
		float verticalInput = Input.GetAxis ("Vertical");
		bool isAttacking = Input.GetKey (KeyCode.B);

		npc.attack (Input.GetKey(KeyCode.G));
		npc.moveHorizontal (horiztonalInput);
		npc.moveVertical (verticalInput);


	}
}
