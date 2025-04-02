using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float moveSpeed;

    private Rigidbody2D rb;
    private Animator anim;

    private float xInput;
    private int facingDir = 1;
    private bool facingRight = true;

    [Header("Collision info")]
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask whatIsGround;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        CheckInput();
        Movement();
        CheckCollision();

        FlipController();
        AnimatorControllers();
    }

    private void CheckCollision()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, whatIsGround);
    }

    private void CheckInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    private void Movement()
    {
        rb.linearVelocity = new Vector2(xInput * moveSpeed, rb.linearVelocityY);
    }

    private void Jump()
    {
        if (isGrounded)
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce);
    }

    private void AnimatorControllers()
    { 
        bool isMoving = rb.linearVelocity.x != 0;

        anim.SetBool("isMoving", isMoving);
    }

    private void Flip()
    { 
        facingDir *= -1;
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    private void FlipController()
    {
        if (rb.linearVelocityX > 0 && !facingRight)
            Flip();
        else if (rb.linearVelocityX < 0 && facingRight)
            Flip();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - groundCheckDistance));
    }
}
