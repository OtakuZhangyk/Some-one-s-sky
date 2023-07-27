using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //public Vector3 direction;
    public float speed;
    public float damage;
    public string owner;

    // hit detection
    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("Hit");
        if (!collider.gameObject.CompareTag(owner))
        {
            //Debug.Log("HitEnemy");
            // hit animation? audio? decrease HP?


            // destroy bullet
            Destroy(gameObject);

            if (!collider.gameObject.CompareTag("Bullet"))
            {

                if (owner == "Player")
                {
                    // Access the Enemy script attached to the enemy game object
                    Enemy enemy = collider.gameObject.GetComponent<Enemy>();

                    // Call the method to decrease health
                    enemy.DecreaseHealth(damage); // 10 or any amount of health to decrease
                }
                else if (owner == "Enemy")
                {
                    Attributes AttributesScript = collider.gameObject.GetComponent<Attributes>();

                    AttributesScript.DecreaseHealth(damage); // 10 or any amount of health to decrease
                }
            }
            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0.0f, speed, 0.0f) * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        // Destroy the bullet when it is no longer visible
        Destroy(gameObject);
    }
}
