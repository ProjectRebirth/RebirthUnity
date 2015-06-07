using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public BulletMechanics ammo;
	public GraysonMechanics grayson;
	public Vector3 upLocalPosition;
	public int maxAmmo;
	private int currentAmmo;
	public float refreshRate;
	private float refreshTimer;
	private bool waitingReload;
	public int maxAmmoCarried;

	private int ammoCarried;

	/**
	 * Currently this just sets some random amount of ammo for the gun when it is created.
	 * Mostly for when a gun is picked up.
	 */ 
	void Start() {
		currentAmmo = (int)Random.Range(0, maxAmmo);
		ammoCarried = 0; //This will change later on
	}





	/**
	 * Checks if the weapon has a proper cool down and then fires the bullet
	 * associated with the weapon if the player is pushing down the fire button
	 */ 
	public void fireWeapon(Vector2 dir) {
		if (refreshTimer <= 0 && currentAmmo > 0 && !grayson.getIsReloading()) {
			BulletMechanics obj = null;
			if (grayson.getIsLookingUp()){
				obj = (BulletMechanics)Instantiate (ammo, upLocalPosition + grayson.transform.localPosition, new Quaternion ());
			}else {
				obj = (BulletMechanics)Instantiate (ammo, transform.position, new Quaternion ());
			}


			obj.setDirection (dir);
			refreshTimer = refreshRate;
			currentAmmo--;

		}
	}

	public bool hasSpareAmmo() {
		return ammoCarried > 0;
	}

	public bool isMagazineEmpty() {
		return currentAmmo <= 0;
	}

	public void reloadWeapon() {
		if (ammoCarried > maxAmmo) {
			currentAmmo = maxAmmo;
			ammoCarried-=maxAmmo;
		} else {
			currentAmmo = ammoCarried;
			ammoCarried-=ammoCarried;
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

		refreshTime (Time.deltaTime);
		checkReloading ();
	}

	void checkReloading() {
		if (grayson.getIsReloading ()) {
			waitingReload = true;
			
		}else if (waitingReload && !grayson.getIsReloading ()) {
			reloadWeapon ();
			waitingReload = false;
		} else {
			waitingReload = false;
		}
	}

	void refreshTime(float deltaTime) {
		refreshTimer-=deltaTime;
		if (refreshTimer < 0) {
			refreshTimer = 0;
		}
	}

}
