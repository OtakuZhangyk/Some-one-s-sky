using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressEToContinue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadNextScene()
    {
        // Get the current Scene
        Scene currentScene = SceneManager.GetActiveScene();

        // Get the index of the next Scene
        int nextSceneIndex = currentScene.buildIndex + 1;

        // Load the next Scene
        SceneManager.LoadScene(nextSceneIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            LoadNextScene();
        }
    }

    
}
