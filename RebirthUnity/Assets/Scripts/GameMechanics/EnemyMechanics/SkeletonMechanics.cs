using UnityEngine;
using System.Collections;

public class SkeletonMechanics : TribeMechanics {
	private SkeletonStats skeletonStats;

	protected override void Start() {
		base.Start ();
		skeletonStats = (SkeletonStats)baseStats;
		skeletonStats.setIsInvincible (true);
	}

	public bool getIsInvincible() {
		return skeletonStats.getIsInvincible ();
	}

	public void goInvincible(bool invincibleDown) {
		if (skeletonStats.canActivateInvincible ()) {
			skeletonStats.setIsInvincible(invincibleDown);
		}
	}


	protected override void OnTriggerEnter2D (Collider2D collider) {
		//base.OnCollisionEnter2D (collider);

		print (collider.tag);
		if (collider.tag == "Projectile") {

			BulletMechanics bMechanics = collider.GetComponent<BulletMechanics>();
			if (skeletonStats.getIsInvincible()) {
				print ("Skeleton Mech Print");
				bMechanics.changeEnemyTag("Grayson");
				bMechanics.cancelDestroyBullet();
				reflectProjectile(bMechanics);
			}
		}
	}

	private void reflectProjectile(BulletMechanics bMechanics) {
		Vector2 currentDirection = bMechanics.getDirection ();
		float x = -currentDirection.x + Random.Range (-.1f, .1f);
		float y = -currentDirection.y + Random.Range (-.1f, .1f);
		bMechanics.setDirection (new Vector2(x, y));
	}
}
