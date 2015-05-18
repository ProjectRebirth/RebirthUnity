using UnityEngine;
using System.Collections;


/*
 * This script is used for all of Grayson's mechanics
 * 
 */ 
public class GraysonMechanics : MonoBehaviour {
	public float speed;//The speed that Grayson will be moving from side to side
	public float jumpSpeed;//The height of that Grayson will jump


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
}
