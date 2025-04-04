using UnityEngine;

public class Skeleton : Entity
{
    [Header("Move info")]
    [SerializeField] private float moveSpeed;
    private float chaseSpeed;

    [Header("Player detection")]
    [SerializeField] private float playerCheckDistance;
    [SerializeField] private LayerMask whatIsPlayer;

    private RaycastHit2D isPlayerDetected;

    private bool isAttacking;

    protected override void Start()
    {
        base.Start();
        chaseSpeed = 1f;
    }

    protected override void Update()
    {
        base.Update();

        if (isPlayerDetected)
        { 
            if (isPlayerDetected.distance > 1)
            {
                chaseSpeed = 1.5f;
                //rb.linearVelocity = new Vector2(moveSpeed * 1.5f * facingDir, rb.linearVelocityY);
                Debug.Log("Player detected");
            }
            else
            {
                Debug.Log("공격!" + isPlayerDetected.collider.gameObject.name);
                isAttacking = true;
            }
        }
        else
        {
            chaseSpeed = 1f;
            isAttacking = false;
        }

        if (!isGrounded || isWallDetected)
            Flip();

        Movement();
    }

    private void Movement()
    {
        rb.linearVelocity = new Vector2(moveSpeed * chaseSpeed * facingDir, rb.linearVelocityY);
    }

    protected override void CheckCollision()
    {
        base.CheckCollision();

        isPlayerDetected = Physics2D.Raycast(transform.position, Vector2.right, playerCheckDistance * facingDir, whatIsPlayer);
    }

    protected override void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + playerCheckDistance * facingDir, transform.position.y));
    }
}