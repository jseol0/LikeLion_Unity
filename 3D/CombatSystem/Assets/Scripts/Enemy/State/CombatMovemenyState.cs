using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public enum AICombatStates {  Idle, Chase, Circling}

public class CombatMovementState : State<EnemyController>
{
    [SerializeField] float circlingSpeed = 20f;
    [SerializeField] float distanceToStand = 3f;
    [SerializeField] float adjustDistanceThreshold = 1f;
    [SerializeField] Vector2 idleTimeRange = new Vector2(2, 5);
    [SerializeField] Vector2 circlingTimeRange = new Vector2(3, 6);

    float timer = 0f;
    int circlingDir;

    AICombatStates state;
    
    EnemyController enemy;

    public override void Enter(EnemyController owner)
    {
        enemy = owner;

        enemy.NavAgent.stoppingDistance = distanceToStand;
        enemy.combatMovementTimer = 0f;
    }

    public override void Execute()
    {

        if (Vector3.Distance(enemy.Target.transform.position, enemy.transform.position) > distanceToStand + adjustDistanceThreshold)
        {
            StartChase();
        }

        if (state == AICombatStates.Idle)
        {
            if (timer <= 0)
            {
                if (Random.Range(0, 2) == 0)
                {
                    StartIdle();
                }
                else
                {
                    StartCircleing();
                }
            }
        }
        else if (state == AICombatStates.Chase)
        {
            if (Vector3.Distance(enemy.Target.transform.position, enemy.transform.position) <= distanceToStand + 0.03f)
            {
                StartIdle();
                return;
            }
            enemy.NavAgent.SetDestination(enemy.Target.transform.position);
        }
        else if (state == AICombatStates.Circling)
        {
            if (timer <= 0)
            {
                StartIdle();
                return;
            }

            //transform.RotateAround(enemy.Target.transform.position, Vector3.up, circlingSpeed * circlingDir * Time.deltaTime);

            var vecToTarget = enemy.transform.position - enemy.Target.transform.position;
            var rotatePos = Quaternion.Euler(0, circlingSpeed * circlingDir * Time.deltaTime, 0) * vecToTarget;
            enemy.NavAgent.Move(rotatePos - vecToTarget);
            enemy.transform.rotation = Quaternion.LookRotation(-rotatePos);
        }

        //enemy.Anim.SetFloat("moveAmount", enemy.NavAgent.velocity.magnitude / enemy.NavAgent.speed);

        if (timer > 0f)
            timer -= Time.deltaTime;

        enemy.combatMovementTimer += Time.deltaTime;
    }

    void StartCircleing()
    {
        state = AICombatStates.Circling;
        timer = Random.Range(circlingTimeRange.x, circlingTimeRange.y);

        circlingDir = Random.Range(0, 2) == 0 ? 1 : -1;
    }

    void StartChase()
    {
        state = AICombatStates.Chase;
        enemy.Anim.SetBool("combatMode", false);
    }

    void StartIdle()
    {
        state = AICombatStates.Idle;
        timer = Random.Range(idleTimeRange.x, idleTimeRange.y);
        enemy.Anim.SetBool("combatMode", true);
    }

    public override void Exit()
    {
        enemy.combatMovementTimer = 0f;
    }
}