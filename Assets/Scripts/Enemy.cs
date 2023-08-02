using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Tells Random to use the Unity Engine random number generator.
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public GameObject gameManager;
    
    public int gold;
    public float rate;//random rate give random item
    public float heal;
    public float damage;
    public float attackSpeed;
    public float bulletSpeed;
    public float speed;
    public float alartDistance;
    public float keepDistance;
    //public Vector3 moving_direction;
    
    private float xSpeed;
    private bool foundPlayer;
    private float backSpeed;

    
    // Start is called before the first frame update
    void Start()
    {
        xSpeed = Random.Range(-4,5) * speed * 0.25f;
        if (xSpeed == 0.0f)
            xSpeed = speed * 0.25f;
        foundPlayer = false;
        backSpeed = -0.25f * speed;
        Debug.Log(heal);
    }
    
    // Update is called once per frame
    void Update()
    {
        // calculate distance between self and player
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (!foundPlayer)
        {
            // move to y+
            transform.Translate(new Vector3(0.0f, speed, 0.0f) * Time.deltaTime);

            // enemy found player
            if(distance < alartDistance)
            {
                foundPlayer = true;
                LookAtMouse LookAtScript = GetComponent<LookAtMouse>();
                LookAtScript.enabled = true;
                // keep firing script enabled
                Fire FireScript = GetComponent<Fire>();
                FireScript.enabled = true;
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

    public void DecreaseHealth(float amountOfDamage)
    {
        heal -= amountOfDamage;
        Debug.Log(heal);
        // died
        if (heal <= 0)
        {
            Destroy(gameObject);
            
            // random drop rate, TBD

            // call roll item
            ItemManager itemManagerScript = gameManager.GetComponent<ItemManager>();
            itemManagerScript.rollItems();
            float resourceMultiply = player.GetComponent<Attributes>().GetResourceMultiple();
            Debug.Log("resourceMultiple = "+resourceMultiply);
            // give gold
            player.GetComponent<Attributes>().GiveGold((int)(gold * resourceMultiply));
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
