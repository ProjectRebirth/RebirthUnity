using UnityEngine;
using System.Collections;

public class GraysonStats : SpriteStats {

	public float curShield;
	public float maxShield;

	public float curEnergy;
	public float maxEnergy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void initStats(){
		curHealth = 100;
		maxHealth = 100;
		curShield = 50;
		maxShield = 50;
		curEnergy = 1;
		maxEnergy = 1;

	}
	public void takeDamage(float damageAmount){
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
}
