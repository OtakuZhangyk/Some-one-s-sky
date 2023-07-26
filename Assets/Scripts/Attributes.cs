using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes : MonoBehaviour
{
    
    public float damage;
    public float attackSpeed;
    public float HPMax;//fly need hp, hurt reduce hp
    public float currentHP;
    public float resourceMultiple;//rate of get more resources
    public float autoHP;
    public int bulletNumber;
    public float moveSpeed;
    public int bulletLevel;
    public float bulletSpeed;
    public float defend;//hurt rate
    public List<int> items;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // called when an item is added to inventory
    //public void getItem(item )

    // Update is called once per frame
    void Update()
    {
        
    }
}
