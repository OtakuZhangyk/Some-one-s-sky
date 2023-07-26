using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemButton : MonoBehaviour
{
    public int itemIndex;
    public GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void onChoseItem()
    {
        itemManager itemManager = gameManager.GetComponent<itemManager>();
        itemManager.giveItem(itemIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
