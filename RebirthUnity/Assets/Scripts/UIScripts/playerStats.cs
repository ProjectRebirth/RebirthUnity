using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class playerStats : MonoBehaviour {
	public float curHealth;
	public float shield;
	public float maxHealth;
	//public float energy;
	public int ammo;
	
	
	public GraysonMechanics graysonStats;
	public Weapon weapStats;
	public Image img;
	public GameObject healthBar;
	
	
	// Use this for initialization
	void Start () {
		curHealth = graysonStats.getHealth();
		maxHealth = graysonStats.getMaxHealth();
	}
	
	// Update is called once per frame
	void Update () {
		curHealth = graysonStats.getHealth();
		ammo = weapStats.getCurrentAmmo();
		if (Input.GetKeyDown (KeyCode.O)) {
			graysonStats.health -= 10;
		}
		img.fillAmount = curHealth / maxHealth;
	}
}
