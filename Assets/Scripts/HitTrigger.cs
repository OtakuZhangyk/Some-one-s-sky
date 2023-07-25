using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("Hit");
        if (!collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("HitPlayer");
            // hit animation? audio? decrease HP?


            // destroy bullet
            Destroy(gameObject);
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
