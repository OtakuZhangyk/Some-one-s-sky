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
    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            // show panel
            //Debug.Log("Interacting with KeyE");
            dialoguePanel.SetActive(true);
        }
    }
    

    void LateUpdate()
    {
        // Keep the child object's rotation fixed at Quaternion.identity (no rotation)
        transform.rotation = Quaternion.identity;
    }
}
