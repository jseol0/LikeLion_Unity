using UnityEngine;

public class MonsterIdleState : MonsterState
{
    public MonsterIdleState(Monster _monster, MonsterStateMachine _stateMachine, string _animBoolName)
        : base(_monster, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.M))
            monster.stateMachine.ChangeState(monster.moveState);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
