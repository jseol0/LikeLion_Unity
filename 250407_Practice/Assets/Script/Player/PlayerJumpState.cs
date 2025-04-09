using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(Player _player, PlayerStateMachine _stateMachine, string _animBooolName) : base(_player, _stateMachine, _animBooolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        rb.linearVelocity = new Vector2(rb.linearVelocityX, player.jumpForce);
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

        if (rb.linearVelocityY < 0)
            stateMachine.ChangeState(player.airState);
    }
}
