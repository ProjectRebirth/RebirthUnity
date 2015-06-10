using UnityEngine;
using System.Collections;

public class NPCController : MonoBehaviour {
	public SpriteMechanics npc;

	
	// Update is called once per frame
	void Update () {
		float horiztonalInput = Input.GetAxis ("Horizontal");
		bool isAttacking = Input.GetKey (KeyCode.B);

		npc.moveHorizontal (horiztonalInput);


	}
}
