using UnityEngine;

public class SkeletonBattleState : EnemyState
{
    private Enemy_Skeleton enemy;
    private Transform player;
    private int moveDir;

    public SkeletonBattleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Skeleton _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();

        player = GameObject.FindGameObjectWithTag("Player").transform;
        //player = enemy.IsPlayerDetected().collider.transform;
    }

    public override void Update()
    {
        base.Update();

        /*
        if (enemy.IsPlayerDetected())
        {
            if (enemy.IsPlayerDetected().distance < enemy.attackDistance)
            {
                if (CanAttack())
                    stateMachine.ChangeState(enemy.attackState);
                return;
            }
        }
        */

        RaycastHit2D hit = enemy.IsPlayerDetected();
        if (hit)
        {
            stateTimer = enemy.battleTime;

            if (hit.distance < enemy.attackDistance)
            {
                if (CanAttack())
                    stateMachine.ChangeState(enemy.attackState);
                return;
            }
        }
        else
        {
            if (stateTimer < 0 || Vector2.Distance(player.position, enemy.transform.position) > enemy.battleDistance)
                stateMachine.ChangeState(enemy.idleState);

        }

        if (player.position.x > enemy.transform.position.x)
            moveDir = 1;
        else if (player.position.x < enemy.transform.position.x)
            moveDir = -1;

        enemy.SetVelocity(enemy.moveSpeed * moveDir, rb.linearVelocityY);
    }

    public override void Exit()
    {
        base.Exit();
    }

    private bool CanAttack()
    {
        if (Time.time >= enemy.lastTimeAttacked + enemy.attackCooldown)
        {
            enemy.lastTimeAttacked = Time.time;
            return true;
        }
        return false;
    }
}
