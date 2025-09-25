using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;

    public float damage;

    [SerializeField]
    private Transform _hitPosition;

    [SerializeField]
    private Vector2 _hitArea;

    [SerializeField]
    private LayerMask _enemyLayer;


    // Update is called once per frame
    void FixedUpdate()
    {
        BasicAttack();
        
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
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(_hitPosition.position,_hitArea,0,_enemyLayer);
        foreach (Collider2D hitEnemy in hitEnemies)
        {
            Debug.Log(hitEnemy.gameObject.GetComponent<Transform>());
        }
    }

    private void OnDrawGizmos()
    {
        // Define cor do gizmo (usar apenas cores padrao RGB para evitar Unicode)
        Gizmos.color = new Color(1f, 0.55f, 0f); // equivalente a "dark orange"

        // Desenha o circulo representando o alcance do ataque
        if (_hitPosition != null)
        {
            Gizmos.DrawWireCube(_hitPosition.position, _hitArea);
        }
    }
}
