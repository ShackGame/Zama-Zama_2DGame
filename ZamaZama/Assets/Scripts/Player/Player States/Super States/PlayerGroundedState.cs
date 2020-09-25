using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class PlayerGroundedState : PlayerState
{
    protected int xInput;

    private bool JumpInput;
    private bool grabInput;
    private bool isGrounded;
    private bool isTouchingWall;
    private bool MeleeInput;
    private bool ShootInput;

    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isGrounded = player.CheckIfGrounded();
        isTouchingWall = player.CheckIfTouchingWall();
    }

    public override void Enter()
    {
        base.Enter();

        player.JumpState.ResetAmountOfJumpsLeft();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.InputHandler.NormInputX;
        JumpInput = player.InputHandler.JumpInput;
        grabInput = player.InputHandler.GrabInput;
        MeleeInput = player.InputHandler.MeleeInput;
        ShootInput = player.InputHandler.ShootInput;

        if (JumpInput && player.JumpState.CanJump())
        {           
            player.InputHandler.UseJumpInput();
            stateMachine.ChangeState(player.JumpState);
        }
        else if (MeleeInput && player.InputHandler.NormInputX == 0)
        {
            stateMachine.ChangeState(player.MeleeState);                   
        }
        else if (ShootInput && player.InputHandler.NormInputX == 0)
        {
            stateMachine.ChangeState(player.RangedAttackState);
        }
        else if (!isGrounded)
        {
            player.InAirState.StartCoyoteTime();
            stateMachine.ChangeState(player.InAirState);
        }
        else if (isTouchingWall && grabInput)
        {
            stateMachine.ChangeState(player.WallGrabState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
