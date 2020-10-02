using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitController : MonoBehaviour
{
    AttackDetails attackDetails;

    private float dmageAmountPit = 5f;

    private void Start()
    {
        attackDetails.damageAmount = dmageAmountPit;
        attackDetails.position = gameObject.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameManager.instance.Health -= 5f;
            collision.SendMessage("Damage", attackDetails);
        }
    }
}
