using System;
using UnityEngine;
using UnityEngine.InputSystem.XInput;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    private Rigidbody2D rb;
    private Animator anim;

    private float xInput;
    private int facingDir = 1;
    private bool facingRight = true;

    [Header("Collosion info")]
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask whatIsGround;
    private bool isGrounded;

    [Header("Dash info")]
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashDuration;
    [SerializeField] private float dashCooldown;
    private float dashTime;
    private float dashCooldownTimer;

    [Header("Attack info")]
    [SerializeField] private float comboTime = 0.3f;
    private bool isAttacking;
    private int comboCounter;
    private float comboTimeCounter;

    private bool isDashAttack;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        CheckCollision();
        CheckInput();
        Movement();
        
        dashTime -= Time.deltaTime;
        dashCooldownTimer -= Time.deltaTime;
        comboTimeCounter -= Time.deltaTime;

        FlipControl();
        AnimationControl();
    }

    private void AnimationControl()
    {
        bool isMoving = rb.linearVelocityX != 0;

        anim.SetFloat("yVelocity", rb.linearVelocityY);

        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isDash", dashTime > 0);
        anim.SetBool("isAttacking", isAttacking);
        anim.SetInteger("comboCounter", comboCounter);
        anim.SetBool("isDashAttack", isDashAttack);
    }

    private void CheckInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            DashAbility();
        }
        
        if (dashTime > 0 && Input.GetKeyDown(KeyCode.Mouse0))
        {
            isDashAttack = true;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && isGrounded)
        {
            Attack();
        }
    }

    private void Movement()
    {
        if (isAttacking)
        { 
            rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
        }
        else if (isDashAttack)
        {
            rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
        }
        else if (dashTime > 0)
        {
            rb.linearVelocity = new Vector2(facingDir * dashSpeed, 0f);
        }
        else
        { 
            rb.linearVelocity = new Vector2(xInput * moveSpeed, rb.linearVelocity.y);
        }
        
    }

    private void CheckCollision()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, whatIsGround);
    }

    private void Jump()
    {
        if (isGrounded)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    private void DashAbility()
    {
        AttackOver();

        if (dashCooldownTimer < 0)
        {
            dashTime = dashDuration;
            dashCooldownTimer = dashCooldown;
        }
    }

    private void Attack()
    {
        if (comboTimeCounter < 0)
            comboCounter = 0;

        isAttacking = true;
        comboTimeCounter = comboTime;
    }

    public void AttackOver()
    {
        //if (!isGrounded)
        //    return;

        isAttacking = false;

        comboCounter++;

        if (comboCounter > 1)
            comboCounter = 0;
    }

    public void DashAttackOver()
    {
        isDashAttack = false;
    }

    private void FlipControl()
    {
        if (rb.linearVelocityX > 0 && !facingRight)
            Flip();
        else if (rb.linearVelocityX < 0 && facingRight)
            Flip();
    }

    private void Flip()
    {
        facingDir *= -1;
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
    }




    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - groundCheckDistance));
    }
}
