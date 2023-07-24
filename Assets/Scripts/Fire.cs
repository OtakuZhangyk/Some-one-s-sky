using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float timeBetweenFires;
    float lastFire = 0.0f;
    CharacterController controller;

    void SpawnBullet(float angle, Vector3 direction)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, angle));
        
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.direction = direction;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        lastFire += Time.deltaTime;

        

        // Always face mouse cursor
        // Get the mouse position in world coordinates
        Vector3 LookAtPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Make sure the z position is the same as the sprite
        LookAtPosition.z = transform.position.z;

        // Calculate the direction from the sprite to the mouse
        Vector3 direction = LookAtPosition - transform.position;

        // Calculate the angle of the direction vector,
        // subtract 90 degrees because the sprite is facing up
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        // Set the z rotation of the sprite to this angle
        //transform.rotation = Quaternion.Euler(0, 0, angle);

        if (Input.GetButton("Fire1") && lastFire >= timeBetweenFires)
        {
            SpawnBullet(angle, direction);
            lastFire = 0.0f;
        }
    }
}
