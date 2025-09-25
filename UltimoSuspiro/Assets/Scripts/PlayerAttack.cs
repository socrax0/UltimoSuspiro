using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;

    private float LastPlayerDir = 1;

    public float damage;

    [SerializeField]
    private Vector3 _hitDistance;

    [SerializeField]
    private Vector2 _hitArea;

    [SerializeField]
    private LayerMask _enemyLayer;


    // Update is called once per frame
    void FixedUpdate()
    {
        BasicAttack();
        LastPlayerDir = Player.GetComponent<PlayerMovement>().LastPlayerDir;

    }

    public void BasicAttack()
    {
        if (Input.GetButton("BasicAttack"))
        {
            Debug.Log("Ataque básico");
            
        }
    }

    public void Hit()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(transform.position + _hitDistance * LastPlayerDir, _hitArea,0,_enemyLayer);
        
    }

    private void OnDrawGizmos()
    {
        // Define cor do gizmo (usar apenas cores padrao RGB para evitar Unicode)
        Gizmos.color = new Color(125f,0f,0f); // equivalente a "dark orange"

        Gizmos.DrawWireCube(transform.position + _hitDistance * LastPlayerDir, _hitArea);

    }
}
