using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class playerStats : MonoBehaviour {

	public float curShield;
	public float maxShield;
	public float initHealth;
	public float initShield;
	public float curHealth;
	public float maxHealth;
	public float curStamina;
	public float maxStamina;
	public int currentAmmo;
	public int maxAmmo;
	
	public GraysonMechanics graysonStats;
	public Weapon weapStats;
	public Image healthBar;
	public Image damageBar;
	public Image shieldBar;
	public Image impactBar;
	public Image staminaBar;
	
	// Use this for initialization
	void Start () {
		//healthBar = GetComponent<Image> ();
		//shieldBar = GetComponent<Image> ();
		//staminaBar = GetComponent<Image> ();
		
		curHealth = graysonStats.getCurHealth();
		maxHealth = graysonStats.getMaxHealth();
		curShield = graysonStats.getCurShield ();
		maxShield = graysonStats.getMaxShield ();
		curStamina = graysonStats.getCurStamina ();
		maxStamina = graysonStats.getMaxStamina ();
		
		initHealth = curHealth;
		initShield = curShield;
		
		currentAmmo = weapStats.getCurrentAmmo ();
		//maxAmmo = weapStats.getMaxAmmo ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.O)) {
			playerTakesDamage(8f);
		}
		
		shieldBar.fillAmount = curShield / maxShield;
		impactBar.fillAmount = Mathf.MoveTowards ((initShield / maxShield), (curShield / maxShield), Time.deltaTime * .005f);
		healthBar.fillAmount = curHealth / maxHealth;
		damageBar.fillAmount = Mathf.MoveTowards (initHealth / maxHealth, curHealth / maxHealth, Time.deltaTime * .005f);
		
		initHealth = curHealth;
		initShield = curShield;
		
		
	}
	void playerTakesDamage(float amount){
		if(graysonStats.curShield > 0){
			if(graysonStats.curShield < amount){
				float remainder = 0f;
				remainder = amount - graysonStats.curShield;
				graysonStats.curShield = 0;
				graysonStats.curHealth -= remainder;
			}else {
				graysonStats.curShield -= amount;
			}
		}else{
			if(graysonStats.curHealth < amount){
				graysonStats.curHealth = 0;
			}else{
				graysonStats.curHealth -= amount;
			}
			
		}
		curHealth = graysonStats.getCurHealth();
		curShield = graysonStats.getCurShield();
		
	}
}
