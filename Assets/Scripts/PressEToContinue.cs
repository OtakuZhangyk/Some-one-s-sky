using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressEToContinue : MonoBehaviour
{
    public SceneTransitionManager sceneTransitionManager;
    public string nextSceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            sceneTransitionManager.FadeAndLoadScene(nextSceneName);
            this.enabled = false;
        }
    }

    
}
