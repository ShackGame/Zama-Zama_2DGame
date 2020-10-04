using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public static bool SpawnHealingEffect = false;

    private bool needsHealth = false;

    private void FixedUpdate()
    {
        if (GameManager.instance.Health < 5f)
        {
            needsHealth = true;
        }
        else
        {
            needsHealth = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")  && needsHealth)
        {
            needsHealth = false;
            GameManager.instance.Health += 2f;
            SpawnHealingEffect = true;
            Destroy(gameObject);
                     
        }
    }
}
