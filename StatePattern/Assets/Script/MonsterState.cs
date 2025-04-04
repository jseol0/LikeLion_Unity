using UnityEngine;

public class MonsterState
{
    protected MonsterStateMachine stateMachine;
    protected Monster monster;

    private string animBoolName;

    public MonsterState(Monster _monster, MonsterStateMachine _stateMachine, string _animBoolName)
    {
        this.monster = _monster;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        Debug.Log("Enter " + animBoolName);
    }

    public virtual void Update()
    {
        Debug.Log("Update " + animBoolName);
    }

    public virtual void Exit()
    {
        Debug.Log("Exit " + animBoolName);
    }
}
