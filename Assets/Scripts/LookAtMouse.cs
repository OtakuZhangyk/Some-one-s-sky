using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    public GameObject Prefab2LookAt; // null = look at mouse cursor
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Prefab2LookAt == null)
        {
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
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else
        {
            Vector3 LookAtPosition = Prefab2LookAt.transform.position;
            // Make sure the z position is the same as the sprite
            LookAtPosition.z = transform.position.z;

            // Calculate the direction from the sprite to the mouse
            Vector3 direction = LookAtPosition - transform.position;

            // Calculate the angle of the direction vector,
            // subtract 90 degrees because the sprite is facing up
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

            // Set the z rotation of the sprite to this angle
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
