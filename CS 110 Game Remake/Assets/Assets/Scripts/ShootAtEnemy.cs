using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtEnemy : MonoBehaviour {
    public float range = 5f;
    public float damage = 100f;
    public float shotsPerSecond;

    private float timeSinceLastFire = 0f;
    private float fireRate;

    private Level01 level01script;
    
	// Use this for initialization
	void Start () {
        level01script = GameObject.Find("Level01Screen").GetComponent<Level01>();
        fireRate = 1 / shotsPerSecond;
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
        for(int i = 0; i < level01script.enemyList.Count; i++)
        {
            float distance = (transform.position - level01script.enemyList[i].transform.position).magnitude;
            if (distance <= range)
            {
                return level01script.enemyList[i];
            }
        }
        return null;
    }

    private void dealDamageTo(GameObject enemy)
    {
        enemy.GetComponent<Health>().health -= damage;
        print(enemy);
    }

    private void shoot()
    {
        if (isEnemyInRange() != null)
        {
            dealDamageTo(isEnemyInRange());
        }
    }
}
