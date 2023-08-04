using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public AudioClip shootSound;
    public AudioClip enemyShootSound;
    public AudioClip alienShootSound;
    private AudioSource audioSource;
    public float timeBetweenFires;
    float lastFire = 0.0f; // time between last fired and current
    //CharacterController controller;

    private float bulletSpeed;
    private float bulletDamage;
    private string owner;

    void SpawnBullet()//float angle, Vector3 direction)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);//Quaternion.Euler(0, 0, angle));
        if (owner == "Player")
        {
            Attributes AttributesScript = GetComponent<Attributes>();
            bulletSpeed = AttributesScript.GetBulletSpeed();
            bulletDamage = AttributesScript.GetDamage();
        }
        else if (owner == "Enemy")
        {
            Enemy EnemyScript = GetComponent<Enemy>();
            bulletSpeed = EnemyScript.bulletSpeed;
            bulletDamage = EnemyScript.damage;
        }
        else if (owner == "Alien")
        {
            Alien AlienScript = GetComponent<Alien>();
            bulletSpeed = AlienScript.bulletSpeed;
            bulletDamage = AlienScript.damage;
        }

        
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        //bulletScript.direction = direction;
        bulletScript.speed = bulletSpeed;
        bulletScript.damage = bulletDamage;
        bulletScript.owner = owner;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        //controller = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
        // determine the owner of the bullet by tag
        owner = gameObject.tag;
        if (owner == "Enemy")
        {
            Enemy EnemyScript = GetComponent<Enemy>();
            timeBetweenFires = 1.0f/EnemyScript.attackSpeed;
        }
        else if (owner == "Alien")
        {
            Alien AlienScript = GetComponent<Alien>();
            timeBetweenFires = 1.0f/AlienScript.attackSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        lastFire += Time.deltaTime;

        

        // Always face mouse cursor
        // Get the mouse position in world coordinates
        //Vector3 LookAtPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Make sure the z position is the same as the sprite
        //LookAtPosition.z = transform.position.z;

        // Calculate the direction from the sprite to the mouse
        //Vector3 direction = LookAtPosition - transform.position;

        // Calculate the angle of the direction vector,
        // subtract 90 degrees because the sprite is facing up
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        // Set the z rotation of the sprite to this angle
        //transform.rotation = Quaternion.Euler(0, 0, angle);
        if (owner == "Player")
        {
            if (Input.GetButton("Fire1") && lastFire >= timeBetweenFires)
            {
                SpawnBullet();//angle, direction);
                // play shooting sound
                audioSource.clip = shootSound;
                audioSource.Play();
                lastFire = 0.0f;
            }
        }
        else// if (owner == "Enemy")
        {
            if (lastFire >= timeBetweenFires)
            {
                SpawnBullet();

                lastFire = 0.0f;
                if(owner == "Enemy")
                {
                    audioSource.clip = enemyShootSound;
                    audioSource.Play();
                }
                else
                {
                    audioSource.clip = alienShootSound;
                    audioSource.Play();
                }
            }
        
        }
        
    }
}
