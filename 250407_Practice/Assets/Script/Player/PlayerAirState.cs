using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(Player _player, PlayerStateMachine _stateMachine, string _animBooolName) : base(_player, _stateMachine, _animBooolName)
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

        if (Input.GetKeyDown(KeyCode.Space) && !player.dubleJump)
        {
            player.dubleJump = true;
            stateMachine.ChangeState(player.jumpState);
        }

        if (player.IsWallDetected())
            stateMachine.ChangeState(player.wallSlideState);

        if (player.IsGroundDetected())
            stateMachine.ChangeState(player.idleState);

        if (xInput != 0)
            player.SetVelocity(player.moveSpeed * xInput * 0.8f, rb.linearVelocityY);
    }
}
