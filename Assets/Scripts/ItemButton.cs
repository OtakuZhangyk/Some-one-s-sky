using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButton : MonoBehaviour
{
    public int itemIndex;
    public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void onChoseItem()
    {
        ItemManager itemManagerScript = gameManager.GetComponent<ItemManager>();
        bool isGiven = itemManagerScript.giveItem(itemIndex);
        if (isGiven)
        {
            if (transform.parent.name == "StorePanel")
            {
                transform.parent.gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
