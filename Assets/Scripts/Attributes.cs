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
    public float resourceMultipleModifier;
    public float autoHPModifier;
    public int bulletNumberModifier;
    public float moveSpeedModifier;
    public float bulletSpeedModifier;
    public float defendModifier;
    
    public int baseBulletLevel;
    public int bulletLevelModifier;
    
    public float currentHP;

    public List<int> items;


    // Start is called before the first frame update
    void Start()
    {
        GetAttackSpeed();
    }

    public float GetDamage()
    {
        return baseDamage * damageModifier;
    }

    public float GetAttackSpeed()
    {
        void UpdateTimeBetweenAttacks()
        {
            Fire FireScript = GetComponent<Fire>();
            FireScript.timeBetweenFires = 1/(baseAttackSpeed * attackSpeedModifier);
        }

        UpdateTimeBetweenAttacks();
        return baseAttackSpeed * attackSpeedModifier;
    }

    public float GetHPMax()
    {
        return baseHPMax * HPMaxModifier;
    }

    public float GetResourceMultiple()
    {
        return baseResourceMultiple * resourceMultipleModifier;
    }

    public float GetAutoHP()
    {
        return baseAutoHP * autoHPModifier;
    }

    public float GetBulletNumber()
    {
        return baseBulletNumber + bulletNumberModifier;
    }

    public float GetMoveSpeed()
    {
        return baseMoveSpeed * moveSpeedModifier;
    }

    public float GetBulletSpeed()
    {
        return baseBulletSpeed * bulletSpeedModifier;
    }

    public float GetDefend()
    {
        return baseDefend * defendModifier;
    }

    // called on getting hit 
    public void DecreaseHealth(float amount)
    {
        currentHP -= amount;
        Debug.Log("Player HP: " + currentHP);
        if (currentHP <= 0)
        {
            gameObject.SetActive(false);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
