using UnityEngine;
using System.Collections;

public abstract class MeleeWeapon : MonoBehaviour {
	public TribeMechanics tribeMechanics;
	public float weaponForce;
	public string enemyTag;

	protected virtual void Start() {
		//weaponCollider = GetComponent<Collider2D> ();
	}

	protected virtual void Update() {
		checkWeaponEnabled ();
	}

	public abstract void checkWeaponEnabled ();


	void OnTriggerEnter2D(Collider2D collider) {
		
		if (collider.tag == enemyTag) {
			
			Rigidbody2D rigid = collider.GetComponent<Rigidbody2D>();
			SpriteMechanics grayson = collider.GetComponent<SpriteMechanics>();
			
			if (tribeMechanics.getIsRight()){
				rigid.velocity = new Vector2(1, .6f) * weaponForce;
				
			} else {
				rigid.velocity = new Vector2(-1, .6f) * weaponForce;
			}
			
			grayson.setIsHit(true);
		}
	}

}
