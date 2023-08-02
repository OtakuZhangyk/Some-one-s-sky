using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    public TMP_Text nameText;
    public TMP_Text sentenceText;
    public GameObject StorePanel;

    private int currentDialogueIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentDialogueIndex = 0;
        nameText.text = dialogueTree[currentDialogueIndex].name;
        sentenceText.text = dialogueTree[currentDialogueIndex].sentence;
    }

    ///////////////////////
    // exit dialogue TBD //
    ///////////////////////
    void UpdateDialogue(int jumpTo = 0)
    {
        if (jumpTo == -1)
        {
            gameObject.SetActive(false);
            StorePanel.SetActive(true);
        }
        else if (jumpTo == 0)
        {
            currentDialogueIndex++;
        }
        else
        {
            currentDialogueIndex = jumpTo;
        }
        nameText.text = dialogueTree[currentDialogueIndex].name;
        sentenceText.text = dialogueTree[currentDialogueIndex].sentence;
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
            UpdateDialogue(dialogueTree[currentDialogueIndex].jumpTo);
        }
    }
}
