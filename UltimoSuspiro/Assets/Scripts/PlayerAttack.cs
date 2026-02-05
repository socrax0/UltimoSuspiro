using System.Timers;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAttack : MonoBehaviour
{
    private float lastPlayerDir = 1;

    [SerializeField]
    private Vector3 hitDistance;

    [SerializeField]
    private Vector2 hitArea;
    
    public Vector2 hitboxPosition;

    [SerializeField]
    private LayerMask enemyLayer;

    void FixedUpdate()
    {
        BasicAttack();
        lastPlayerDir = this.GetComponent<PlayerMovement>().LastPlayerDir;
    }

    public void BasicAttack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(transform.position + hitDistance * lastPlayerDir, hitArea, 0, enemyLayer);

        foreach (Collider2D hitEnemy in hitEnemies)
        {
            //Debug.Log(hitEnemy);   
            hitEnemy.gameObject.GetComponent<EnemyBehaviour>().TakeDamage(this.GetComponent<PlayerManager>().playerDamage);
        }
    }
    private void OnDrawGizmos()
    {
        // Define cor do gizmo (usar apenas cores padrao RGB para evitar Unicode)
        Gizmos.color = new Color(125f,0f,0f); // equivalente a "dark orange"

        Gizmos.DrawWireCube(transform.position + hitDistance * lastPlayerDir, hitArea);

    }
}
