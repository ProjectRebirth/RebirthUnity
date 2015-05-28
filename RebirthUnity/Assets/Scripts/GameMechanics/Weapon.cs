using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public GameObject ammo;
	public int maxAmmo;
	private int currentAmmo;
	public int refreshRate;
	private int refreshTimer;

	void Start() {
		currentAmmo = (int)Random.Range(0, maxAmmo);

	}

	public void fireWeapon(Vector2 dir) {
		if (refreshTimer <= 0) {
			GameObject obj = (GameObject)Instantiate (ammo, transform.position, new Quaternion ());
			BulletMechanics bullet = obj.GetComponent<BulletMechanics> ();

			bullet.setDirection (dir);
			refreshTimer = refreshRate;
		}
	}

	void Update() {
		refreshTimer--;
		if (refreshTimer < 0) {
			refreshTimer = 0;
		}
	}
	
}
