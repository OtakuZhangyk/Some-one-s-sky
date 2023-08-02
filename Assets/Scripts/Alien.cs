using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    //public Camera playerCamera;
    //private SpriteRenderer spriteRenderer;
    public GameObject player;
    public GameObject gameManager;

    public float HP;
    public float speed;
    public float showKeyEDistance;

    public int gold;
    public float rate;//random rate give random item
    public float damage;
    public float attackSpeed;
    public float bulletSpeed;
    public float keepDistance;

    private float xSpeed;
    private float backSpeed;

    private GameObject childKeyE;
    private int friendly;
    // Start is called before the first frame update
    void Start()
    {
        //spriteRenderer = GetComponent<SpriteRenderer>();
        childKeyE = transform.GetChild(0).gameObject;
        friendly = 5;

        xSpeed = Random.Range(-4,5) * speed * 0.25f;
        if (xSpeed == 0.0f)
            xSpeed = speed * 0.25f;
        backSpeed = -0.25f * speed;
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
        if (friendly > 0)
        {
            // move to y+
            transform.Translate(new Vector3(0.0f, 0.5f * speed, 0.0f) * Time.deltaTime);
            if (!childKeyE.activeSelf)
            {
                // move to y+
                //transform.Translate(new Vector3(0.0f, speed, 0.0f) * Time.deltaTime);

                // show keyE
                if(distance < showKeyEDistance)
                {
                    childKeyE.SetActive(true);
                }
            }
            else
            {
                // move to y+
                //transform.Translate(new Vector3(0.0f, speed, 0.0f) * Time.deltaTime);
                // hide keyE
                if(distance > showKeyEDistance + 0.5f)
                {
                    childKeyE.SetActive(false);
                }
            }
        }
        else
        {
            // enemy move to player
            if (distance > keepDistance + 1)
            {
                transform.Translate(new Vector3(0.0f, speed, 0.0f) * Time.deltaTime);
                //Debug.Log("closer");
            }
            // enemy move to its left or right
            else if (distance <= keepDistance + 1 && distance >= keepDistance - 1)
            {
                transform.Translate(new Vector3(xSpeed, 0.0f, 0.0f) * Time.deltaTime);
                //Debug.Log("keep");
            }
            // enemy try to get away from player
            else if (distance < keepDistance - 1)
            {
                transform.Translate(new Vector3(xSpeed, backSpeed, 0.0f) * Time.deltaTime);
                //Debug.Log("away");
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
        HP -= amountOfDamage;
        Debug.Log(HP);
        if (HP <= 0)
        {
            Destroy(gameObject);
            
            // random drop rate, TBD

            // random drop rate, TBD
            if (Random.value < rate)
            {
                // call roll item
                ItemManager itemManagerScript = gameManager.GetComponent<ItemManager>();
                itemManagerScript.rollItems();
            }
            float resourceMultiply = player.GetComponent<Attributes>().GetResourceMultiple();
            Debug.Log("resourceMultiple = "+resourceMultiply);
            // give gold
            player.GetComponent<Attributes>().GiveGold((int)(gold * resourceMultiply));
        }
        if (owner == "Player")
        {
            friendly -= 1;
            if (friendly <= 0)
            {
                LookAtMouse LookAtScript = GetComponent<LookAtMouse>();
                LookAtScript.enabled = true;
                // keep firing script enabled
                Fire FireScript = GetComponent<Fire>();
                FireScript.enabled = true;
                // hide key E
                childKeyE.SetActive(false);
            }
        }
    }
}
