using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearButtonTexts : MonoBehaviour {
    private Button[] buttons;

	// Use this for initialization
	void Start () {
        buttons = GetComponentsInChildren<Button>();
        for(int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponentInChildren<Text>().text = "";
        }
	}
}
