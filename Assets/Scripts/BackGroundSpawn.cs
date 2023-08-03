using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundSpawn : MonoBehaviour
{
    public GameObject backGroundPrefab;
    //public GameObject player;

    // player in Xth background(horizontal), Yth background(vertical)
    private int playerX;
    private int playerY;
    private List<Vector3> currentBackGrounds;
    // Start is called before the first frame update
    void Start()
    {
        playerX = 0;
        playerY = 0;
        currentBackGrounds = new List<Vector3>();
        SpawnBackGround();
    }

    void SpawnBackGround()
    {
        for (int i = playerX - 1; i <= playerX + 1; i++)
        {
            for (int j = playerY - 1; j <= playerY + 1; j++)
            {
                if (!currentBackGrounds.Contains(new Vector3(i,j,0)))
                {
                    GameObject newBackGround = Instantiate(backGroundPrefab, new Vector3(i * 40.95f, j * 40.95f, 0), Quaternion.identity);

                    newBackGround.name = "Background(" + i + "," + j + ")";
                    newBackGround.transform.localScale = new Vector3((int)(2 * System.Math.Pow(-1, i)), (int)(2 * System.Math.Pow(-1, j)), 2);
                    currentBackGrounds.Add(new Vector3(i,j,0));
                }
            }
        }
    }

    void DespawnBackGround()
    {
        // destory backgrounds that are not in (playerX - 1 ~ playerX + 1, playerY - 1 ~ playerY + 1)
        for (int i = 0; i < currentBackGrounds.Count; i++)
        {
            if (currentBackGrounds[i].x < playerX - 1 || currentBackGrounds[i].x > playerX + 1 || currentBackGrounds[i].y < playerY - 1 || currentBackGrounds[i].y > playerY + 1)
            {
                //Debug.Log("Destroy Background(" + currentBackGrounds[i].x + "," + currentBackGrounds[i].y + ")");
                //Debug.Log("currentBackGrounds.Count: " + currentBackGrounds.Count);
                GameObject.Destroy(GameObject.Find("Background(" + currentBackGrounds[i].x + "," + currentBackGrounds[i].y + ")"));
                currentBackGrounds.RemoveAt(i);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        int curplayerX;
        int curplayerY;
        if (transform.position.x > 0)
        {
            curplayerX = ((int)transform.position.x + 20) / 40;
        }
        else
        {
            curplayerX = ((int)transform.position.x - 20) / 40;
        }
        if (transform.position.y > 0)
        {
            curplayerY = ((int)transform.position.y + 20) / 40;
        }
        else
        {
            curplayerY = ((int)transform.position.y - 20) / 40;
        }
        if (curplayerX != playerX || curplayerY != playerY)
        {
            playerX = curplayerX;
            playerY = curplayerY;
            Debug.Log("playerX: " + playerX + " playerY: " + playerY);
            Debug.Log(transform.position.x + "," + transform.position.y);
            SpawnBackGround();
            DespawnBackGround();
        }
    }
}
