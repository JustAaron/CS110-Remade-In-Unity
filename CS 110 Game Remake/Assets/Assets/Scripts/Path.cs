using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour {
    public bool isHovered = false;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseEnter()
    {
        isHovered = true;
        //print("mouse entered");
    }

    private void OnMouseExit()
    {
        if (isHovered = true)
        {
            //print("mouse exit");
        }
        isHovered = false;
    }
}
