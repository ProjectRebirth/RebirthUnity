using UnityEngine;
using System.Collections;

public class SpriteStats : MonoBehaviour {
	

	public float curHealth;
	public float maxHealth;

	public bool isDead;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		checkIsDead ();
	}
	

	public void plusCurHealth(float incAmt){
		if ((curHealth + incAmt) >= maxHealth) {
			curHealth = maxHealth;
		} else {
			curHealth += incAmt;
		}
	}

	public void subCurHealth(float decAmt){
		if ((curHealth - decAmt) <= 0) {
			curHealth = 0;
		}else {
			curHealth -= decAmt;
		}
	}

	public void checkIsDead(){
		if (curHealth == 0) {
			isDead = true;
		} else {
			isDead = false;
		}
	}

	/***********Getter*************/
	public bool getIsDead(){
		return isDead;
	}

	public float getCurHealth(){
		return curHealth;
	}
	public float getmaxHealth(){
		return maxHealth;
	}

	/***********Setters*************/
	public void setIsDead(bool boolean){
		isDead = boolean;
	}

	public void setCurHealth(float num){
		curHealth = num;
	}

	public void setMaxHealth(float num){
		maxHealth = num;
	}



}
