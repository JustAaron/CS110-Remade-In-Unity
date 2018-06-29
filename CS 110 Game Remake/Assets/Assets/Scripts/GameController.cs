using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    AudioSource music;
    bool isSoundPlaying;

	// Use this for initialization
	void Awake () {
        music = GetComponent<AudioSource>();
        Screen.SetResolution(700, 650, false);
        DontDestroyOnLoad(transform.gameObject);
        isSoundPlaying = true;
	}
    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            QuitGame();
        }
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

    public void QuitGame()
    {
        Debug.Log("App Quit");
        Application.Quit();
    }


}
