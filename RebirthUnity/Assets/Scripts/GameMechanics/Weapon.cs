using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	protected static float DEFAULT_ACCURACY = .05f;

	public BulletMechanics ammo;//The ammo that will be 
	public GraysonMechanics grayson;
	public Vector3 upLocalPosition;
	public int maxAmmo;//The max size of a magazine clip in the gun
	public int currentAmmo;//The current amount of ammo in the magazine
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
		ammoCarried = 150; //This will change later on
	}


	/**
	 * Checks if the weapon has a proper cool down and then fires the bullet
	 * associated with the weapon if the player is pushing down the fire button
	 */ 
	public void fireWeapon(Vector2 dir) {
		if (refreshTimer <= 0 && currentAmmo > 0 && !grayson.getIsReloading()) {
			BulletMechanics obj = null;

			if (grayson.getIsLookingUp()){
				// Prepare bullet's position
				Vector3 bulletPosition = upLocalPosition + grayson.transform.localPosition;
				bulletPosition = Weapon.defineSpread (bulletPosition, 1);
				
				obj = (BulletMechanics)Instantiate (ammo, bulletPosition, new Quaternion ());
			}else {
				// Prepare bullet's position
				Vector3 bulletPosition = transform.position;
				bulletPosition = Weapon.defineSpread (bulletPosition, 2);

				obj = (BulletMechanics)Instantiate (ammo, bulletPosition, new Quaternion ());
			}


			obj.setDirection (dir);
			refreshTimer = refreshRate;
			currentAmmo--;

		}
	}

	/**
	 * 
	 */ 
	public bool hasSpareAmmo() {
		return ammoCarried > 0;
	}

	/**
	 * Checks that the ammo in the magazine is zero
	 */ 
	public bool isMagazineEmpty() {
		return currentAmmo <= 0;
	}

	/**
	 * This only refers to resupplying the gun with more ammunition.
	 * Reload animation is activated somewhere else.
	 */ 
	public void reloadWeapon() {
		int ammoNeeded = maxAmmo - currentAmmo;
		if (ammoNeeded <= ammoCarried) {
			currentAmmo += ammoNeeded;
			ammoCarried -= ammoNeeded;
		} else if (ammoNeeded > ammoCarried) {
			currentAmmo += ammoCarried;
			ammoCarried = 0;
		}
	}

	public bool getWeaponIsFull() {
		return maxAmmo == currentAmmo;
	}

	public void addCarriedAmmo (int addedAmmo) {
		ammoCarried += addedAmmo;
	}

	public int getCurrentAmmo(){
		return currentAmmo;
	}


	public int getMaxAmmo(){
		return maxAmmo;
	}

	/**
	 * updates the cooldown timer for the gun
	 */ 
	void Update() {

		refreshTime (Time.deltaTime);
		checkReloading ();
	}

	/**
	 * 
	 */ 
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

	/*
	 *  The function takes a position and adds a variance to the
	 *  bullet's y axis
	 * 
	 *  @param Vector3 position the initial position
	 * 
	 *  @param int axis defines the axis on which spread needs to be defined
	 * 
	 *  @return position position is returned with variance added
	 */
	protected static Vector3 defineSpread(Vector3 position, int axis)
	{
		switch(axis){
			case 1:
				position.Set (position.x + (Random.value - .5f) * DEFAULT_ACCURACY , position.y, position.z);
				break;
			case 2:
				position.Set (position.x, position.y + (Random.value - .5f) * DEFAULT_ACCURACY, position.z);
				break;
			default:
			// No-op
			break;
		}

		return position;
	}
}
