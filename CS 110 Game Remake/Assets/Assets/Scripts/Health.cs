using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    public float health = 100f;
    public int value = 100;

    private Level01 level01script;

    // Use this for initialization
    void Start () {
        level01script = GameObject.Find("Level01Screen").GetComponent<Level01>();
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
	}
}
