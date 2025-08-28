using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 PlayerDir;

    public int PlayerSpeed;

    private Rigidbody2D rb;

    [SerializeField]
    private bool isGrounded;

    public int PlayerJumpForce;

    public Transform GroundCheck1;

    public LayerMask groundLayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMov();
    }

    void PlayerMov()
    {   
        //Horizontal
        PlayerDir = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position = transform.position + PlayerDir * PlayerSpeed * Time.deltaTime;

        //Jump

        isGrounded = Physics2D.OverlapCircle(GroundCheck1.position, 0.15f, groundLayer); // checks if you are within 0.15 position in the Y of the ground 

        if (isGrounded)
        {
            if (Input.GetButton("Jump"))
            {
                rb.AddForceY(PlayerJumpForce);
            }
        } 
    }

}
