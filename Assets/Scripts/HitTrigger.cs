using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("Hit");
        if (collider.gameObject.CompareTag("Enemy"))
        {
            //Debug.Log("HitEnemy");
            // hit animation? audio? decrease HP?


            // destroy bullet
            Destroy(gameObject);

            // Access the Enemy script attached to the enemy game object
            Enemy enemy = collider.gameObject.GetComponent<Enemy>();

            // Call the method to decrease health
            enemy.DecreaseHealth(10); // 10 or any amount of health to decrease
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
