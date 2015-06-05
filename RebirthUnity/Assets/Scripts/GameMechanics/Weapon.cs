using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public GameObject ammo;
	public GraysonMechanics grayson;
	public int maxAmmo;
	private int currentAmmo;
	public float refreshRate;
	private float refreshTimer;

	private int ammoCarried;

	/**
	 * Currently this just sets some random amount of ammo for the gun when it is created.
	 * Mostly for when a gun is picked up.
	 */ 
	void Start() {
		currentAmmo = (int)Random.Range(0, maxAmmo);
		ammoCarried = 200; //This will change later on
	}

	/**
	 * Checks if the weapon has a proper cool down and then fires the bullet
	 * associated with the weapon if the player is pushing down the fire button
	 */ 
	public void fireWeapon(Vector2 dir) {
		if (refreshTimer <= 0 && currentAmmo > 0 && !grayson.getIsReloading()) {
			GameObject obj = (GameObject)Instantiate (ammo, transform.position, new Quaternion ());

			BulletMechanics bullet = obj.GetComponent<BulletMechanics> ();

			bullet.setDirection (dir);
			refreshTimer = refreshRate;
			currentAmmo--;

		}
	}

	public bool isEmpty() {
		return currentAmmo <= 0;
	}

	public void reloadWeapon() {
		if (ammoCarried > maxAmmo) {
			currentAmmo = maxAmmo;
		} else {
			currentAmmo = ammoCarried;
		}
	}

	public bool getWeaponIsFull() {
		return maxAmmo == currentAmmo;
	}

	public void addCarriedAmmo (int addedAmmo) {
		ammoCarried += addedAmmo;
	}



	/**
	 * updates the cooldown timer for the gun
	 */ 
	void Update() {
		refreshTimer-=Time.deltaTime;
		if (refreshTimer < 0) {
			refreshTimer = 0;
		}
	}


}
