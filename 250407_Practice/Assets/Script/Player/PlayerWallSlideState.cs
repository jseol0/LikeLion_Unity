using UnityEngine;

public class PlayerWallSlideState : PlayerState
{
    public PlayerWallSlideState(Player _player, PlayerStateMachine _stateMachine, string _animBooolName) : base(_player, _stateMachine, _animBooolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (yInput < 0)
            rb.linearVelocity = new Vector2(0f, rb.linearVelocityY);
        else
            rb.linearVelocity = new Vector2(0f, rb.linearVelocityY * 0.7f);

        if (player.IsGroundDetected())
            stateMachine.ChangeState(player.idleState);

        if (xInput != 0 && player.facingDir != xInput)
            stateMachine.ChangeState(player.idleState);

        if (Input.GetKeyDown(KeyCode.Space))
        { 
            stateMachine.ChangeState(player.wallJumpState);
            return;
        }
    }
}
