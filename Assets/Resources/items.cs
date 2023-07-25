using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

class item{
    public int num;
    public string name;
    public float damage = 0;
    public float attackSpeed = 0;
    public float HPMax = 0 ;//fly need hp, hurt reduce hp
    public float currentHP = 0;
    public float resourceMultiple = 0;//rate of get more resources
    public float autoHP = 0;
    public int bulletNumber = 0;
    public float moveSpeed = 0;
    public int bulletLevel = 0;
    public float bulletSpeed = 0;
    public float defend = 1.0f;//hurt rate
}
public class items : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        item lazerGun = new item {num = 1, name = "Lazor Gun", damage = 1, attackSpeed = 1, bulletSpeed = 1};
        item solarPanel = new item { num = 2, name = "Solar Panel", HPMax = 10, autoHP = 1, defend = 0.9f};
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
