using UnityEngine;

public class Skeleton_AttackState : EnemyState
{
    private Enemy_Skeleton enemy;

    public Skeleton_AttackState(Enemy enemyBase, EnemyStateMachine enemyStateMachine, string animBoolName, Enemy_Skeleton enemy) : base(enemyBase, enemyStateMachine, animBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        enemy.lastTimeAttacked = Time.time;
    }

    public override void Update()
    {
        base.Update();

        enemy.ZeroVelocity();

        if (triggerCalled)
            stateMachine.ChangeState(enemy.battleState);
    }
}
