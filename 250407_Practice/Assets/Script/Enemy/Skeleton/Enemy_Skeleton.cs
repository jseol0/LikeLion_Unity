using UnityEngine;

public class Enemy_Skeleton : Enemy
{
    public float battleDistance = 5;

    public SkeletonIdleState idleState { get; private set; }
    public SkeletonMoveState moveState { get; private set; }
    public SkeletoenBattleState battleState { get; private set; }
    public Skeleton_AttackState attackState { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        idleState = new SkeletonIdleState(this, stateMachine, "Idle", this);
        moveState = new SkeletonMoveState(this, stateMachine, "Move", this);
        battleState = new SkeletoenBattleState(this, stateMachine, "Move", this);
        attackState = new Skeleton_AttackState(this, stateMachine, "Attack", this);
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
    }

    public override RaycastHit2D IsPlayerDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, battleDistance, whatIsPlayer);
}
