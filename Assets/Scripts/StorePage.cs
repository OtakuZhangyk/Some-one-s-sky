using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorePage : MonoBehaviour
{
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
    }

    void OnDisable()
    {
        ResumeGame();
    }

    public void OnClick_ReturnButton()
    {
        gameObject.SetActive(false);
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
