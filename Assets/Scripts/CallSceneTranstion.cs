using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallSceneTranstion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CallFadeAndLoadScene(string sceneName)
    {
        SceneTransitionManager.Instance.FadeAndLoadScene(sceneName);
    }

}
