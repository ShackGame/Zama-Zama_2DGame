using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public static bool SpawnHealingEffect = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Health += 2f;
            SpawnHealingEffect = true;
            Destroy(gameObject);
        }
    }
}
