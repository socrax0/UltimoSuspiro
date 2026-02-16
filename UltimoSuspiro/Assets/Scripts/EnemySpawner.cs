using NUnit.Framework.Internal;
using System.Threading;
using System.Timers;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform spawnPosLeft;
    public Transform spawnPosRight;

    public int totalEnemies;
    
    public float spawnDelay;
    public float sD;

    [SerializeField]
    public GameObject[] enemies;

    private void Update()
    {
        if (totalEnemies > 0)
        {
            SpawnEnemy();
        }
        else
        {
            Debug.Log("Todos os inimigos foram spawnados");
        }

    }

    void SpawnEnemy()
    {
        sD += Time.deltaTime;
        if (sD > spawnDelay)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                //Vector3 spwPos = new Vector3(Random.Range(-1, 2), -.5f, 0);
                Instantiate(enemies[i], spawnPosRight.position, Quaternion.identity);
            }
            totalEnemies--;
            sD = 0;
        }
        
    }

}
