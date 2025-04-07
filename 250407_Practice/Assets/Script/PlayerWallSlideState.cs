using UnityEngine;

public class PlayerWallSlideState : PlayerState
{
    public PlayerWallSlideState(Player _player, PlayerStateMachine _stateMachine, string _animBooolName) : base(_player, _stateMachine, _animBooolName)
    {
    }

    public override void Enter()
    {
        Debug.Log("Wall Slide State Entered");
        base.Enter();

        //rb.linearVelocity = new Vector2(rb.linearVelocityX, rb.linearVelocityY * player.slideSpeed);
        rb.linearVelocity = new Vector2(rb.linearVelocityX, -player.slideSpeed);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Space))
            stateMachine.ChangeState(player.jumpState);

        if (player.IsGroundDetected())
            stateMachine.ChangeState(player.idleState);
    }
}
