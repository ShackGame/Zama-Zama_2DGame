using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesDamage : MonoBehaviour
{
    AttackDetails attackDetails;

    private float dmageAmountPit = 0.5f;

    private AudioManager audioManager;

    [SerializeField]
    private string spikesSound;

    private void Start()
    {
        attackDetails.damageAmount = dmageAmountPit;
        attackDetails.position = gameObject.transform.position;

        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.Log("No AudioManager found");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            audioManager.PlaySound(spikesSound);
            GameManager.instance.Health -= 0.5f;
            collision.SendMessage("Damage", attackDetails);
        }
    }
}
