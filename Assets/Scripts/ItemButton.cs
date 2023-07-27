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
        itemManagerScript.giveItem(itemIndex);
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
    }

    void OnEnable()
    {
        PauseGame();
    }

    void OnDisable()
    {
        ResumeGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
