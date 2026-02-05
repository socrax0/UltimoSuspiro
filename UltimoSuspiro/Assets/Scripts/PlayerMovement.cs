using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerManager PlayerManager;

    public float PlayerDir;

    public float LastPlayerDir = 1;

    private Rigidbody2D rb;

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
        PlayerManager = GetComponent<PlayerManager>();
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
        PlayerDir = Input.GetAxisRaw("Horizontal");
        if (PlayerDir != 0) {
            LastPlayerDir = PlayerDir;
        }

        GetComponent<SpriteRenderer>().flipX = LastPlayerDir < 0;
        transform.position = transform.position + PlayerManager.playerSpeed * Time.deltaTime * new Vector3(PlayerDir, 0, 0);

        //Jump
        if (_isGrounded && Input.GetButton("Jump"))
        {
            rb.AddForceY(PlayerManager.playerJump);
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
