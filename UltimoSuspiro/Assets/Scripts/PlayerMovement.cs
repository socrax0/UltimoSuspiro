using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 PlayerDir;

    public int PlayerSpeed;

    private BoxCollider2D groundCheck;

    private Rigidbody2D rb;

    private bool isGrounded;

    [SerializeField]
    public int PlayerJumpForce;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCheck = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMov();
        Debug.Log(groundCheck.IsTouchingLayers(3));

    }

    void PlayerMov()
    {   
        //Horizontal
        PlayerDir = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position = transform.position + PlayerDir * PlayerSpeed * Time.deltaTime;

        //Jump
        isGrounded = groundCheck.IsTouchingLayers(3);

        if (isGrounded)
        {
            if (Input.GetButton("Jump"))
            {
                rb.AddForceY(PlayerJumpForce);
            }
        } 
    }

}
