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
			playerStats.damagePlayer(8f);
		}
		
		//shieldBar.fillAmount = playerStats.curShield / playerStats.maxShield;
		//impactBar.fillAmount = Mathf.MoveTowards ((initShield / playerStats.maxShield), 0, Time.deltaTime * .005f);
		//.fillAmount = playerStats.curHealth / playerStats.maxHealth;
		//.fillAmount = Mathf.MoveTowards (initHealth / playerStats.maxHealth, playerStats.curHealth / playerStats.maxHealth, Time.deltaTime * .005f);
		
		shieldBar.fillAmount = Mathf.MoveTowards ((playerStats.curShield / playerStats.maxShield), 0, Time.smoothDeltaTime * .5f);
		
		initHealth = playerStats.curHealth;
		initShield = playerStats.curShield;
	}
}
