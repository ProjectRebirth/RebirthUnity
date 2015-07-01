using UnityEngine;
using System.Collections;

public class GraysonStats : BaseStats {

	public float curShield;
	public float maxShield;

	public float curEnergy;
	public float maxEnergy;

	// Use this for initialization
	void Start () {
		initStats ();
	}
	
	// Update is called once per frame
	void Update () {
		checkHP ();
		capShield ();
	}

	void initStats(){
		curHealth = 100;
		maxHealth = 100;
		curShield = 80;
		maxShield = 100;
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
	public void checkHP(){
		if (curHealth == 0) {
			setIsDead (true);
		} else {
			setIsDead(false);
		}
	}
	public void capShield(){
		if (curShield > maxShield) {
			curShield = maxShield;
		}
	}

	public float getCurShield(){
		return curShield;
	}
	public float getMaxShield(){
		return maxShield;
	}
	public float getCurEnergy(){
		return curEnergy;
	}
	public float getMaxEnergy(){
		return maxEnergy;
	}

	public void setCurShield (float amt){
		curShield = amt;
	}
	public void setMaxShield (float amt){
		maxShield = amt;
	}
	public void setCurEnergy (float amt){
		curEnergy = amt;
	}
	public void setMaxEnergy (float amt){
		maxEnergy = amt;
	}




}
