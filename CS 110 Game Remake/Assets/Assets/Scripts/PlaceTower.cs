using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour {
    public Sprite towerWithRange;
    public Sprite towerWithoutRange;
    //bool isDragged = false;
    public GameObject level01Manager;
    public GameObject workingTower;
    public int price;

    private Level01 level01script;
    //private List<GameObject> tiles;
    //private GameObject pathsObj;
    //private Transform[] paths;
    private Ray ray;
    private RaycastHit2D hit;

	// Use this for initialization
	void Start () {
        level01script = level01Manager.GetComponent<Level01>();
        //pathsObj = GameObject.Find("Paths");
        //paths = pathsObj.GetComponentsInChildren<Transform>();
        //print(paths);
        //mainCamera = Transform.FindObjectOfType<Camera>();
        //print(mainCamera.transform.position);
        //for(int i = 0; i < paths.Length; i++)
        //{
        //    print(paths[i]);
        //}
        //tiles = level01script.tiles;
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnMouseDrag()
    {
        GetComponent<SpriteRenderer>().sprite = towerWithRange;
        Vector3 mousePosInWorldSpace = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosInWorldSpace.x, mousePosInWorldSpace.y, 0);
    }

    private void OnMouseUp()
    {
        //isDragged = false;
        GetComponent<SpriteRenderer>().sprite = towerWithoutRange;
        transform.position = new Vector3(1.5f, -4.75f, 0f);
        if (CanPlaceTower() && CanPurchaseTower())
        {
            GameObject tempTower = Instantiate(workingTower, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0), Quaternion.identity);
            level01script.money -= price;
            level01script.moneyText.text = level01script.money.ToString();
            level01script.GetTowerList().Add(tempTower);
        }
    }

    private bool CanPurchaseTower()
    {
        return (level01script.money >= price);
    }

    private bool CanPlaceTower()
    {
        //v1:
        //if(Input.mousePosition.y >= 200)
        //{
        //    for(int i = 1; i < paths.Length; i++)
        //    {
        //        if (paths[i].gameObject.GetComponent<Path>().isHovered)
        //        {
        //            print(paths[i].gameObject.GetComponent<Transform>().position);
        //            return false;
        //        }
        //        if(i == paths.Length - 1)
        //        {
        //            return true;
        //        }
        //    }
        //}
        //v3:
        hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if(Input.mousePosition.y <= 200)
        {
            return false;
        }
        if (hit.collider != null)
        {
            if(hit.collider.gameObject.tag == "Path")
            {
                return false;
            }
        }
        return true;
    }
}
