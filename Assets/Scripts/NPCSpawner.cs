using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Tells Random to use the Unity Engine random number generator.
using Random = UnityEngine.Random;

public class NPCSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject alienPrefab;
    public GameObject gameManager;
    public GameObject DialoguePanel;
    public float spawnRadius = 80f;
    public float safeRadius = 10f;
    public float despawnRadius = 120f;

    public int maxEnemies = 50;
    public int maxAliens = 3;

    public float alienRatio = 0.05f;

    // spawn enemy cost spawn points, points recovers every second
    public float spawnPoint = 1000f;
    public float enemyCost = 10f;
    public float alienCost = 50f;
    public float spawnPointRecovery = 1f;

    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnPoint += spawnPointRecovery * Time.deltaTime;
        SpawnNPCs();
        DespawnNPCs();
        timer += Time.deltaTime;
        if (timer >= 60.0f)
        {
            spawnPointRecovery += 1f;
            timer = 0;
        }
    }

    void SpawnNPCs()
    {
        // Get a random spawn position
        Vector3 spawnPosition = Random.insideUnitSphere * spawnRadius;
        spawnPosition.z = 0; 

        // Don't spawn enemies too close to the player
        if (spawnPosition.magnitude < safeRadius) return;
        
        // spawn enemy
        if (Random.value > alienRatio)
        {
            // if there is not enough spawn point, dont spawn
            if (spawnPoint < enemyCost) return;

            
            
            // if there is too many enemy, dont spawn
            if (GameObject.FindGameObjectsWithTag("Enemy").Length >= maxEnemies) return;
            
            


            // Get a random rotation
            Quaternion randomRotation = Quaternion.Euler(0,0,Random.Range(0, 360));
            // Instantiate the enemy at the spawn position
            GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPosition + transform.position, randomRotation);

            LookAtMouse LookAtMouseScript = spawnedEnemy.GetComponent<LookAtMouse>();
            LookAtMouseScript.Prefab2LookAt = gameObject;

            Enemy EnemyScript = spawnedEnemy.GetComponent<Enemy>();
            EnemyScript.player = gameObject;
            EnemyScript.gameManager = gameManager;
            /*EnemyScript.heal = 100;
            EnemyScript.damage = 5;
            EnemyScript.attackSpeed = 1;
            EnemyScript.bulletSpeed = 10;
            EnemyScript.speed = 3;
            EnemyScript.alartDistance = 8;
            EnemyScript.keepDistance = 4;*/

            spawnPoint -= enemyCost;
        }
        else
        {
            //spawn alien
            // if there is not enough spawn point, dont spawn
            if (spawnPoint < alienCost) return;

            // if there is too many enemy, dont spawn
            if (GameObject.FindGameObjectsWithTag("Alien").Length >= maxAliens) return;
            
            


            // Get a random rotation
            Quaternion randomRotation = Quaternion.Euler(0,0,Random.Range(0, 360));
            // Instantiate the enemy at the spawn position
            GameObject spawnedAlien = Instantiate(alienPrefab, spawnPosition + transform.position, randomRotation);

            LookAtMouse LookAtMouseScript = spawnedAlien.GetComponent<LookAtMouse>();
            LookAtMouseScript.Prefab2LookAt = gameObject;

            Alien AlienScript = spawnedAlien.GetComponent<Alien>();
            AlienScript.player = gameObject;
            AlienScript.gameManager = gameManager;

            KeyE KeyEScript = spawnedAlien.GetComponentInChildren<KeyE>(true);
            KeyEScript.dialoguePanel = DialoguePanel;

            spawnPoint -= alienCost;
        }
    }


    void DespawnNPCs()
    {
        // Get all enemies in the scene
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            // Despawn if too far from the player
            if ((enemy.transform.position - transform.position).magnitude > despawnRadius)
            {
                Destroy(enemy);
                spawnPoint += enemyCost;
            }
        }

        // Get all aliens in the scene
        GameObject[] aliens = GameObject.FindGameObjectsWithTag("Alien");
        foreach (GameObject alien in aliens)
        {
            // Despawn if too far from the player
            if ((alien.transform.position - transform.position).magnitude > despawnRadius)
            {
                Destroy(alien);
                spawnPoint += alienCost;
            }
        }
    }


}
