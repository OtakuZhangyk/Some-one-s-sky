using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienProfilePanel : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            gameObject.SetActive(false);
        }
    }
}
