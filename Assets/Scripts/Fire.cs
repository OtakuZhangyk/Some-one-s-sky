using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float timeBetweenFires;
    float lastFire = 0.0f;
    CharacterController controller;

    void SpawnBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.direction = new Vector3(0.0f, 1.0f, 0.0f);
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

        if (Input.GetButton("Fire1") && lastFire >= timeBetweenFires)
        {
            SpawnBullet();
            lastFire = 0.0f;
        }
    }
}
