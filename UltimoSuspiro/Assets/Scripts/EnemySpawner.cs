using NUnit.Framework.Internal;
using System.Threading;
using System.Timers;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform spawnPosLeft;
    public Transform spawnPosRight;

    public int totalEnemies;
    
    public float spawnDelay;
    public float sD = 0;

    [SerializeField]
    public GameObject[] enemies;

    private void FixedUpdate()
    {
        if (totalEnemies > 0)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
            foreach (GameObject enemy in enemies)
            {
                sD += Time.deltaTime;
                if (sD > spawnDelay)
                {
                    Debug.Log(enemy.name);
                    Instantiate(enemy, spawnPosLeft.position, Quaternion.identity);
                    totalEnemies--;
                    sD = 0;
                
                }
            }
        }
        
    }
