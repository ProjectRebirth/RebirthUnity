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
}
