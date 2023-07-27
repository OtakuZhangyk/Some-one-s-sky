using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes : MonoBehaviour
{
    public float baseDamage;
    public float baseAttackSpeed;
    public float baseHPMax;//fly need hp, hurt reduce hp
    public float baseResourceMultiple;//rate of get more resources
    public float baseAutoHP;
    public int baseBulletNumber;
    public float baseMoveSpeed;
    public float baseBulletSpeed;
    public float baseDefend;//hurt rate

    // current attributes = base atteibutes +/* modifier
    public float damageModifier;
    public float attackSpeedModifier;
    public float HPMaxModifier;
    public float resourceMultipleModifier;//rate of get more resources
    public float autoHPModifier;
    public int bulletNumberModifier;
    public float moveSpeedModifier;
    public float bulletSpeedModifier;
    public float defendModifier;//hurt rate
    
    public int baseBulletLevel;
    public int bulletLevelModifier;
    
    public float currentHP;

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
