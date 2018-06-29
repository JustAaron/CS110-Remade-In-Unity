using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtEnemy : MonoBehaviour {
    public float range;
    public float damage;
    public float shotsPerSecond;

    private float timeSinceLastFire;
    private float fireRate;

    private Level01 level01script;
    
	// Use this for initialization
	void Start () {
        level01script = GameObject.Find("Level01Screen").GetComponent<Level01>();
        fireRate = 1 / shotsPerSecond;
        timeSinceLastFire = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if(isEnemyInRange() != null && Time.time >= timeSinceLastFire)
        {
            //print("shooting");
            timeSinceLastFire = Time.time + fireRate;
            shoot();
        }
        //print(timeSinceLastFire);
    }

    private GameObject isEnemyInRange()
    {
        //float distance;
        for(int i = 0; i < level01script.GetEnemyList().Count; i++)
        {
            float distance = (transform.position - level01script.GetEnemyList()[i].transform.position).magnitude;
            if (distance <= range)
            {
                return level01script.GetEnemyList()[i];
            }
        }
        return null;
    }

    private void dealDamageTo(GameObject enemy)
    {
        Health enemyHealth = enemy.GetComponent<Health>();
        enemyHealth.health -= damage;
        if(enemyHealth.health <= 0)
        {
            level01script.money += enemyHealth.value;
            level01script.moneyText.text = level01script.money.ToString();
            enemyHealth.DestroySelf();
        }
    }

    private void shoot()
    {
        if (isEnemyInRange() != null)
        {
            dealDamageTo(isEnemyInRange());
        }
    }
}
