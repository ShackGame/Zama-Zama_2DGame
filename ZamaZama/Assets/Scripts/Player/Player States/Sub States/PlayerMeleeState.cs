using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeState : PlayerAbilityState
{
    private AttackDetails attackDetails;
    
    public PlayerMeleeState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        if (player.InputHandler.NormInputX != 0)
        {
            
            stateMachine.ChangeState(player.MoveState);
        }
        else
        {
            
            stateMachine.ChangeState(player.IdleState);
        }
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();

        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(player.meleePosition.position, playerData.meleeAtackRadius, playerData.whatIsEnemy);

       foreach(Collider2D collider in detectedObjects)
       {
            PlayerStats.Score += 10f;
            collider.transform.parent.SendMessage("Damage", attackDetails);
       }
    }

    public override void DoChecks()
    {
        base.DoChecks();
        
    }

    public override void Enter()
    {
        base.Enter();

        attackDetails.damageAmount = playerData.damageAmount;
        attackDetails.position = player.transform.position;

        player.InputHandler.UseMeleeInput();

    }

    public override void Exit()
    {
        base.Exit();
    }
}
