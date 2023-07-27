using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //public Vector3 direction;
    public float speed;

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
