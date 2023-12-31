using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //public Vector3 direction;
    public float speed;
    public float damage;
    public string owner;
    //public AudioClip playerBulletTouchSound;
    //public AudioClip enemyBulletTouchSound;
    //public AudioClip alienBulletTouchSound;
    //private AudioSource audioSource;

    float lastSeconds = 10f;
    float timer = 0f;

    // hit detection
    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("Hit");
        if (!collider.gameObject.CompareTag(owner))
        {
            //Debug.Log("HitEnemy");
            // hit animation? audio? decrease HP?


            if (collider.gameObject.CompareTag("Bullet"))
            {
                return;
            }
            // destroy bullet
            Destroy(gameObject);

            if (!collider.gameObject.CompareTag("Bullet"))
            {

                if (owner == "Player")
                {
                    if (collider.gameObject.CompareTag("Enemy"))
                    {
                        // Access the Enemy script attached to the enemy game object
                        Enemy enemy = collider.gameObject.GetComponent<Enemy>();

                        // Call the method to decrease health
                        enemy.DecreaseHealth(damage); // 10 or any amount of health to decrease

                        //audioSource.clip = playerBulletTouchSound;
                        //audioSource.Play();
                    }
                    else if (collider.gameObject.CompareTag("Alien"))
                    {
                        // Access the Alien script attached to the enemy game object
                        Alien alien = collider.gameObject.GetComponent<Alien>();

                        // Call the method to decrease health
                        alien.DecreaseHealth(damage, owner); // 10 or any amount of health to decrease

                        //audioSource.clip = playerBulletTouchSound;
                        //audioSource.Play();
                    }
                }
                else if (owner == "Enemy")
                {
                    if (collider.gameObject.CompareTag("Player"))
                    {
                        Attributes AttributesScript = collider.gameObject.GetComponent<Attributes>();

                        AttributesScript.DecreaseHealth(damage); // 10 or any amount of health to decrease

                        //audioSource.clip = enemyBulletTouchSound;
                        //audioSource.Play();
                    }
                }
                else if (owner == "Alien")
                {
                    if (collider.gameObject.CompareTag("Player"))
                    {
                        Attributes AttributesScript = collider.gameObject.GetComponent<Attributes>();

                        AttributesScript.DecreaseHealth(damage); // 10 or any amount of health to decrease

                        //audioSource.clip = alienBulletTouchSound;
                        //audioSource.Play();
                    }
                }
            }

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0.0f, speed, 0.0f) * Time.deltaTime);
        timer += Time.deltaTime;
        if (timer >= lastSeconds)
        {
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        // Destroy the bullet when it is no longer visible
        Destroy(gameObject);
    }
}
