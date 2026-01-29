using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;
    // variables concerning Player interactions
    [SerializeField] 
    private GameObject player;

    private Vector3 playerPos;

    private Vector3 playerDistance;

    private float playerHealth;

    [SerializeField]
    private float playerMaxDistance;

    // enemy variables SPEED HEALTH DAMAGE

    public float enemyDefaultSpeed = 1f;

    private float enemySpeed;

    public float enemyHealth;

    public float enemyDamage;

    // Update is called once per frame
    void Update()
    {
        playerPos = player.GetComponent<Transform>().position;
        playerDistance = playerPos - transform.position;
        playerHealth = player.GetComponent<PlayerManager>().playerHealth;

        EnemyMovement();
        EnemyAttack();
    }

    void EnemyMovement()
    {
        transform.position = transform.position + enemySpeed * Time.deltaTime * playerDistance.normalized;
    }

    void EnemyAttack()
    {
        if (playerDistance.x < playerMaxDistance && playerDistance.x > -playerMaxDistance)
        {
            enemySpeed = 0;
            playerHealth = player.GetComponent<PlayerManager>().playerHealth;
        }
        else
        {
            enemySpeed = enemyDefaultSpeed;
        }
        
    }

    public void TakeDamage(float playerDamage)
    {
        enemyHealth -= playerDamage * Time.deltaTime;
        Debug.Log(enemyHealth);

        if (enemyHealth <= 0)
        {
            enemyDamage = 0;
            enemy.GetComponent<SpriteRenderer>().color = Color.red;
            Destroy(gameObject, .5f);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, playerMaxDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, playerMaxDistance);
    }
}
