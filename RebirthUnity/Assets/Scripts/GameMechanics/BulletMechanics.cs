using UnityEngine;
using System.Collections;

public class BulletMechanics : MonoBehaviour {

	public float speed;
	public Weapon weapon;
	private Vector2 unitVector;
	private Vector3 origin;
	public string enemyTag;
	public float damage;
	public Animator bulletAnimator;

	/**
	 * Bullets are triggers. Use O
	 */ 
	void Start() {
		origin = transform.localPosition;
		//unitVector = new Vector2(1, 0);

		bulletAnimator.enabled = false;
	}
	

	/**
	*The bulllet will update its location here
	*/
	protected virtual void Update() {
		Rigidbody2D rigid = GetComponent<Rigidbody2D> ();
		checkOutOfRange ();

		if (!bulletAnimator.enabled) {
			rigid.velocity = speed * unitVector;
		} else {
			rigid.velocity = new Vector2();
		}

		if (bulletAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1){
			Destroy(this.gameObject);
		}
	}

	protected void checkOutOfRange() {
		if (getMagnitudeFromOrigin() > 10) {
			Destroy(gameObject);		
		}

	}

	/**
	 * Sets the direction that the projectile will follow in 2d space.
	 * 
	 */
	public virtual void setDirection(Vector2 direction) {

		unitVector = normalizeVector(direction);
	} 

	private Vector2 normalizeVector(Vector2 vec) {
		float x = vec.x;
		float y = vec.y;

		float mag = Mathf.Sqrt (x * x + y * y);
		return new Vector2 (x / mag, y / mag);
	}



	/**
	 * This does a quick check the distance between the origin and the projectile's
	 * current locatio
	 */ 
	private float getMagnitudeFromOrigin() {
		float x = transform.localPosition.x - origin.x;
		float y = transform.localPosition.y - origin.y;
		return Mathf.Sqrt(x * x + y * y);


	}

	/**
	 * Use this method to do something when a bullet enters an area
	 */ 
	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag != "Grayson") {
			SpriteMechanics sprite = collider.GetComponent<SpriteMechanics>();
			sprite.setHealth (0);
			bulletAnimator.enabled = true;
		}
	}

	/**
	 * Use this to carry out a task when the bullet exits an
	 * area.
	 */ 
	void OntriggerExit2D (Collider2D collider) {

	}


	/**
	 * This is supposed to destoy the bullet after it collides with another boject,
	 * but something bad happens when this is uncommented and there are no bullets on
	 * screen.
	 */

	void OnCollisionEnter2D(Collision2D collider) {
		//Destroy (gameObject);


	}

}
