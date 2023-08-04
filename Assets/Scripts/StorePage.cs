using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StorePage : MonoBehaviour
{
    public TMP_Text refreshCostText;
    public GameObject gameManager;
    public Attributes atttributesScript;

    private int refreshCost;
    // Start is called before the first frame update
    void Start()
    {
        
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
        refreshCost = 50;
        refreshCostText.text = refreshCost.ToString();
        gameManager.GetComponent<ItemManager>().rollItems(true);
    }

    void OnDisable()
    {
        ResumeGame();
    }

    public void OnClick_ReturnButton()
    {
        gameObject.SetActive(false);
    }

    public void OnClick_RefreshButton()
    {
        if (atttributesScript.gold >= refreshCost)
        {
            atttributesScript.gold -= refreshCost;
            refreshCost *= 2;
            refreshCostText.text = refreshCost.ToString();
            gameManager.GetComponent<ItemManager>().rollItems(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
        }
    }
}
