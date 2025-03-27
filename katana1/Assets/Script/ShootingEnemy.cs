using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    [Header("적 캐릭터 속성")]
    public float detectionRange = 10f;
    public float shootingInterval = 2f;
    public GameObject missilePerfab;

    [Header("참조 컴포넌트")]
    public Transform firePoint;
    private Transform player;
    private float shootTimer;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
        shootTimer = shootingInterval;
    }

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            spriteRenderer.flipX = (player.position.x < transform.position.x);

            shootTimer -= Time.deltaTime;

            if (shootTimer <= 0)
            {
                Shoot();
                shootTimer = shootingInterval;
            }
        }
    }

    void Shoot()
    {
        GameObject missile = Instantiate(missilePerfab, firePoint.position, Quaternion.identity);

        Vector2 direction = (player.position - firePoint.position).normalized;
        missile.GetComponent<EnemyMissile>().SetDirection(direction);
    }

    //디버깅용
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
