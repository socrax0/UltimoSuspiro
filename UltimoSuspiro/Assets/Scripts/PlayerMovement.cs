using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // MOVEMENT VARIABLES
    public Vector3 PlayerDir;

    public float PlayerSpeed = 7;

    private RaycastHit2D groundCheck;

    private Rigidbody2D rb;

    // JUMP VARIABLES
    [SerializeField]
    private int PlayerJumpForce;

    private bool _isGrounded;

    [SerializeField]
    private Vector2 _groundCheckSize;

    [SerializeField]
    private LayerMask groundLayer;

    [SerializeField]
    private float _groundCheckDistance;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        IsGrounded();
        PlayerMov();

    }

    public void PlayerMov()
    {
        //Horizontal
        PlayerDir = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position = transform.position + PlayerDir * PlayerSpeed * Time.deltaTime;

        //Jump
        if (_isGrounded && Input.GetButton("Jump"))
        {
            rb.AddForceY(PlayerJumpForce);
        }
    }

    void IsGrounded()
    {
        RaycastHit2D groundCheck = Physics2D.BoxCast(transform.position, _groundCheckSize, 0, Vector2.down, _groundCheckDistance, groundLayer);

        _isGrounded = groundCheck.collider;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(
            transform.position - transform.up * _groundCheckDistance,
            Vector3.one * _groundCheckSize
        );
    }
}
