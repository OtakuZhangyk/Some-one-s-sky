using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAlienProfile : MonoBehaviour
{
    public GameObject alienProfilePanel;
    private bool neverMetAlien;
    // Start is called before the first frame update
    void Start()
    {
        neverMetAlien = true;
    }

    public void ShowProfile()
    {
        if (neverMetAlien)
        {
            alienProfilePanel.SetActive(true);
            neverMetAlien = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
