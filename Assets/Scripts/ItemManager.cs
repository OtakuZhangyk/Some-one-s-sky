using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
//Tells Random to use the Unity Engine random number generator.
using Random = UnityEngine.Random;

[System.Serializable]
public class item {
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
    public float defend = 0;//hurt rate

    public int cost = 50;
}


public class ItemManager : MonoBehaviour
{
    public GameObject itemSelectPanel;
    public GameObject character;
    public GameObject storePanel;
    

    public List<item> itemList = new List<item>();//all items store in this list
    private int itemListLength;

    public List<item> storeItemList = new List<item>();//all items store in this list
    private int storeItemListLength;

    
    // Start is called before the first frame update
    void Start()
    {
        itemList.Add(new item {index = 0, name = "Lazor Gun", description = "",damage = 1, attackSpeed = 1, bulletSpeed = 1});
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
            HPMax = 0.2f,
            defend = 0.85f
        });
        itemList.Add(new item
        {
            index = 5,
            name = "Meteorite Thruster",
            description = "A propulsion engine designed using the dense matter found in meteorites.",
            effectDescription = "Increases the ship's move speed by 30%, allowing you to evade enemy fire and travel through the map at a faster pace. Also, it improves bullet speed by 20% due to the explosive force it creates.",
            moveSpeed = 0.3f,
            bulletSpeed = 0.2f
        });
        itemList.Add(new item
        {
            index = 6,
            name = "Plasma Infuser",
            description = "A high-tech device that injects plasma into your weapon systems.",
            effectDescription = "Increases damage by 25% by supercharging your weapons with volatile plasma. Also, it boosts attack speed by 10% due to improved energy flow. ",
            damage = 0.25f,
            attackSpeed = 0.1f
        });
        itemList.Add(new item
        {
            index = 7,
            name = "Nebula Medikit",
            description = "An advanced medikit infused with regenerative particles found in nebulae.",
            effectDescription = "Boosts auto recover HP by 10 per second, enabling your ship to heal itself faster during combat. Increases max HP by 10% due to the additional vitality granted by nebula particles. ",
            autoHP = 10f,
            HPMax = 0.1f
        });

        itemListLength = itemList.Count;
        
        
        storeItemList.Add(new item {index = 100, name = "Test1", damage = 1, attackSpeed = 1, bulletSpeed = 1, cost = 50});
        storeItemList.Add(new item {index = 101, name = "Test2", damage = 1, attackSpeed = 1, bulletSpeed = 1, cost = 100});
        storeItemList.Add(new item {index = 102, name = "Test3", damage = 1, attackSpeed = 1, bulletSpeed = 1, cost = 150});
        storeItemListLength = storeItemList.Count;
    }

    


    // enemy dies, random drop rate, call rollItem
    // roll three items
    // pass index int, name and description strings to buttons 
    // button call giveItem(int itemIndex)
    // giveItem() change values in character.attributes

    // roll three items
    public void rollItems(bool isStore = false)
    {
        int item1 = Random.Range(0,itemListLength);
        int item2 = Random.Range(0,itemListLength);
        while (item2 == item1)
            item2 = Random.Range(0,itemListLength);
        int item3 = Random.Range(0,itemListLength);
        while (item3 == item2 || item3 == item1)
            item3 = Random.Range(0,itemListLength);
        
        if (isStore)
        {
            item1 = Random.Range(0,storeItemListLength);
            item2 = Random.Range(0,storeItemListLength);
            while (item2 == item1)
                item2 = Random.Range(0,storeItemListLength);
            item3 = Random.Range(0,storeItemListLength);
            while (item3 == item2 || item3 == item1)
                item3 = Random.Range(0,storeItemListLength);
        }
        
        void ChangeButtonText(string buttonName, int itemIndex)
        {
            GameObject button;
            if (!isStore)
            {
                button = itemSelectPanel.transform.Find(buttonName).gameObject;
            }
            else
            {
                button = storePanel.transform.Find(buttonName).gameObject;
            }
            // pass item index
            ItemButton itemButtonScript = button.GetComponent<ItemButton>();
            if (!isStore)
                itemButtonScript.itemIndex = itemIndex;
            else
                itemButtonScript.itemIndex = itemIndex + 100;
            // get TMPs
            TMP_Text nameTMP = button.transform.Find("NameTMP").GetComponent<TMP_Text>();
            TMP_Text descriptionTMP = button.transform.Find("DescriptionTMP").GetComponent<TMP_Text>();
            TMP_Text effectTMP = button.transform.Find("EffectTMP").GetComponent<TMP_Text>();
            // change texts in buttons 
            if (!isStore)
            {
                nameTMP.text = itemList[itemIndex].name;
                descriptionTMP.text = itemList[itemIndex].description;
                effectTMP.text = itemList[itemIndex].effectDescription;
            }
            else
            {
                nameTMP.text = storeItemList[itemIndex].name;
                descriptionTMP.text = storeItemList[itemIndex].description;
                effectTMP.text = storeItemList[itemIndex].effectDescription;
                TMP_Text costTMP = button.transform.Find("CostTMP").GetComponent<TMP_Text>();
                costTMP.text = storeItemList[itemIndex].cost.ToString();
                Debug.Log(storeItemList.Count);
            }
        }

        ChangeButtonText("Button1", item1);
        ChangeButtonText("Button2", item2);
        ChangeButtonText("Button3", item3);
        // show item select panel and buttons
        if (!isStore)
            itemSelectPanel.SetActive(true);
    }


    public bool giveItem(int itemIndex)
    {
        
        if (itemIndex < 100)
        {
            // hide item select panel and buttons
            itemSelectPanel.SetActive(false);
            Debug.Log("chose item " + itemList[itemIndex].name);
        }
        else
        {
            Debug.Log("itemIndex " + itemIndex);
            Debug.Log("chose store item "  + storeItemList[itemIndex - 100].name);
        }

        Attributes AttributesScript = character.GetComponent<Attributes>();
        AttributesScript.items.Add(itemIndex);

        if (itemIndex < 100)
        {
            AttributesScript.damageModifier += itemList[itemIndex].damage;
            AttributesScript.attackSpeedModifier += itemList[itemIndex].attackSpeed;
            AttributesScript.GetAttackSpeed();

            float oldHPMax = AttributesScript.GetHPMax();

            AttributesScript.HPMaxModifier += itemList[itemIndex].HPMax;

            //After item was given, check if hpmax is changed by the item. If so, change hpmax and currenthp
            
            if (oldHPMax != AttributesScript.GetHPMax())
            {
                Debug.Log("Hpmax is changed from" + oldHPMax + "to" + AttributesScript.GetHPMax());
                if (AttributesScript.currentHP > AttributesScript.GetHPMax())
                {
                    AttributesScript.currentHP = AttributesScript.GetHPMax();
                }
            }

            AttributesScript.resourceMultipleModifier += itemList[itemIndex].resourceMultiple;//implement in enemy.cs

            AttributesScript.autoHPModifier += itemList[itemIndex].autoHP;

            AttributesScript.baseBulletNumber += itemList[itemIndex].bulletNumber;
            AttributesScript.moveSpeedModifier += itemList[itemIndex].moveSpeed;
            AttributesScript.bulletSpeedModifier += itemList[itemIndex].bulletSpeed;
            AttributesScript.defendModifier *= itemList[itemIndex].defend;//defend = base defend * defend modifer

            AttributesScript.bulletLevelModifier += itemList[itemIndex].bulletLevel;
            return true;
        }
        else
        {
            if (AttributesScript.gold < storeItemList[itemIndex - 100].cost)
            {
                return false;
            }
            AttributesScript.damageModifier += storeItemList[itemIndex - 100].damage;
            AttributesScript.attackSpeedModifier += storeItemList[itemIndex - 100].attackSpeed;
            AttributesScript.GetAttackSpeed();

            float oldHPMax = AttributesScript.GetHPMax();

            AttributesScript.HPMaxModifier += storeItemList[itemIndex - 100].HPMax;

            //After item was given, check if hpmax is changed by the item. If so, change hpmax and currenthp
            
            if (oldHPMax != AttributesScript.GetHPMax())
            {
                Debug.Log("Hpmax is changed from" + oldHPMax + "to" + AttributesScript.GetHPMax());
                if (AttributesScript.currentHP > AttributesScript.GetHPMax())
                {
                    AttributesScript.currentHP = AttributesScript.GetHPMax();
                }
            }

            AttributesScript.resourceMultipleModifier += storeItemList[itemIndex - 100].resourceMultiple;//implement in enemy.cs

            AttributesScript.autoHPModifier += storeItemList[itemIndex - 100].autoHP;

            AttributesScript.baseBulletNumber += storeItemList[itemIndex - 100].bulletNumber;
            AttributesScript.moveSpeedModifier += storeItemList[itemIndex - 100].moveSpeed;
            AttributesScript.bulletSpeedModifier += storeItemList[itemIndex - 100].bulletSpeed;
            AttributesScript.defendModifier *= storeItemList[itemIndex - 100].defend;//defend = base defend * defend modifer

            AttributesScript.bulletLevelModifier += storeItemList[itemIndex - 100].bulletLevel;
            
            AttributesScript.gold -= storeItemList[itemIndex - 100].cost;
            return true;
        }

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
