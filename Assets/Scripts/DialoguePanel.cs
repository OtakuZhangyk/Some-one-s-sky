using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueEntry
{
    public string name;
    public string sentence;
    public int jumpTo;
}

public class DialoguePanel : MonoBehaviour
{
    public List<DialogueEntry> dialogueTree = new List<DialogueEntry>();
    
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
        
    }
}
