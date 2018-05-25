using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FrontPage : MonoBehaviour {
    Button[] buttons;

	// Use this for initialization
	void Start () {
        buttons = GetComponentsInChildren<Button>();
        for(int i = 0; i < buttons.Length; i++)
        {
            Text buttonTexts = buttons[i].GetComponentInChildren<Text>();
            buttonTexts.text = "";
        }
	}

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
