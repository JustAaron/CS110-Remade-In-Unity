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
    private Canvas mainCanvas;
    private Image healthBar;
    private Image healthBarCopy;
    private Vector3 SPAWN;

    // Use this for initialization
    void Start () {
        health = maxHealth;
        level01script = GameObject.FindGameObjectWithTag("Level01").GetComponent<Level01>();
        mainCanvas = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>();
        healthBar = GameObject.FindGameObjectWithTag("HealthBarOriginal").GetComponent<Image>();
        SPAWN = gameObject.transform.position + new Vector3(0f, 0.4f, 0f);
        healthBarCopy = Instantiate(healthBar, mainCanvas.transform);
        healthBarCopy.transform.position = SPAWN;
        healthBarCopy.tag = "Untagged";
    }
	
	// Update is called once per frame
	void Update () {
        healthBarCopy.transform.position = gameObject.transform.position + new Vector3(0f, 0.4f, 0f);
        healthBarCopy.fillAmount = (health / maxHealth);
	}

    public Image GetHealthBar()
    {
        return healthBarCopy;
    }

    public void DestroySelf()
    {
        level01script.removeFromEnemyList(gameObject);
        Destroy(healthBarCopy.gameObject);
        Destroy(gameObject);
    }
}
