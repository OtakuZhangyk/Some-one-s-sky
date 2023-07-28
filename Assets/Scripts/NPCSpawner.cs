using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Tells Random to use the Unity Engine random number generator.
using Random = UnityEngine.Random;

public class NPCSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject gameManager;
    public float spawnRadius = 80f;
    public float safeRadius = 12f;
    public float despawnRadius = 120f;

    public int maxEnemies = 10;

    // spawn enemy cost spawn points, points recovers every second
    public float spawnPoint = 100f;
    public float enemyCost = 10f;
    public float spawnPointRecovery = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnPoint += spawnPointRecovery * Time.deltaTime;
        SpawnEnemies();
        DespawnEnemies();
    }

    void SpawnEnemies()
    {
        // Get a random spawn position
        Vector3 spawnPosition = Random.insideUnitSphere * spawnRadius;
        spawnPosition.z = 0; 

        // Don't spawn enemies too close to the player
        if ((spawnPosition - transform.position).magnitude < safeRadius) return;
        
        // if there is not enough spawn point, dont spawn
        if (spawnPoint < enemyCost) return;

        // if there is too many enemy, dont spawn
        if (GameObject.FindGameObjectsWithTag("Enemy").Length >= maxEnemies) return;
        
        spawnPoint -= enemyCost;

        // Get a random rotation
        Quaternion randomRotation = Quaternion.Euler(0,0,Random.Range(0, 360));
        // Instantiate the enemy at the spawn position
        GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPosition, randomRotation);

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
    }

    void DespawnEnemies()
    {
        // Get all enemies in the scene
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            // Despawn if too far from the player
            if ((enemy.transform.position - transform.position).magnitude > despawnRadius)
            {
                Destroy(enemy);
            }
        }
    }


}
