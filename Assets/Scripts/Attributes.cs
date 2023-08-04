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
    //public float currentHPMax;
    public int gold;

    public List<int> items;

    public GameObject gameOverPanel;

    public AudioClip hurtSound;//audio
    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        GetAttackSpeed();
        audioSource = GetComponent<AudioSource>();
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
        return baseAutoHP + autoHPModifier;
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
        currentHP -= (amount * GetDefend());
        audioSource.clip = hurtSound;
        audioSource.Play();
        //Debug.Log("Player defend : " + GetDefend());
        //Debug.Log("Player decrease " + amount * GetDefend());
        Debug.Log("Player HP: " + currentHP);
        if (currentHP <= 0)
        {
            //gameObject.SetActive(false);
            // show gameover panel
            gameOverPanel.SetActive(true);
        }
    }

    public void IncreaseHealth(float amount)
    {
        currentHP += amount;
        if (currentHP > GetHPMax())
        {
            currentHP = GetHPMax();
        }
    }

    public void GiveGold(int amount)
    {
        gold += amount;
    }


    // Update is called once per frame

    float autohp;
    void Update()
    {
        autohp = GetAutoHP();
        IncreaseHealth(autohp * Time.deltaTime);
        //Debug.Log(autohp);
    }
}
