using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinPage : MonoBehaviour
{
    public GameObject placeableTower;
    public Level01 level01;
    private Button[] buttons;
    private GameObject gameController;

    // Use this for initialization
    void Start()
    {
        buttons = GetComponentsInChildren<Button>();
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponentInChildren<Text>().text = "";
        }
        gameController = GameObject.Find("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        placeableTower.SetActive(false);
    }

    public void restart()
    {
        level01.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ToggleSound()
    {
        gameController.GetComponent<GameController>().ToggleSound();
    }
}