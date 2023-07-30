using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alien : MonoBehaviour
{
    //public Camera playerCamera;
    //private SpriteRenderer spriteRenderer;
    public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        //spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        /*Vector3 screenPoint = playerCamera.WorldToViewportPoint(transform.position);
        bool onScreen = screenPoint.x >= 0 && screenPoint.x <= 1 && screenPoint.y >= 0 && screenPoint.y <= 1;
        if(onScreen)
        {
            Debug.Log("Object is in player's field of view");
        }
        else
        {
            // The object is not in the player's field of view
            Debug.Log("Object is not in player's field of view");
        }*/
    }

    /*
    void OnBecameInvisible()
    {
        Debug.Log("Object is not in player's field of view");
    }
    */


    void OnBecameVisible()
    {
        //Debug.Log("Object is in player's field of view");
        gameManager.GetComponent<ShowAlienProfile>().ShowProfile();
    }
}
