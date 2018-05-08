using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    AudioSource music;
    bool isSoundPlaying = true;

	// Use this for initialization
	void Awake () {
        music = GetComponent<AudioSource>();
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            DontDestroyOnLoad(transform.gameObject);
        }
	}
    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            QuitGame();
        }
    }

    void StartWave()
    {

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
