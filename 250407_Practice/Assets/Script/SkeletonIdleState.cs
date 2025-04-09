using Unity.VisualScripting;
using UnityEngine;

public class SkeletonIdleState : EnemyState
{
    private Enemy_Skeleton enemy;

    public SkeletonIdleState(Enemy enemyBase, EnemyStateMachine enemyStateMachine, string animBoolName, Enemy_Skeleton enemy) : base(enemyBase, enemyStateMachine, animBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = enemy.idleTime;
        enemy.ZeroVelocity();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer < 0)
            stateMachine.ChangeState(enemy.moveState);
    }
}
