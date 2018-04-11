using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FrontPage : MonoBehaviour {
    Button[] buttons;
    bool isSoundPlaying = true;
    public GameObject gameController;
    AudioSource music;
	// Use this for initialization
	void Start () {
        buttons = GetComponentsInChildren<Button>();
        for(int i = 0; i < buttons.Length; i++)
        {
            Text buttonTexts = buttons[i].GetComponentInChildren<Text>();
            buttonTexts.text = "";
        }
        music = gameController.GetComponent<AudioSource>();
	}

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("App Quit");
        Application.Quit();
    }

    public void ToggleSound()
    {
        if (isSoundPlaying)
        {
            music.Pause();
            isSoundPlaying = false;
        }
        else
        {
            music.UnPause();
            isSoundPlaying = true;
        }
    }
}
