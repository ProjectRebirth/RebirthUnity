using UnityEngine;
using System.Collections;

public class BulletMechanics : MonoBehaviour {
	
	public float speed;
	public Weapon weapon;
	private Vector2 unitVector;
	private Vector3 origin;
	public string enemyTag;
	public float rawDamage;
	public Animator bulletAnimator;
	public string[] collideWith;//Objects that the bullet can collide with
	
	/**
	 * Bullets are triggers. Use O
	 */ 
	void Start() {
		origin = transform.localPosition;
		//unitVector = new Vector2(1, 0);
		
		bulletAnimator.enabled = false;
	}

	public void setWeapon(Weapon weapon) {
		this.weapon = weapon;
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

	public void cancelDestroyBullet() {
		bulletAnimator.enabled = false;
	}

	public void changeEnemyTag(string enemyTag) {
		this.enemyTag = enemyTag;
	}
	
	/**
	 * Use this method to do something when a bullet enters an area
	 */ 
	void OnTriggerEnter2D(Collider2D collider) {
		if (checkCollide(collider.tag)) {
			BaseStats sprite = collider.GetComponent<BaseStats>();
			if (collider.tag == enemyTag){
				sprite.takeDamage (rawDamage);
			}
			bulletAnimator.enabled = true;
		}
	}

	public Vector2 getDirection() {
		return unitVector;
	}
	

	
	public bool checkCollide(string checkTag) {
		foreach (string check in collideWith) {
			if (check == checkTag) {
				return true;
			}
		}
		return false;
	}

	public GameObject getOwner() {
		return weapon.getOwner ();
	}

	public string getOwnerTag() {
		return weapon.getOwner ().tag;
	}

	/**
	 * This is supposed to destoy the bullet after it collides with another boject,
	 * but something bad happens when this is uncommented and there are no bullets on
	 * screen.
	 */

	
}
