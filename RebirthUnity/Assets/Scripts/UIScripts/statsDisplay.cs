using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class statsDisplay : MonoBehaviour {
	public playerStats playerStats;
	public Weapon weapStats;
	
	public Image healthBar;
	public Image damageBar;
	public Image shieldBar;
	public Image impactBar;
	public Image energyBar;
	
	private float initHealth;
	private float initShield;
	
	// Use this for initialization
	void Start () {
		initHealth = playerStats.curHealth;
		initShield = playerStats.curShield;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.O)) {
			playerStats.damagePlayer(11f);
		}
		float displacement1 = moveTowards ((initShield /2 * playerStats.maxShield), (playerStats.curShield/ 2 * playerStats.maxShield), Time.deltaTime * .4f );
		float displacement2 = moveTowards (initHealth / 2 * playerStats.maxHealth, playerStats.curHealth / 2 * playerStats.maxHealth, Time.deltaTime *.4f);
		shieldBar.fillAmount = playerStats.curShield / 2 * playerStats.maxShield;
		impactBar.fillAmount = displacement1;
		healthBar.fillAmount = playerStats.curHealth / 2 * playerStats.maxHealth;
		damageBar.fillAmount = displacement2;

		initShield = displacement1 * playerStats.maxShield;
		initHealth = displacement2 * playerStats.maxHealth;
	}

	float moveTowards(float current, float goal, float difference) {
		if (current < goal) {
			float newTime = current + difference;
			if (newTime > goal) {
				return goal;
			} else {
				return newTime;
			}
		} else if (current > goal) {
			float newTime = current - difference;
			if (newTime < goal) {
				return goal;
			} else {
				return newTime;
			}
		} else {
			return goal;
		}

	}

}
