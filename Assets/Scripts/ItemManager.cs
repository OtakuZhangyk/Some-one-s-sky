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
    public GameObject canvas;
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
        button1 = canvas.transform.Find("Button1").gameObject;
        button2 = canvas.transform.Find("Button2").gameObject;
        button3 = canvas.transform.Find("Button3").gameObject;
        
        itemList.Add(new item {index = 0, name = "Lazor Gun", damage = 1, attackSpeed = 1, bulletSpeed = 1});
        itemList.Add(new item {index = 1, name = "Solar Panel", HPMax = 10, autoHP = 1, defend = 0.9f});
        itemList.Add(new item {index = 2, name = "Overclock Mode", damage = 2, attackSpeed = 1, autoHP = -2, defend = 0.8f});
        itemList.Add(new item {index = 3, name = "Dimensional Siphon", 
            description = "A forbidden technology that drains resources from parallel universes.", 
            effectDescription = "Increases resource multiple by 2, but reduces HPmax by 10%.", 
            resourceMultiple = 2, HPMax = 0.9f});

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
        
        void showButtonChangeText(GameObject button, int itemIndex)
        {
            // show buttons
            button.SetActive(true);
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

        showButtonChangeText(button1, item1);
        showButtonChangeText(button2, item2);
        showButtonChangeText(button3, item3);
    }


    public void giveItem(int itemIndex)
    {
        // hide buttons
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        Debug.Log("chose item " + itemList[itemIndex].name);

        Attributes AttributesScript = character.GetComponent<Attributes>();
        AttributesScript.items.Add(itemIndex);

        AttributesScript.damageModifier += itemList[itemIndex].damage;
        AttributesScript.attackSpeedModifier += itemList[itemIndex].attackSpeed;
        AttributesScript.GetAttackSpeed();
        AttributesScript.HPMaxModifier += itemList[itemIndex].HPMax;
        AttributesScript.resourceMultipleModifier += itemList[itemIndex].resourceMultiple;
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
