using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    //public Camera playerCamera;
    //private SpriteRenderer spriteRenderer;
    public GameObject player;

    public float speed;
    public float alartDistance;

    private GameObject childKeyE;
    private bool foundPlayer;
    // Start is called before the first frame update
    void Start()
    {
        //spriteRenderer = GetComponent<SpriteRenderer>();
        childKeyE = transform.GetChild(0).gameObject;
        foundPlayer = false;
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
        // calculate distance between self and player
        float distance = Vector3.Distance(player.transform.position, transform.position);
        // move to y+
        transform.Translate(new Vector3(0.0f, speed, 0.0f) * Time.deltaTime);
        if (!foundPlayer)
        {
            // move to y+
            //transform.Translate(new Vector3(0.0f, speed, 0.0f) * Time.deltaTime);

            // enemy found player
            if(distance < alartDistance)
            {
                foundPlayer = true;
                childKeyE.SetActive(true);
            }
        }
        else
        {
            // move to y+
            //transform.Translate(new Vector3(0.0f, speed, 0.0f) * Time.deltaTime);
            if(distance > alartDistance + 0.5f)
            {
                foundPlayer = false;
                childKeyE.SetActive(false);
            }
        }
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
        player.GetComponent<ShowAlienProfile>().ShowProfile();
    }

    public void DecreaseHealth(float amountOfDamage, string owner)
    {
        heal -= amountOfDamage;
        Debug.Log(heal);
        if (heal <= 0)
        {
            Destroy(gameObject);
            
            // random drop rate, TBD

            // call roll item
            ItemManager itemManagerScript = gameManager.GetComponent<ItemManager>();
            itemManagerScript.rollItems();
        }
        if (!foundPlayer)
        {
            foundPlayer = true;
            LookAtMouse LookAtScript = GetComponent<LookAtMouse>();
            LookAtScript.enabled = true;
            // keep firing script enabled
            Fire FireScript = GetComponent<Fire>();
            FireScript.enabled = true;
        }
    }
}
