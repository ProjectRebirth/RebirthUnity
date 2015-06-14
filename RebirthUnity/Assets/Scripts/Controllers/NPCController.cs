using UnityEngine;
using System.Collections;

public class NPCController : MonoBehaviour {
	public SpriteMechanics npc;

	
	// Update is called once per frame
	void FixedUpdate () {
		float horiztonalInput = Input.GetAxis ("Horizontal");
		float verticalInput = Input.GetAxis ("Vertical");
		bool isAttacking = Input.GetKey (KeyCode.B);

		npc.moveHorizontal (horiztonalInput);
		npc.moveVertical (verticalInput);


	}
}
