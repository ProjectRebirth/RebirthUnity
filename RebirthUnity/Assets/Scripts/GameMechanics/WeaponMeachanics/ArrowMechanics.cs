using UnityEngine;
using System.Collections;

public class ArrowMechanics : BulletMechanics {

	protected override void Update() {
		checkOutOfRange ();
	}

	public override void setDirection (Vector2 direction)
	{
		Rigidbody2D rigid = GetComponent<Rigidbody2D> ();
		rigid.velocity = direction * speed;
	}

	 void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == enemyTag) {
			Rigidbody2D arrowRigid = GetComponent<Rigidbody2D>();
			gameObject.transform.parent = collider.transform;
			arrowRigid.velocity = new Vector2(0, 0);
			Destroy(arrowRigid);

			Destroy (this.GetComponent<ArrowMechanics>());
		}
	}
}
