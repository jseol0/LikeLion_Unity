using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(Player _player, PlayerStateMachine _stateMachine, string _animBooolName) : base(_player, _stateMachine, _animBooolName)
    {
    }

    public override void Enter()
    {
        Debug.Log("Jump State Entered");
        base.Enter();

        if (player.IsWallDetected())
            rb.linearVelocity = new Vector2(-player.facingDir * player.jumpForce, player.jumpForce);

        rb.linearVelocity = new Vector2(rb.linearVelocityX, player.jumpForce);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (rb.linearVelocityY < 0)
            stateMachine.ChangeState(player.airState);

        if (player.IsWallDetected())
            stateMachine.ChangeState(player.wallSlideState);
    }
}
