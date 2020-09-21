using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerState
{
    public PlayerDeadState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        GameObject.Instantiate(playerData.deathBloodParticle, player.transform.position, playerData.deathBloodParticle.transform.rotation);
        GameObject.Instantiate(playerData.deathChukParticle, player.transform.position, playerData.deathChukParticle.transform.rotation);

        player.respawn.Respawn();
        GameObject.Destroy(player.gameObject);
    }
}
