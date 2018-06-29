using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToWaypoint : MonoBehaviour {
    private Level01 level01script;
    public float speed;
    public Sprite slime1;
    public Sprite slime2;
    //public Sprite slime3;

    private int waypointTarget;
    private Transform waypoints;
    private Rigidbody2D rb;
    private int animState;
    private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
        waypoints = GameObject.FindGameObjectWithTag("Waypoints").transform;
        level01script = GameObject.FindGameObjectWithTag("Level01").GetComponent<Level01>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        InvokeRepeating("changeAnim", 0.5f, .25f);
        waypointTarget = 0;
        animState = 1;
    }

    private void FixedUpdate()
    {
        doPathFinding();
    }

    private void doPathFinding()
    {
        Transform targetWaypoint = waypoints.GetChild(waypointTarget);
        Vector3 relative = targetWaypoint.position - transform.position;
        Vector3 relativeNormal = relative.normalized;
        float distance = relative.magnitude;
        //print("distance is " + distance);
        //print("target is " + waypointTarget);
        //print("time is " + Time.fixedDeltaTime);
        if(distance <= 0.25f)
        {
            if(waypointTarget + 1 < waypoints.childCount)
            {
                waypointTarget++;
            }
            else
            {
                level01script.lives--;
                level01script.livesText.text = level01script.lives.ToString();
                gameObject.GetComponent<Health>().DestroySelf();
                if (level01script.lives <= 0)
                {
                    level01script.ResetGame();
                    level01script.StopAllCoroutines();
                    level01script.endPage.SetActive(true);
                    level01script.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            rb.AddForce(new Vector2(relativeNormal.x, relativeNormal.y) * speed);
        }
    }

    private void changeAnim()
    {
        if(animState == 1)
        {
            animState = 2;
            spriteRenderer.sprite = slime2;
        }
        else if(animState == 2)
        {
            animState = 1;
            spriteRenderer.sprite = slime1;
        }
    }
}
