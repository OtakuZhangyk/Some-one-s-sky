using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public int gold;
    public float rate;//random rate give random item
    public int heal;
    public int damage;
    public int attackspeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    bool flag = false;
    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(player.transform.position, transform.position);
        if(distance < 8)
        {
            flag = true;
            
        }
    }
}
