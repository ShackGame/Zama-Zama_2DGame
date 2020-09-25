using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesController : MonoBehaviour
{
    private float healthUpgradeCost = 300f;
    private float bulletsUpgradeCost = 200f;

    public void UpgradeHealth()
    {
        if(GameManager.Score - healthUpgradeCost > 0)
        {
            GameManager.Score -= healthUpgradeCost;
            GameManager.Health += 2f;
            HealthPickUp.SpawnHealingEffect = true;
        }
    }

    public void UpgradeBullets()
    {
        if (GameManager.Score - bulletsUpgradeCost > 0)
        {
            GameManager.Score -= bulletsUpgradeCost;
            GameManager.Health += 5f;
        }
    }
}
