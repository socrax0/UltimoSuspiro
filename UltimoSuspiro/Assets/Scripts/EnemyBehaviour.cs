using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyBehaviour : MonoBehaviour
{

    // variables concerning Player interactions
    [SerializeField] 
    private GameObject player;

    private Vector3 playerPos;

    private Vector3 playerDistance;

    [SerializeField]
    private float playerMaxDistance;

    // enemy variables SPEED HEALTH DAMAGE

    public float enemyDefaultSpeed = 1f;

    private float enemySpeed;

    public float enemyHealth;

    public float enemyDamage;

    public bool isEnemyDead = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        playerPos = player.GetComponent<Transform>().position;
        playerDistance = playerPos - transform.position;

        if (!isEnemyDead)
        {
            EnemyMovement();
            EnemyAttack();
        }
    }

    void EnemyMovement()
    {
        transform.position = transform.position + enemySpeed * Time.deltaTime * playerDistance.normalized;
    }

    void EnemyAttack()
    {
        if (playerDistance.x < playerMaxDistance && playerDistance.x > -playerMaxDistance)
        {
            player.GetComponent<PlayerManager>().isTakingDamage = true;
            player.GetComponent<PlayerManager>().OnTakingDamage(enemyDamage);
            enemySpeed = 0;
        }

        else
        {
            player.GetComponent<PlayerManager>().isTakingDamage = false;
            enemySpeed = enemyDefaultSpeed;
        }
    }

    public void TakeDamage(float playerDamage)
    {
        enemyHealth -= playerDamage * Time.deltaTime;
        //Debug.Log(enemyHealth);

        if (enemyHealth <= 0)
        {
            isEnemyDead = true;
            player.GetComponent<PlayerManager>().isTakingDamage = false;
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            Destroy(gameObject, .2f);
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
