using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
    public float maxHealth;
    [HideInInspector]
    public float health;
    public int value;

    private Level01 level01script;
    private Image healthBar;

    // Use this for initialization
    void Start () {
        health = maxHealth;
        level01script = GameObject.Find("Level01Screen").GetComponent<Level01>();
        healthBar = GetComponentInChildren<Image>();
    }
	
	// Update is called once per frame
	void Update () {
		if(health <= 0)
        {
            level01script.money += value;
            level01script.moneyText.text = level01script.money.ToString();
            level01script.removeFromEnemyList(gameObject);
            Destroy(gameObject);
        }
        healthBar.fillAmount = (health / maxHealth);
	}
}
