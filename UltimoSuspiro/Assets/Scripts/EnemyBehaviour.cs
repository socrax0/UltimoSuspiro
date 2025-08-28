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

    [SerializeField]
    private int speed;

    // Update is called once per frame
    void Update()
    {
        PlayerPos = Player.GetComponent<Transform>().position;
        PlayerDistance = PlayerPos - transform.position;

        transform.position = transform.position + PlayerDistance.normalized * speed * Time.deltaTime;

        Debug.Log(transform.position);
        Debug.DrawLine(transform.position, new Vector3(PlayerMaxDistance,0,0));  
        
    }

    void EnemyAttack()
    {
        
        Debug.Log("Ataque ataque ataque");
    }
}
