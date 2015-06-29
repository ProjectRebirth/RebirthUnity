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
	public Image shieldBar2;
	public Image impactBar2;
	public Image ammoRow1;
	public Image ammoRow2;
	public Image ammoRow3;
	public Image ammoRow4;


	public Image energyBar;
	
	private float initHealth;
	private float initShield;

	private int currentAmmo;
	private int maxClipAmmo;
	
	// Use this for initialization
	void Start () {
		initHealth = playerStats.curHealth;
		initShield = playerStats.curShield;

		currentAmmo = weapStats.getCurrentAmmo ();
		maxClipAmmo = weapStats.getMaxAmmo ();
	}
	
	// Update is called once per frame
	void Update () {
		updateHPShield ();
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
	void updateAmmo(){
		
	}
	void updateHPShield(){
		if (Input.GetKeyDown (KeyCode.O)) {
			playerStats.damagePlayer(11f);
		}

		float displacement1 = moveTowards ((initShield  * playerStats.maxShield), (playerStats.curShield * playerStats.maxShield), Time.deltaTime * .4f );
		float displacement2 = moveTowards (initHealth  * playerStats.maxHealth, playerStats.curHealth  * playerStats.maxHealth, Time.deltaTime *.4f);
		shieldBar.fillAmount = (playerStats.curShield  * playerStats.maxShield);
		impactBar.fillAmount = displacement1;
		healthBar.fillAmount = (playerStats.curHealth * playerStats.maxHealth);
		damageBar.fillAmount = displacement2;
		
		initShield = displacement1 * playerStats.maxShield;
		initHealth = displacement2 * playerStats.maxHealth;
	}

}
