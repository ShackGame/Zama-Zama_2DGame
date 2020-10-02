using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesController : MonoBehaviour
{
    private float healthUpgradeCost = 300f;
    private float bulletsUpgradeCost = 200f;

    public void UpgradeHealth()
    {
        if(GameManager.instance.Score - healthUpgradeCost > 0)
        {
            GameManager.instance.Score -= healthUpgradeCost;
            GameManager.instance.Health += 2f;
            HealthPickUp.SpawnHealingEffect = true;
        }
    }

    public void UpgradeBullets()
    {
        if (GameManager.instance.Score - bulletsUpgradeCost > 0)
        {
            GameManager.instance.Score -= bulletsUpgradeCost;
            GameManager.instance.Health += 5f;
        }
    }
}
