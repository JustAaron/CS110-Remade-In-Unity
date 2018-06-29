using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level01 : MonoBehaviour {
    private Button[] buttons;
    public int livesOrig, moneyOrig, waveOrig, finalWave;
    public float spawnWait;
    [HideInInspector]
    public int lives, money, wave;
    public GameObject winPage, endPage;
    //private Ray ray;
    //private RaycastHit hit;
    public Text livesText, moneyText, waveText;
    public GameObject enemy;
    private List<GameObject> enemyList, towerList;
    //private bool startWaveEvent;
    private bool waveStarted;
    private int count;
    //private float waveTimer;

	// Use this for initialization
	void Start () {
        buttons = GetComponentsInChildren<Button>();
        for(int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponentInChildren<Text>().text = "";
        }
        livesText = transform.Find("Texts/LivesText").gameObject.GetComponent<Text>();
        moneyText = transform.Find("Texts/MoneyText").gameObject.GetComponent<Text>();
        waveText = transform.Find("Texts/WaveText").gameObject.GetComponent<Text>();
        //startWaveEvent = false;
        //waveTimer = 0;
        waveStarted = false;
        lives = livesOrig;
        money = moneyOrig;
        wave = waveOrig;
        enemyList = new List<GameObject>();
        towerList = new List<GameObject>();
        count = 0;
    }

    private void SpawnEnemy()
    {
        GameObject tempEnemy = Instantiate(enemy, new Vector3(-6.25f, 5f, 0f), Quaternion.identity);
        enemyList.Add(tempEnemy);
    }

    public void removeFromEnemyList(GameObject removeEnemy)
    {
        enemyList.Remove(removeEnemy);
    }

    public IEnumerator StartWave(int numberOfEnemies)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            SpawnEnemy();
            count++;
            //print(count);
            yield return new WaitForSeconds(spawnWait);
        }
        //print("wave ended");
        //print("coroutine ended");
        waveStarted = false;
    }

    public void StartWaveButtonClicked()
    {
        //print("button clicked");
        if (!waveStarted)
        {
            //print("wave started");
            //startWaveEvent = false;
            waveStarted = true;
            wave++;
            waveText.text = wave.ToString();
            //waveTimer += Time.deltaTime;
            StartCoroutine(StartWave(wave * 3 + 5));
            if (wave == finalWave + 1)
            {
                ResetGame();
                StopAllCoroutines();
                winPage.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }

    public void ResetGame()
    {
        //startWaveEvent = false;
        //waveTimer = 0;
        waveStarted = false;
        lives = livesOrig;
        money = moneyOrig;
        wave = waveOrig;
        livesText.text = lives.ToString();
        moneyText.text = money.ToString();
        waveText.text = wave.ToString();
        for (int i = 0; i < enemyList.Count; i++)
        {
            Destroy(enemyList[i].GetComponent<Health>().GetHealthBar());
            Destroy(enemyList[i].gameObject);
        }
        enemyList.Clear();
        for (int i = 0; i < towerList.Count; i++)
        {
            Destroy(towerList[i].gameObject);
        }
        towerList.Clear();
    }

    public List<GameObject> GetEnemyList()
    {
        return enemyList;
    }

    public List<GameObject> GetTowerList()
    {
        return towerList;
    }
}
