using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangedAttackState : PlayerAbilityState
{
    AttackDetails attackDetails;
    

    public PlayerRangedAttackState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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

        GameObject bullet = BulletPool.SharedInstance.GetPooledBullet();

        if(bullet != null)
        {
            bullet.transform.position = player.attackPosition.position;
            bullet.transform.rotation = player.attackPosition.rotation;
            bullet.GetComponent<Projectile>().FireProjectile(playerData.projectileSpeed, playerData.projectileTravelDistance, playerData.projectileDamage);
            bullet.SetActive(true);
        }              
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        player.InputHandler.UseShootInput();
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
