using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyE : MonoBehaviour
{
    public GameObject dialoguePanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame

    int meetingTimes = 0;//whether player met the alien or not
    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            // show panel
            //Debug.Log("Interacting with KeyE");
            dialoguePanel.SetActive(true);
            if (meetingTimes > 5)
            {
                dialoguePanel.GetComponent<DialoguePanel>().UpdateDialogue(6);
            }

            meetingTimes++;
        }
    }
    

    void LateUpdate()
    {
        // Keep the child object's rotation fixed at Quaternion.identity (no rotation)
        transform.rotation = Quaternion.identity;
    }
}
