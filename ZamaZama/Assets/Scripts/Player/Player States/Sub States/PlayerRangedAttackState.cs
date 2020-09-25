using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangedAttackState : PlayerAbilityState
{
    
    public PlayerRangedAttackState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {

    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        stateMachine.ChangeState(player.IdleState);
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();

        playerData.projectile = GameObject.Instantiate(playerData.projectile, player.attackPosition.position, player.attackPosition.rotation);
        playerData.projectileScript = playerData.projectile.GetComponent<PlayerProjectile>();
        playerData.projectileScript.FireProjectile(playerData.projectileSpeed, playerData.projectileTravelDistance, playerData.projectileDamage);
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
    }
}
