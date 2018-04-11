using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instruction : MonoBehaviour {
    Button MainMenuButton;
    Text MainMenuButtonText;
	// Use this for initialization
	void Start () {
        MainMenuButton = GetComponentInChildren<Button>();
        MainMenuButtonText = MainMenuButton.GetComponentInChildren<Text>();
        MainMenuButtonText.text = "";
	}
}
