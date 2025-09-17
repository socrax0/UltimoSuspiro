using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyBehaviour : MonoBehaviour
{
    // variables concerning Player interactions
    [SerializeField] 
    private GameObject Player;

    private Vector3 PlayerPos;

    private Vector3 PlayerDistance;

    [SerializeField]
    private float PlayerMaxDistance;

    // enemy variables

    public int speed = 1;

    // Update is called once per frame
    void Update()
    {
        PlayerPos = Player.GetComponent<Transform>().position;
        PlayerDistance = PlayerPos - transform.position;

        EnemyMovement();
        EnemyAttack();  

    }

    void EnemyMovement()
    {
        transform.position = transform.position + PlayerDistance * speed * Time.deltaTime;
        
    }

    void EnemyAttack()
    {
        if (PlayerDistance.x < PlayerMaxDistance && PlayerDistance.x > -PlayerMaxDistance)
        {
            speed = 0;
            Debug.Log("Ataque ataque ataque");
        }
        else
        {
            speed = 1;
        }
        
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, PlayerMaxDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, PlayerMaxDistance);
    }
}
