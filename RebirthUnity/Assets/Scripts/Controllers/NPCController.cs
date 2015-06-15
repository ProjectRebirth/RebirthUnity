using UnityEngine;
using System.Collections;

public class NPCController : MonoBehaviour {
	public TribeMechanics npc;

	
	// Update is called once per frame
	void FixedUpdate () {
		float horiztonalInput = Input.GetAxis ("Horizontal");
		float verticalInput = Input.GetAxis ("Vertical");
		bool isAttacking = Input.GetKey (KeyCode.B);

		npc.attack (Input.GetKey(KeyCode.G));
		npc.moveHorizontal (horiztonalInput);
		npc.moveVertical (verticalInput);


	}
}
