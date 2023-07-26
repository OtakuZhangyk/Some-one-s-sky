using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
//Tells Random to use the Unity Engine random number generator.
using Random = UnityEngine.Random;

class item {
    public int index;
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
public class itemManager : MonoBehaviour
{
    public GameObject canvas;
    
    private List<item> itemList = new List<item>();
    private int itemListLength;
    
    // Start is called before the first frame update
    void Start()
    {
        itemList.Add(new item {index = 1, name = "Lazor Gun", damage = 1, attackSpeed = 1, bulletSpeed = 1});
        itemList.Add(new item {index = 2, name = "Solar Panel", HPMax = 10, autoHP = 1, defend = 0.9f});
        itemList.Add(new item {index = 3, name = "Overclock Mode", damage = 2, attackSpeed = 1, autoHP = -2, defend = 0.8f});

        itemListLength = itemList.Count;
        // Debug
        rollItems();
    }

    // enemy dies, random drop rate, call rollItem
    // roll three items
    // pass index int, name and description strings to buttons 
    // button call giveItem(int itemIndex)
    // giveItem() change values in character.attributes

    // roll three items
    public void rollItems()
    {
        int item1 = Random.Range(1,itemListLength + 1);
        int item2 = Random.Range(1,itemListLength + 1);
        while (item2 == item1)
            item2 = Random.Range(1,itemListLength + 1);
        int item3 = Random.Range(1,itemListLength + 1);
        while (item3 == item2 || item3 == item1)
            item3 = Random.Range(1,itemListLength + 1);
        
        
        // get buttons
        GameObject button1 = canvas.transform.Find("Button1").gameObject;
        // show buttons
        button1.SetActive(true);
        // pass item index
        itemButton itemButtonScript1 = button1.GetComponent<itemButton>();
        itemButtonScript1.itemIndex = item1;
        // get TMP
        TMP_Text tmp1 = button1.GetComponentInChildren<TMP_Text>();
        // change texts in buttons 
        tmp1.text = itemList[item1 - 1].name;

        GameObject button2 = canvas.transform.Find("Button2").gameObject;
        button2.SetActive(true);
        itemButton itemButtonScript2 = button2.GetComponent<itemButton>();
        itemButtonScript2.itemIndex = item2;
        TMP_Text tmp2 = button2.GetComponentInChildren<TMP_Text>();
        tmp2.text = itemList[item2 - 1].name;

        GameObject button3 = canvas.transform.Find("Button3").gameObject;
        button3.SetActive(true);
        itemButton itemButtonScript3 = button3.GetComponent<itemButton>();
        itemButtonScript3.itemIndex = item3;
        TMP_Text tmp3 = button3.GetComponentInChildren<TMP_Text>();
        tmp3.text = itemList[item3 - 1].name;
    }

    public void giveItem(int itemIndex)
    {
        Debug.Log("chose item " + itemList[itemIndex - 1].name);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
