using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level01 : MonoBehaviour {
    Button[] buttons;
    public int lives = 20;
    public int money = 500;
    public int wave = 1;
    //public GameObject tile;
    //public List<GameObject> tiles = new List<GameObject>();
    private Ray ray;
    private RaycastHit hit;
    private Text[] texts;
    public Text livesText;
    public Text moneyText;
    public Text waveText;
    public GameObject enemy;
    public List<GameObject> enemyList;

	// Use this for initialization
	void Start () {
        buttons = GetComponentsInChildren<Button>();
        for(int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponentInChildren<Text>().text = "";
        }
        texts = GetComponentsInChildren<Text>();
        livesText = transform.Find("Texts/LivesText").gameObject.GetComponent<Text>();
        moneyText = transform.Find("Texts/MoneyText").gameObject.GetComponent<Text>();
        waveText = transform.Find("Texts/WaveText").gameObject.GetComponent<Text>();
        //Debug.Log(StartWaveButton.GetComponentInChildren<Text>().text);
        //SetUpTiles();
    }
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    test();
        //}
	}

    public void spawnEnemy()
    {
        GameObject tempEnemy = Instantiate(enemy, new Vector3(-6.25f, 5f, 0f), Quaternion.identity);
        enemyList.Add(tempEnemy);
    }

    void SetUpTiles()
    {
        bool isColor = false;
        for (float i = -6.5f; i <= 6.5f; i += 1f)
        {
            for (float j = -2f; j <= 6f; j += 1f)
            {
                //Debug.Log(i + " " + j);
                Vector3 pos = new Vector3(i, j, 0);
                //Debug.Log(pos);
                //GameObject tempTile = Instantiate(tile, pos, Quaternion.identity);
                /*if (isColor)
                {
                    isColor = false;
                    tempTile.transform.Find("Tile").GetComponent<SpriteRenderer>().color = Color.red;
                }
                else if (!isColor)
                {
                    isColor = true;
                    tempTile.transform.Find("Tile").GetComponent<SpriteRenderer>().color = Color.blue;
                }*/
                //tiles.Add(tempTile);
                //tempTile.layer = 1;
            }
        }
    }

    //private void test()
    //{
    //    Vector3 mousePoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
    //    mousePoint.z = 0;
    //    print(mousePoint);
    //    ray = Camera.main.ScreenPointToRay(mousePoint);
    //    if (Physics.Raycast(ray, out hit))
    //    {
    //        print("works");
    //        if(hit.collider)
    //        {
    //        print(hit.collider.name);
    //        }
    //    }
    //}

    public void removeFromEnemyList(GameObject removeEnemy)
    {
        enemyList.Remove(removeEnemy);
    }
}
