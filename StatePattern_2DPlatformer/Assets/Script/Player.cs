using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : Entity
{
    [Header("Move info")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float moveSpeed;

    private float xInput;

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
    
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        CheckInput();
        Movement();

        dashTime -= Time.deltaTime;
        dashCooldownTimer -= Time.deltaTime;
        comboTimeCounter -= Time.deltaTime;

        FlipController();
        AnimatorControllers();
    }

    private void CheckInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Mouse0) && isGrounded)
        {
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            DashAbility();
        }
    }

    private void AnimatorControllers()
    {
        bool isMoving = rb.linearVelocity.x != 0;

        anim.SetFloat("yVelocity", rb.linearVelocityY);

        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isDash", dashTime > 0);
        anim.SetBool("isAttacking", isAttacking);
        anim.SetInteger("comboCounter", comboCounter);
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

        if (comboCounter > 2)
            comboCounter = 0;
    }

    private void Jump()
    {
        if (isGrounded)
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce);
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

    private void Movement()
    {
        if (isAttacking)
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }
        else if (dashTime > 0)
        {
            rb.linearVelocity = new Vector2(facingDir * dashSpeed, 0);
        }
        else
        {
            rb.linearVelocity = new Vector2(xInput * moveSpeed, rb.linearVelocity.y);
        }
    }
}
