using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
//Tells Random to use the Unity Engine random number generator.
using Random = UnityEngine.Random;

class item {
    public int index;
    public string name = "Test Item";
    public string description = "Test Description";
    public string effectDescription = "Test Effect Description";
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


public class ItemManager : MonoBehaviour
{
    public GameObject itemSelectPanel;
    public GameObject character;
    

    private List<item> itemList = new List<item>();//all items store in this list
    private int itemListLength;

    private GameObject button1;
    private GameObject button2;
    private GameObject button3;
    
    // Start is called before the first frame update
    void Start()
    {
        // get buttons
        button1 = itemSelectPanel.transform.Find("Button1").gameObject;
        button2 = itemSelectPanel.transform.Find("Button2").gameObject;
        button3 = itemSelectPanel.transform.Find("Button3").gameObject;
        
        itemList.Add(new item {index = 0, name = "Lazor Gun", damage = 1, attackSpeed = 1, bulletSpeed = 1});
        itemList.Add(new item {index = 1, name = "Solar Panel", HPMax = 1.1f, autoHP = 1, defend = 0.9f});
        itemList.Add(new item {index = 2, name = "Overclock Mode", damage = 2, attackSpeed = 1, autoHP = -2, defend = 0.8f});
        itemList.Add(new item {index = 3, name = "Dimensional Siphon", 
            description = "A forbidden technology that drains resources from parallel universes.", 
            effectDescription = "Increases resource multiple by 0.5, but reduces HPmax by 10%.", 
            resourceMultiple = 0.5f, HPMax = 0.9f});
        itemList.Add(new item
        {
            index = 4,
            name = "Stardust Shell",
            description = "An armor piece crafted from the remnants of fallen stars.",
            effectDescription = "Increases the ship's max HP by 20%. Offers a 15% boost in the ship's defend rate due to its stardust composition, making it harder for enemy projectiles to penetrate.",
            HPMax = 1.2f,
            defend = 0.85f
        });
        itemList.Add(new item
        {
            index = 5,
            name = "Meteorite Thruster",
            description = "A propulsion engine designed using the dense matter found in meteorites.",
            effectDescription = "Increases the ship's move speed by 30%, allowing you to evade enemy fire and travel through the map at a faster pace. Also, it improves bullet speed by 20% due to the explosive force it creates.",
            moveSpeed = 1.3f,
            bulletSpeed = 1.2f
        });
        itemList.Add(new item
        {
            index = 6,
            name = "Plasma Infuser",
            description = "A high-tech device that injects plasma into your weapon systems.",
            effectDescription = "Increases damage by 25% by supercharging your weapons with volatile plasma. Also, it boosts attack speed by 10% due to improved energy flow. ",
            damage = 1.25f,
            attackSpeed = 1.1f
        });
        itemList.Add(new item
        {
            index = 7,
            name = "Nebula Medikit",
            description = "An advanced medikit infused with regenerative particles found in nebulae.",
            effectDescription = "Boosts auto recover HP by 10 per second, enabling your ship to heal itself faster during combat. Increases max HP by 10% due to the additional vitality granted by nebula particles. ",
            autoHP = 10f,
            HPMax = 1.1f
        });

        itemListLength = itemList.Count;
        // Debug
        //rollItems();
    }

    


    // enemy dies, random drop rate, call rollItem
    // roll three items
    // pass index int, name and description strings to buttons 
    // button call giveItem(int itemIndex)
    // giveItem() change values in character.attributes

    // roll three items
    public void rollItems()
    {
        int item1 = Random.Range(0,itemListLength);
        int item2 = Random.Range(0,itemListLength);
        while (item2 == item1)
            item2 = Random.Range(0,itemListLength);
        int item3 = Random.Range(0,itemListLength);
        while (item3 == item2 || item3 == item1)
            item3 = Random.Range(0,itemListLength);
        
        void ChangeButtonText(GameObject button, int itemIndex)
        {
            // show buttons
            //button.SetActive(true);
            // pass item index
            ItemButton itemButtonScript = button.GetComponent<ItemButton>();
            itemButtonScript.itemIndex = itemIndex;
            // get TMPs
            TMP_Text nameTMP = button.transform.Find("NameTMP").GetComponent<TMP_Text>();
            TMP_Text descriptionTMP = button.transform.Find("DescriptionTMP").GetComponent<TMP_Text>();
            TMP_Text effectTMP = button.transform.Find("EffectTMP").GetComponent<TMP_Text>();
            // change texts in buttons 
            nameTMP.text = itemList[itemIndex].name;
            descriptionTMP.text = itemList[itemIndex].description;
            effectTMP.text = itemList[itemIndex].effectDescription;
        }

        ChangeButtonText(button1, item1);
        ChangeButtonText(button2, item2);
        ChangeButtonText(button3, item3);
        // show item select panel and buttons
        itemSelectPanel.SetActive(true);
    }


    public void giveItem(int itemIndex)
    {
        // hide item select panel and buttons
        itemSelectPanel.SetActive(false);

        Debug.Log("chose item " + itemList[itemIndex].name);

        Attributes AttributesScript = character.GetComponent<Attributes>();
        AttributesScript.items.Add(itemIndex);

        AttributesScript.damageModifier += itemList[itemIndex].damage;
        AttributesScript.attackSpeedModifier += itemList[itemIndex].attackSpeed;
        AttributesScript.GetAttackSpeed();
        AttributesScript.HPMaxModifier += itemList[itemIndex].HPMax;

        //After item was given, check if hpmax is changed by the item. If so, change hpmax and currenthp
        float oldHPMax = AttributesScript.currentHPMax;
        AttributesScript.currentHPMax = AttributesScript.GetHPMax();
        if (oldHPMax != AttributesScript.currentHPMax)
        {
            Debug.Log("Hpmax is changed from" + oldHPMax + "to" + AttributesScript.currentHPMax);
            if (AttributesScript.currentHP > AttributesScript.currentHPMax)
            {
                AttributesScript.currentHP = AttributesScript.currentHPMax;
            }
        }

        AttributesScript.resourceMultipleModifier += itemList[itemIndex].resourceMultiple;//implement in enemy.cs

        AttributesScript.autoHPModifier += itemList[itemIndex].autoHP;

        AttributesScript.baseBulletNumber += itemList[itemIndex].bulletNumber;
        AttributesScript.moveSpeedModifier += itemList[itemIndex].moveSpeed;
        AttributesScript.bulletSpeedModifier += itemList[itemIndex].bulletSpeed;
        AttributesScript.defendModifier += itemList[itemIndex].defend;

        AttributesScript.bulletLevelModifier += itemList[itemIndex].bulletLevel;


        //change attribute modifiers
        
        /*
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
        */

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
