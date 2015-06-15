using UnityEngine;
using System.Collections;

public class AxeMechanics : MonoBehaviour {
	private Collider2D axeCollider;
	public TribeMechanics tribeMechanics;
	public float axeForce;


	void Start() {
		axeCollider = GetComponent<Collider2D> ();

	}

	void Update() {
		checkAxeEnabled ();
	}

	void checkAxeEnabled () {
		if (tribeMechanics.getIsAttacking ()) {
			axeCollider.enabled = true;
		} else {
			axeCollider.enabled = false;
		}

	}

	void OnTriggerEnter2D(Collider2D collider) {

		if (collider.tag == "Grayson") {

			Rigidbody2D rigid = collider.GetComponent<Rigidbody2D>();
			SpriteMechanics grayson = collider.GetComponent<SpriteMechanics>();

			if (tribeMechanics.getIsRight()){
				rigid.velocity = new Vector2(1, .6f) * axeForce;

			} else {
				rigid.velocity = new Vector2(-1, .6f) * axeForce;
			}

			grayson.setIsHit(true);
		}
	}
}
