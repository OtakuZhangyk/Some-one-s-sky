using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneAfterXSeconds : MonoBehaviour
{
    public float seconds;
    public string sceneName;

    private bool triggered = false;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= seconds && !triggered)
        {
            triggered = true;
            SceneTransitionManager.Instance.FadeAndLoadScene(sceneName);
        }
    }
}
