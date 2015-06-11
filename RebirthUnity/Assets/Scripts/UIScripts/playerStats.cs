using UnityEngine;
using System.Collections;

public class playerStats : MonoBehaviour {
	
	public float curShield;
	public float maxShield;
	
	public float curHealth;
	public float maxHealth;
	
	public float curEnergy;
	public float maxEnergy;
	
	public int currentAmmo;
	public int maxAmmo;
	
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void damagePlayer(float damageAmount){
		if(curShield > 0){
			if(curShield < damageAmount){
				float remainder = 0f;
				remainder = damageAmount - curShield;
				curShield = 0;
				curHealth -= remainder;
			}else {
				curShield -= damageAmount;
			}
		}else{
			if(curHealth < damageAmount){
				curHealth = 0;
			}else{
				curHealth -= damageAmount;
			}
		}
	}
	public void healPlayer(float healAmount){
		if ((curHealth + healAmount) >= maxHealth) {
			curHealth = maxHealth;
		} else {
			curHealth += healAmount;
		}
	}
}
