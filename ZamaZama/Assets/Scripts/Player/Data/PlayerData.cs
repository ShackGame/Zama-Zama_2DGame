using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Health")]
    public float maxHealth = 5f;
    public GameObject hitParticle;
    public GameObject deathBloodParticle;
    public GameObject deathChukParticle;

    [Header("Move State")]
    public float movementVelocity = 10f;

    [Header("Combat State")]
    public float meleeAtackRadius = 0.5f;
    public LayerMask whatIsEnemy;
    public float damageAmount = 10f;

    [Header("Jump State")]
    public float jumpVelocity = 15f;
    public int amountOfJumps = 1;

    [Header("In Air State")]
    public float coyoteTime = 0.2f;
    public float variableJumpHeightMultiplier = 0.5f;

    [Header("Wall Slide State")]
    public float wallSlideVelocity = 3f;

    [Header("Wall Climb State")]
    public float wallClimbVelocity = 3f;

    [Header("Ledge Climb State")]
    public Vector2 startOffset;
    public Vector2 stopOffset;

    [Header("Check Variables")]
    public float groundCheckRadius = 0.3f;
    public float wallCheckDistance = 0.5f;
    public LayerMask whatIsGround;

    [Header("Game-Over Variable")]
    public bool isDead = false;
    public float waitTime = 1f;

    [Header("Shoot Variables")]
    public GameObject projectile;
    public PlayerProjectile projectileScript;
    public float bulletPosRadius = 0.1f;
    public float projectileDamage = 20f;
    public float projectileSpeed = 12f;
    public float projectileTravelDistance;
    

}
